-- ========================================
-- SP1: Exam Generation (ENHANCED VERSION)
-- يحدد عدد أسئلة True/False وعدد أسئلة Multiple Choice
-- ========================================

CREATE OR ALTER PROCEDURE SP_GenerateExam
    @StudentID INT,
    @CourseName NVARCHAR(200),
    @NumTrueFalse INT = 5,           -- عدد أسئلة True/False
    @NumMultipleChoice INT = 5       -- عدد أسئلة Multiple Choice
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @CourseID INT;
    DECLARE @ExamID INT;
    DECLARE @AvailableTF INT;
    DECLARE @AvailableMCQ INT;
    DECLARE @TotalQuestions INT;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. الحصول على Course ID من اسم الكورس
        SELECT @CourseID = course_id 
        FROM Courses 
        WHERE course_name = @CourseName;
        
        -- 2. التحقق من وجود الكورس
        IF @CourseID IS NULL
        BEGIN
            PRINT 'Error: Course not found!';
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- 3. التحقق من أن الطالب مسجل في الكورس
        IF NOT EXISTS (
            SELECT 1 FROM Student_Courses 
            WHERE student_id = @StudentID AND course_id = @CourseID
        )
        BEGIN
            PRINT 'Error: Student is not enrolled in this course!';
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- 4. التحقق من وجود أسئلة True/False كافية
        SELECT @AvailableTF = COUNT(*)
        FROM Questions
        WHERE course_id = @CourseID AND question_type = 'true_false';
        
        IF @AvailableTF < @NumTrueFalse
        BEGIN
            PRINT 'Error: Not enough True/False questions!';
            PRINT 'Requested: ' + CAST(@NumTrueFalse AS VARCHAR) + ', Available: ' + CAST(@AvailableTF AS VARCHAR);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- 5. التحقق من وجود أسئلة Multiple Choice كافية
        SELECT @AvailableMCQ = COUNT(*)
        FROM Questions
        WHERE course_id = @CourseID AND question_type = 'multiple_choice';
        
        IF @AvailableMCQ < @NumMultipleChoice
        BEGIN
            PRINT 'Error: Not enough Multiple Choice questions!';
            PRINT 'Requested: ' + CAST(@NumMultipleChoice AS VARCHAR) + ', Available: ' + CAST(@AvailableMCQ AS VARCHAR);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- 6. حساب إجمالي عدد الأسئلة
        SET @TotalQuestions = @NumTrueFalse + @NumMultipleChoice;
        
        -- 7. إنشاء سجل امتحان جديد
        INSERT INTO Student_Exams (student_id, course_id, total_questions, status)
        VALUES (@StudentID, @CourseID, @TotalQuestions, 'generated');
        
        SET @ExamID = SCOPE_IDENTITY();
        
        -- 8. اختيار أسئلة True/False عشوائية
        INSERT INTO Exam_Questions (exam_id, question_id, question_order)
        SELECT TOP (@NumTrueFalse)
            @ExamID,
            question_id,
            ROW_NUMBER() OVER (ORDER BY NEWID())
        FROM Questions
        WHERE course_id = @CourseID AND question_type = 'true_false'
        ORDER BY NEWID();
        
        -- 9. اختيار أسئلة Multiple Choice عشوائية (بعد التروفولص)
        INSERT INTO Exam_Questions (exam_id, question_id, question_order)
        SELECT TOP (@NumMultipleChoice)
            @ExamID,
            question_id,
            @NumTrueFalse + ROW_NUMBER() OVER (ORDER BY NEWID())
        FROM Questions
        WHERE course_id = @CourseID AND question_type = 'multiple_choice'
        ORDER BY NEWID();
        
        COMMIT TRANSACTION;
        
        -- 10. عرض الأسئلة المولدة للطالب
        PRINT '========================================';
        PRINT '          EXAM GENERATED';
        PRINT '========================================';
        PRINT 'Exam ID: ' + CAST(@ExamID AS VARCHAR);
        PRINT 'Course: ' + @CourseName;
        PRINT 'True/False Questions: ' + CAST(@NumTrueFalse AS VARCHAR);
        PRINT 'Multiple Choice Questions: ' + CAST(@NumMultipleChoice AS VARCHAR);
        PRINT 'Total Questions: ' + CAST(@TotalQuestions AS VARCHAR);
        PRINT '========================================';
        PRINT '';
        
        -- عرض الأسئلة مع خياراتها
        SELECT 
            eq.question_order AS [Q#],
            q.question_id AS QuestionID,
            CASE 
                WHEN q.question_type = 'true_false' THEN '[T/F]'
                ELSE '[MCQ]'
            END AS Type,
            q.question_text AS Question,
            q.points AS Points,
            CASE 
                WHEN q.question_type = 'multiple_choice' THEN
                    STUFF((
                        SELECT CHAR(13) + CHAR(10) + 
                               CAST(option_number AS VARCHAR) + '. ' + option_text
                        FROM Question_Options 
                        WHERE question_id = q.question_id
                        ORDER BY option_number
                        FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '')
                ELSE 'Answer: True / False'
            END AS Options
        FROM Exam_Questions eq
        INNER JOIN Questions q ON eq.question_id = q.question_id
        WHERE eq.exam_id = @ExamID
        ORDER BY eq.question_order;
        
        -- 11. ملخص الامتحان
        SELECT 
            @ExamID AS ExamID,
            @CourseName AS CourseName,
            @NumTrueFalse AS TrueFalseCount,
            @NumMultipleChoice AS MultipleChoiceCount,
            @TotalQuestions AS TotalQuestions,
            SUM(q.points) AS TotalPoints
        FROM Exam_Questions eq
        INNER JOIN Questions q ON eq.question_id = q.question_id
        WHERE eq.exam_id = @ExamID;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO




















-- ========================================
-- SP2: Submit Exam Answers
-- يحفظ إجابة واحدة في كل مرة
-- ========================================

CREATE OR ALTER PROCEDURE SP_SubmitExamAnswers
    @ExamID INT,
    @QuestionID INT,
    @StudentAnswer NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TotalQuestions INT;
    DECLARE @AnsweredQuestions INT;
    
    BEGIN TRY
        -- 1. التحقق من وجود الامتحان
        IF NOT EXISTS (SELECT 1 FROM Student_Exams WHERE exam_id = @ExamID)
        BEGIN
            PRINT 'Error: Exam not found!';
            RETURN;
        END
        
        -- 2. التحقق من أن الامتحان في حالة generated أو submitted
        DECLARE @ExamStatus VARCHAR(20);
        SELECT @ExamStatus = status FROM Student_Exams WHERE exam_id = @ExamID;
        
        IF @ExamStatus = 'corrected'
        BEGIN
            PRINT 'Error: Exam already corrected! Cannot modify answers.';
            RETURN;
        END
        
        -- 3. التحقق من أن السؤال موجود في الامتحان
        IF NOT EXISTS (
            SELECT 1 FROM Exam_Questions 
            WHERE exam_id = @ExamID AND question_id = @QuestionID
        )
        BEGIN
            PRINT 'Error: Question not found in this exam!';
            RETURN;
        END
        
        -- 4. حفظ أو تحديث الإجابة
        IF EXISTS (
            SELECT 1 FROM Student_Answers 
            WHERE exam_id = @ExamID AND question_id = @QuestionID
        )
        BEGIN
            -- تحديث الإجابة الموجودة
            UPDATE Student_Answers
            SET student_answer = @StudentAnswer,
                answered_date = GETDATE()
            WHERE exam_id = @ExamID AND question_id = @QuestionID;
            
            PRINT '✓ Answer updated successfully for Question ID: ' + CAST(@QuestionID AS VARCHAR);
        END
        ELSE
        BEGIN
            -- إضافة إجابة جديدة
            INSERT INTO Student_Answers (exam_id, question_id, student_answer)
            VALUES (@ExamID, @QuestionID, @StudentAnswer);
            
            PRINT '✓ Answer saved successfully for Question ID: ' + CAST(@QuestionID AS VARCHAR);
        END
        
        -- 5. تحديث حالة الامتحان إلى submitted (أول مرة بس)
        UPDATE Student_Exams
        SET status = 'submitted'
        WHERE exam_id = @ExamID AND status = 'generated';
        
        -- 6. عرض تقدم الإجابة
        SELECT @TotalQuestions = total_questions 
        FROM Student_Exams 
        WHERE exam_id = @ExamID;
        
        SELECT @AnsweredQuestions = COUNT(*) 
        FROM Student_Answers 
        WHERE exam_id = @ExamID;
        
        PRINT 'Progress: ' + CAST(@AnsweredQuestions AS VARCHAR) + '/' + CAST(@TotalQuestions AS VARCHAR) + ' questions answered';
        
        IF @AnsweredQuestions = @TotalQuestions
        BEGIN
            PRINT '';
            PRINT '========================================';
            PRINT 'All questions answered!';
            PRINT 'You can now submit for correction.';
            PRINT '========================================';
        END
        
    END TRY
    BEGIN CATCH
        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO




















-- ========================================
-- SP3: Correct Exam
-- يصحح الامتحان ويحسب النتيجة
-- ========================================

CREATE OR ALTER PROCEDURE SP_CorrectExam
    @ExamID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TotalQuestions INT;
    DECLARE @AnsweredQuestions INT;
    DECLARE @CorrectAnswers INT;
    DECLARE @TotalPoints INT;
    DECLARE @EarnedPoints INT;
    DECLARE @Percentage DECIMAL(5,2);
    DECLARE @StudentID INT;
    DECLARE @CourseID INT;
    DECLARE @StudentName NVARCHAR(200);
    DECLARE @CourseName NVARCHAR(200);
    DECLARE @TFCorrect INT, @TFWrong INT, @TFTotal INT;
    DECLARE @MCQCorrect INT, @MCQWrong INT, @MCQTotal INT;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. التحقق من وجود الامتحان
        IF NOT EXISTS (SELECT 1 FROM Student_Exams WHERE exam_id = @ExamID)
        BEGIN
            PRINT 'Error: Exam not found!';
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        -- 2. التحقق من أن الامتحان تم تسليمه
        DECLARE @ExamStatus VARCHAR(20);
        SELECT @ExamStatus = status FROM Student_Exams WHERE exam_id = @ExamID;
        
        IF @ExamStatus = 'generated'
        BEGIN
            PRINT 'Error: Exam not submitted yet!';
            ROLLBACK TRANSACTION;
            RETURN;
        END
        
        IF @ExamStatus = 'corrected'
        BEGIN
            PRINT 'Warning: Exam already corrected! Re-correcting...';
        END
        
        -- 3. الحصول على معلومات الامتحان
        SELECT 
            @StudentID = student_id,
            @CourseID = course_id,
            @TotalQuestions = total_questions
        FROM Student_Exams
        WHERE exam_id = @ExamID;
        
        SELECT @StudentName = first_name + ' ' + last_name
        FROM Students WHERE student_id = @StudentID;
        
        SELECT @CourseName = course_name
        FROM Courses WHERE course_id = @CourseID;
        
        -- 4. التحقق من أن الطالب جاوب على كل الأسئلة
        SELECT @AnsweredQuestions = COUNT(*)
        FROM Student_Answers
        WHERE exam_id = @ExamID;
        
        IF @AnsweredQuestions < @TotalQuestions
        BEGIN
            PRINT 'Warning: Student answered ' + CAST(@AnsweredQuestions AS VARCHAR) + 
                  ' out of ' + CAST(@TotalQuestions AS VARCHAR) + ' questions.';
            PRINT 'Unanswered questions will be marked as wrong.';
        END
        
        -- 5. التصحيح: مقارنة إجابات الطالب بالإجابات الصحيحة
        UPDATE sa
        SET 
            sa.is_correct = CASE 
                WHEN LOWER(LTRIM(RTRIM(sa.student_answer))) = LOWER(LTRIM(RTRIM(q.correct_answer))) 
                THEN 1 
                ELSE 0 
            END,
            sa.points_earned = CASE 
                WHEN LOWER(LTRIM(RTRIM(sa.student_answer))) = LOWER(LTRIM(RTRIM(q.correct_answer))) 
                THEN q.points 
                ELSE 0 
            END
        FROM Student_Answers sa
        INNER JOIN Questions q ON sa.question_id = q.question_id
        WHERE sa.exam_id = @ExamID;
        
        -- 6. حساب الإحصائيات العامة
        SELECT @CorrectAnswers = COUNT(*)
        FROM Student_Answers
        WHERE exam_id = @ExamID AND is_correct = 1;
        
        SELECT @TotalPoints = SUM(q.points)
        FROM Exam_Questions eq
        INNER JOIN Questions q ON eq.question_id = q.question_id
        WHERE eq.exam_id = @ExamID;
        
        SELECT @EarnedPoints = ISNULL(SUM(points_earned), 0)
        FROM Student_Answers
        WHERE exam_id = @ExamID;
        
        -- 7. إحصائيات True/False
        SELECT 
            @TFTotal = COUNT(*),
            @TFCorrect = SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END),
            @TFWrong = SUM(CASE WHEN sa.is_correct = 0 OR sa.is_correct IS NULL THEN 1 ELSE 0 END)
        FROM Exam_Questions eq
        INNER JOIN Questions q ON eq.question_id = q.question_id
        LEFT JOIN Student_Answers sa ON sa.exam_id = eq.exam_id AND sa.question_id = q.question_id
        WHERE eq.exam_id = @ExamID AND q.question_type = 'true_false';
        
        -- 8. إحصائيات Multiple Choice
        SELECT 
            @MCQTotal = COUNT(*),
            @MCQCorrect = SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END),
            @MCQWrong = SUM(CASE WHEN sa.is_correct = 0 OR sa.is_correct IS NULL THEN 1 ELSE 0 END)
        FROM Exam_Questions eq
        INNER JOIN Questions q ON eq.question_id = q.question_id
        LEFT JOIN Student_Answers sa ON sa.exam_id = eq.exam_id AND sa.question_id = q.question_id
        WHERE eq.exam_id = @ExamID AND q.question_type = 'multiple_choice';
        
        -- 9. حساب النسبة المئوية
        IF @TotalPoints > 0
            SET @Percentage = (@EarnedPoints * 100.0) / @TotalPoints;
        ELSE
            SET @Percentage = 0;
        
        -- 10. تحديث النتيجة في جدول الامتحانات
        UPDATE Student_Exams
        SET 
            score = @EarnedPoints,
            percentage = @Percentage,
            status = 'corrected'
        WHERE exam_id = @ExamID;
        
        COMMIT TRANSACTION;
        
        -- 11. عرض النتيجة النهائية (Summary)
        PRINT '========================================';
        PRINT '        EXAM CORRECTION REPORT';
        PRINT '========================================';
        PRINT 'Student: ' + @StudentName;
        PRINT 'Course: ' + @CourseName;
        PRINT 'Exam ID: ' + CAST(@ExamID AS VARCHAR);
        PRINT '========================================';
        PRINT 'OVERALL STATISTICS:';
        PRINT '  Total Questions: ' + CAST(@TotalQuestions AS VARCHAR);
        PRINT '  Answered: ' + CAST(@AnsweredQuestions AS VARCHAR);
        PRINT '  Correct: ' + CAST(@CorrectAnswers AS VARCHAR);
        PRINT '  Wrong: ' + CAST(@AnsweredQuestions - @CorrectAnswers AS VARCHAR);
        PRINT '';
        PRINT 'TRUE/FALSE SECTION:';
        PRINT '  Total: ' + CAST(ISNULL(@TFTotal, 0) AS VARCHAR);
        PRINT '  Correct: ' + CAST(ISNULL(@TFCorrect, 0) AS VARCHAR);
        PRINT '  Wrong: ' + CAST(ISNULL(@TFWrong, 0) AS VARCHAR);
        PRINT '';
        PRINT 'MULTIPLE CHOICE SECTION:';
        PRINT '  Total: ' + CAST(ISNULL(@MCQTotal, 0) AS VARCHAR);
        PRINT '  Correct: ' + CAST(ISNULL(@MCQCorrect, 0) AS VARCHAR);
        PRINT '  Wrong: ' + CAST(ISNULL(@MCQWrong, 0) AS VARCHAR);
        PRINT '========================================';
        PRINT 'SCORE:';
        PRINT '  Total Points: ' + CAST(@TotalPoints AS VARCHAR);
        PRINT '  Earned Points: ' + CAST(@EarnedPoints AS VARCHAR);
        PRINT '  Percentage: ' + CAST(@Percentage AS VARCHAR) + '%';
        PRINT '========================================';
        PRINT 'RESULT: ' + CASE 
            WHEN @Percentage >= 50 THEN 'PASSED ✓'
            ELSE 'FAILED ✗'
        END;
        PRINT '========================================';
        
        -- 12. عرض ملخص النتيجة
        SELECT 
            @ExamID AS ExamID,
            @StudentName AS StudentName,
            @CourseName AS CourseName,
            @TotalQuestions AS TotalQuestions,
            @AnsweredQuestions AS AnsweredQuestions,
            @CorrectAnswers AS CorrectAnswers,
            @AnsweredQuestions - @CorrectAnswers AS WrongAnswers,
            @TFTotal AS TrueFalseTotal,
            @TFCorrect AS TrueFalseCorrect,
            @MCQTotal AS MultipleChoiceTotal,
            @MCQCorrect AS MultipleChoiceCorrect,
            @TotalPoints AS TotalPoints,
            @EarnedPoints AS EarnedPoints,
            @Percentage AS Percentage,
            CASE 
                WHEN @Percentage >= 90 THEN 'Excellent'
                WHEN @Percentage >= 75 THEN 'Very Good'
                WHEN @Percentage >= 65 THEN 'Good'
                WHEN @Percentage >= 50 THEN 'Pass'
                ELSE 'Fail'
            END AS Grade,
            CASE 
                WHEN @Percentage >= 50 THEN 'Passed ✓'
                ELSE 'Failed ✗'
            END AS Result;
        
        -- 13. عرض تفاصيل كل سؤال
        SELECT 
            eq.question_order AS [Q#],
            CASE 
                WHEN q.question_type = 'true_false' THEN '[T/F]'
                ELSE '[MCQ]'
            END AS Type,
            LEFT(q.question_text, 60) + '...' AS Question,
            CASE 
                WHEN q.question_type = 'true_false' THEN q.correct_answer
                ELSE (
                    SELECT option_text 
                    FROM Question_Options 
                    WHERE question_id = q.question_id 
                    AND option_number = TRY_CAST(q.correct_answer AS INT)
                )
            END AS CorrectAnswer,
            ISNULL(sa.student_answer, 'Not Answered') AS StudentAnswer,
            CASE 
                WHEN sa.is_correct = 1 THEN '✓ Correct'
                WHEN sa.is_correct = 0 THEN '✗ Wrong'
                ELSE '- Skipped'
            END AS Status,
            CAST(ISNULL(sa.points_earned, 0) AS VARCHAR) + '/' + CAST(q.points AS VARCHAR) AS Points
        FROM Exam_Questions eq
        INNER JOIN Questions q ON eq.question_id = q.question_id
        LEFT JOIN Student_Answers sa ON sa.exam_id = eq.exam_id AND sa.question_id = q.question_id
        WHERE eq.exam_id = @ExamID
        ORDER BY eq.question_order;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

PRINT '';
PRINT '========================================';
PRINT 'All 3 Stored Procedures Created!';
PRINT '========================================';
PRINT 'Available Procedures:';
PRINT '1. SP_GenerateExam - Generate exam with custom T/F and MCQ counts';
PRINT '2. SP_SubmitExamAnswers - Submit individual answers';
PRINT '3. SP_CorrectExam - Correct exam and calculate results';
PRINT '========================================';