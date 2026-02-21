-- ========================================
-- COMPLETE EXAM EXAMPLE
-- من البداية للنهاية
-- ========================================

-- ========================================
-- STEP 0: التحضير - التأكد من وجود البيانات
-- ========================================

-- التحقق من الطالب
SELECT student_id, first_name + ' ' + last_name AS StudentName, email
FROM Students
WHERE student_id = 1;

-- التحقق من تسجيل الطالب في الكورس
SELECT sc.student_id, s.first_name, c.course_name, sc.status
FROM Student_Courses sc
INNER JOIN Students s ON sc.student_id = s.student_id
INNER JOIN Courses c ON sc.course_id = c.course_id
WHERE sc.student_id = 1 AND c.course_name = 'Database Systems';

-- التحقق من عدد الأسئلة المتاحة
SELECT 
    question_type,
    COUNT(*) AS AvailableQuestions
FROM Questions
WHERE course_id = 1
GROUP BY question_type;

PRINT '';
PRINT '========================================';
PRINT 'STEP 1: GENERATING EXAM';
PRINT '========================================';
GO

-- ========================================
-- STEP 1: توليد الامتحان
-- طلب: 3 True/False + 2 Multiple Choice
-- ========================================

EXEC SP_GenerateExam 
    @StudentID = 1,
    @CourseName = 'Database Systems',
    @NumTrueFalse = 3,
    @NumMultipleChoice = 2;

-- الامتحان اتولد بـ exam_id = 1 (غالبًا)
-- هنفترض exam_id = 1 في باقي المثال

GO

PRINT '';
PRINT '========================================';
PRINT 'STEP 2: VIEWING EXAM DETAILS';
PRINT '========================================';
GO

-- ========================================
-- STEP 2: عرض تفاصيل الامتحان المولد
-- ========================================

-- عرض معلومات الامتحان
SELECT 
    exam_id,
    student_id,
    course_id,
    exam_date,
    total_questions,
    status
FROM Student_Exams
WHERE exam_id = 2;

-- عرض الأسئلة المختارة
SELECT 
    eq.exam_id,
    eq.question_order,
    eq.question_id,
    q.question_type,
    q.question_text,
    q.correct_answer,
    q.points
FROM Exam_Questions eq
INNER JOIN Questions q ON eq.question_id = q.question_id
WHERE eq.exam_id = 2
ORDER BY eq.question_order;

GO

PRINT '';
PRINT '========================================';
PRINT 'STEP 3: STUDENT ANSWERING QUESTIONS';
PRINT '========================================';
GO

-- ========================================
-- STEP 3: الطالب يجاوب على الأسئلة
-- ========================================

-- ملاحظة: استخدم الـ question_id الفعلية من الخطوة السابقة
-- هنا مثال افتراضي

-- السؤال 1 (افترض question_id = 1, True/False)

EXEC SP_SubmitExamAnswers 
    @ExamID = 2, 
    @QuestionID = 10, 
    @StudentAnswer = 'True';

-- السؤال 2 (افترض question_id = 2, True/False)
EXEC SP_SubmitExamAnswers 
    @ExamID = 2, 
    @QuestionID = 8, 
    @StudentAnswer = 'False';
    
-- السؤال 3 (افترض question_id = 5, True/False)
EXEC SP_SubmitExamAnswers 
    @ExamID = 2, 
    @QuestionID = 20, 
    @StudentAnswer = '4';  -- إجابة خاطئة متعمدة

-- السؤال 4 (افترض question_id = 11, MCQ)
EXEC SP_SubmitExamAnswers 
    @ExamID = 2, 
    @QuestionID = 3, 
    @StudentAnswer = 'True';

-- السؤال 5 (افترض question_id = 13, MCQ)
EXEC SP_SubmitExamAnswers 
    @ExamID = 2, 
    @QuestionID = 13, 
    @StudentAnswer = '3';  -- إجابة خاطئة متعمدة

GO

PRINT '';
PRINT '========================================';
PRINT 'STEP 4: VIEWING SUBMITTED ANSWERS';
PRINT '========================================';
GO

-- ========================================
-- STEP 4: عرض الإجابات المُسلمة (قبل التصحيح)
-- ========================================

SELECT 
    sa.exam_id,
    sa.question_id,
    q.question_text,
    q.question_type,
    sa.student_answer,
    sa.is_correct,  -- لسه NULL
    sa.points_earned,  -- لسه NULL
    sa.answered_date
FROM Student_Answers sa
INNER JOIN Questions q ON sa.question_id = q.question_id
WHERE sa.exam_id = 2
ORDER BY sa.question_id;

-- عرض حالة الامتحان
SELECT exam_id, status, score, percentage
FROM Student_Exams
WHERE exam_id = 2;

GO

PRINT '';
PRINT '========================================';
PRINT 'STEP 5: CORRECTING THE EXAM';
PRINT '========================================';
GO

-- ========================================
-- STEP 5: تصحيح الامتحان
-- ========================================

EXEC SP_CorrectExam @ExamID = 1;

GO

PRINT '';
PRINT '========================================';
PRINT 'STEP 6: FINAL RESULTS ANALYSIS';
PRINT '========================================';
GO

-- ========================================
-- STEP 6: تحليل النتائج النهائية
-- ========================================

-- 6.1 النتيجة النهائية
SELECT 
    se.exam_id,
    s.first_name + ' ' + s.last_name AS StudentName,
    c.course_name AS CourseName,
    se.exam_date,
    se.total_questions,
    se.score,
    se.percentage,
    CASE 
        WHEN se.percentage >= 90 THEN 'Excellent'
        WHEN se.percentage >= 75 THEN 'Very Good'
        WHEN se.percentage >= 65 THEN 'Good'
        WHEN se.percentage >= 50 THEN 'Pass'
        ELSE 'Fail'
    END AS Grade,
    CASE 
        WHEN se.percentage >= 50 THEN 'PASSED ✓'
        ELSE 'FAILED ✗'
    END AS Result
FROM Student_Exams se
INNER JOIN Students s ON se.student_id = s.student_id
INNER JOIN Courses c ON se.course_id = c.course_id
WHERE se.exam_id = 2;

-- 6.2 تفاصيل كل إجابة (بعد التصحيح)
SELECT 
    eq.question_order AS [Q#],
    q.question_type AS Type,
    LEFT(q.question_text, 50) + '...' AS Question,
    q.correct_answer AS CorrectAnswer,
    sa.student_answer AS StudentAnswer,
    CASE 
        WHEN sa.is_correct = 1 THEN '✓ Correct'
        ELSE '✗ Wrong'
    END AS Result,
    CAST(sa.points_earned AS VARCHAR) + '/' + CAST(q.points AS VARCHAR) AS Points
FROM Exam_Questions eq
INNER JOIN Questions q ON eq.question_id = q.question_id
INNER JOIN Student_Answers sa ON sa.exam_id = eq.exam_id AND sa.question_id = q.question_id
WHERE eq.exam_id = 2
ORDER BY eq.question_order;

-- 6.3 إحصائيات حسب نوع السؤال
SELECT 
    q.question_type AS QuestionType,
    COUNT(*) AS TotalQuestions,
    SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) AS CorrectAnswers,
    SUM(CASE WHEN sa.is_correct = 0 THEN 1 ELSE 0 END) AS WrongAnswers,
    CAST(SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) AS SuccessRate
FROM Exam_Questions eq
INNER JOIN Questions q ON eq.question_id = q.question_id
LEFT JOIN Student_Answers sa ON sa.exam_id = eq.exam_id AND sa.question_id = q.question_id
WHERE eq.exam_id = 2
GROUP BY q.question_type;

GO

PRINT '';
PRINT '========================================';
PRINT 'BONUS: ADDITIONAL USEFUL QUERIES';
PRINT '========================================';
GO

-- ========================================
-- BONUS QUERIES
-- ========================================

-- إيجاد الأسئلة الأصعب (أكثر الأسئلة الطلاب بيغلطوا فيها)
PRINT '--- Most Difficult Questions ---';
SELECT TOP 5
    q.question_id,
    LEFT(q.question_text, 60) + '...' AS Question,
    q.question_type,
    COUNT(sa.answer_id) AS TotalAttempts,
    SUM(CASE WHEN sa.is_correct = 0 THEN 1 ELSE 0 END) AS WrongAnswers,
    CAST(SUM(CASE WHEN sa.is_correct = 0 THEN 1 ELSE 0 END) * 100.0 / COUNT(sa.answer_id) AS DECIMAL(5,2)) AS FailureRate
FROM Questions q
INNER JOIN Student_Answers sa ON q.question_id = sa.question_id
WHERE q.course_id = 1
GROUP BY q.question_id, q.question_text, q.question_type
HAVING COUNT(sa.answer_id) > 0
ORDER BY FailureRate DESC;

-- جميع امتحانات الطالب في الكورس
PRINT '';
PRINT '--- All Student Exams in Course ---';
SELECT 
    se.exam_id,
    se.exam_date,
    se.total_questions,
    se.score,
    se.percentage,
    CASE 
        WHEN se.percentage >= 50 THEN 'Pass'
        ELSE 'Fail'
    END AS Result,
    se.status
FROM Student_Exams se
WHERE se.student_id = 1 AND se.course_id = 1
ORDER BY se.exam_date DESC;

-- مقارنة أداء الطالب (True/False vs MCQ)
PRINT '';
PRINT '--- Student Performance by Question Type ---';
SELECT 
    q.question_type,
    COUNT(*) AS TotalAnswered,
    SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) AS Correct,
    CAST(SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) AS SuccessRate
FROM Student_Answers sa
INNER JOIN Questions q ON sa.question_id = q.question_id
INNER JOIN Student_Exams se ON sa.exam_id = se.exam_id
WHERE se.student_id = 1 AND se.course_id = 1
GROUP BY q.question_type;

GO

PRINT '';
PRINT '========================================';
PRINT 'COMPLETE EXAMPLE FINISHED!';
PRINT '========================================';
PRINT '';
PRINT 'Summary of Steps:';
PRINT '1. ✓ Generated exam with custom T/F and MCQ counts';
PRINT '2. ✓ Student answered all questions';
PRINT '3. ✓ Exam corrected automatically';
PRINT '4. ✓ Results analyzed and displayed';
PRINT '';
PRINT 'Key Features Demonstrated:';
PRINT '- Custom question type distribution';
PRINT '- Individual answer submission';
PRINT '- Automatic correction with detailed feedback';
PRINT '- Performance statistics by question type';
PRINT '========================================';