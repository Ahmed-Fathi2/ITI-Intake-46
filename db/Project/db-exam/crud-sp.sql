-- ========================================
-- STORED PROCEDURES - CORRECTED VERSION
-- For 9-Month Program (No Semesters)
-- ========================================

-- ===================================
-- 1. CRUD - STUDENTS
-- ===================================

CREATE OR ALTER PROCEDURE SP_InsertStudent
    @first_name NVARCHAR(100),
    @last_name NVARCHAR(100),
    @email VARCHAR(200),
    @phone VARCHAR(20),
    @department_id INT,
    @intake_id INT,
    @student_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Students (first_name, last_name, email, phone, department_id, intake_id)
        VALUES (@first_name, @last_name, @email, @phone, @department_id, @intake_id);
        
        SET @student_id = SCOPE_IDENTITY();
        SELECT @student_id AS NewStudentID, 'Student created successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_GetStudents
    @student_id INT = NULL,
    @department_id INT = NULL,
    @intake_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        s.student_id,
        s.first_name,
        s.last_name,
        s.email,
        s.phone,
        d.department_name,
        t.track_name,
        i.intake_name,
        b.branch_name,
        s.enrollment_date,
        s.status
    FROM Students s
    JOIN Departments d ON s.department_id = d.department_id
    JOIN Tracks t ON d.track_id = t.track_id
    JOIN Intakes i ON s.intake_id = i.intake_id
    JOIN Branches b ON i.branch_id = b.branch_id
    WHERE (@student_id IS NULL OR s.student_id = @student_id)
      AND (@department_id IS NULL OR s.department_id = @department_id)
      AND (@intake_id IS NULL OR s.intake_id = @intake_id);
END;
GO

CREATE OR ALTER PROCEDURE SP_UpdateStudent
    @student_id INT,
    @first_name NVARCHAR(100) = NULL,
    @last_name NVARCHAR(100) = NULL,
    @email VARCHAR(200) = NULL,
    @phone VARCHAR(20) = NULL,
    @status VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE Students
        SET 
            first_name = ISNULL(@first_name, first_name),
            last_name = ISNULL(@last_name, last_name),
            email = ISNULL(@email, email),
            phone = ISNULL(@phone, phone),
            status = ISNULL(@status, status)
        WHERE student_id = @student_id;
        
        IF @@ROWCOUNT > 0
            SELECT 'Student updated successfully' AS Message;
        ELSE
            SELECT 'Student not found' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_DeleteStudent
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM Students WHERE student_id = @student_id;
        
        IF @@ROWCOUNT > 0
            SELECT 'Student deleted successfully' AS Message;
        ELSE
            SELECT 'Student not found' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

-- ===================================
-- 2. CRUD - INSTRUCTORS
-- ===================================

CREATE OR ALTER PROCEDURE SP_InsertInstructor
    @first_name NVARCHAR(100),
    @last_name NVARCHAR(100),
    @email VARCHAR(200),
    @phone VARCHAR(20),
    @salary DECIMAL(10,2),
    @specialization NVARCHAR(200),
    @instructor_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Instructors (first_name, last_name, email, phone, salary, specialization)
        VALUES (@first_name, @last_name, @email, @phone, @salary, @specialization);
        
        SET @instructor_id = SCOPE_IDENTITY();
        SELECT @instructor_id AS NewInstructorID, 'Instructor created successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_GetInstructors
    @instructor_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Instructors
    WHERE (@instructor_id IS NULL OR instructor_id = @instructor_id);
END;
GO

CREATE OR ALTER PROCEDURE SP_UpdateInstructor
    @instructor_id INT,
    @first_name NVARCHAR(100) = NULL,
    @last_name NVARCHAR(100) = NULL,
    @email VARCHAR(200) = NULL,
    @phone VARCHAR(20) = NULL,
    @salary DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE Instructors
        SET 
            first_name = ISNULL(@first_name, first_name),
            last_name = ISNULL(@last_name, last_name),
            email = ISNULL(@email, email),
            phone = ISNULL(@phone, phone),
            salary = ISNULL(@salary, salary)
        WHERE instructor_id = @instructor_id;
        
        SELECT 'Instructor updated successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_DeleteInstructor
    @instructor_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM Instructors WHERE instructor_id = @instructor_id;
        SELECT 'Instructor deleted successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

-- ===================================
-- 3. CRUD - COURSES
-- ===================================

CREATE OR ALTER PROCEDURE SP_InsertCourse
    @course_name NVARCHAR(200),
    @course_code VARCHAR(20),
    @department_id INT,
    @credits INT,
    @max_degree INT,
    @description NVARCHAR(MAX) = NULL,
    @course_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Courses (course_name, course_code, department_id, credits, max_degree, description)
        VALUES (@course_name, @course_code, @department_id, @credits, @max_degree, @description);
        
        SET @course_id = SCOPE_IDENTITY();
        SELECT @course_id AS NewCourseID, 'Course created successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_GetCourses
    @course_id INT = NULL,
    @department_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        c.*,
        d.department_name,
        t.track_name
    FROM Courses c
    JOIN Departments d ON c.department_id = d.department_id
    JOIN Tracks t ON d.track_id = t.track_id
    WHERE (@course_id IS NULL OR c.course_id = @course_id)
      AND (@department_id IS NULL OR c.department_id = @department_id);
END;
GO

CREATE OR ALTER PROCEDURE SP_UpdateCourse
    @course_id INT,
    @course_name NVARCHAR(200) = NULL,
    @credits INT = NULL,
    @max_degree INT = NULL,
    @description NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE Courses
        SET 
            course_name = ISNULL(@course_name, course_name),
            credits = ISNULL(@credits, credits),
            max_degree = ISNULL(@max_degree, max_degree),
            description = ISNULL(@description, description)
        WHERE course_id = @course_id;
        
        SELECT 'Course updated successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_DeleteCourse
    @course_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM Courses WHERE course_id = @course_id;
        SELECT 'Course deleted successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

-- ===================================
-- 4. CRUD - QUESTIONS
-- ===================================

CREATE OR ALTER PROCEDURE SP_InsertQuestion
    @course_id INT,
    @question_text NVARCHAR(MAX),
    @question_type VARCHAR(20),
    @correct_answer VARCHAR(10),
    @points INT,
    @difficulty_level VARCHAR(20),
    @topic_id INT = NULL,
    @created_by INT = NULL,
    @question_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Questions (course_id, question_text, question_type, correct_answer, points, difficulty_level, topic_id, created_by)
        VALUES (@course_id, @question_text, @question_type, @correct_answer, @points, @difficulty_level, @topic_id, @created_by);
        
        SET @question_id = SCOPE_IDENTITY();
        SELECT @question_id AS NewQuestionID, 'Question created successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_GetQuestions
    @question_id INT = NULL,
    @course_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        q.*,
        c.course_name,
        ct.topic_name,
        i.first_name + ' ' + i.last_name AS created_by_name
    FROM Questions q
    JOIN Courses c ON q.course_id = c.course_id
    LEFT JOIN Course_Topics ct ON q.topic_id = ct.topic_id
    LEFT JOIN Instructors i ON q.created_by = i.instructor_id
    WHERE (@question_id IS NULL OR q.question_id = @question_id)
      AND (@course_id IS NULL OR q.course_id = @course_id);
END;
GO

CREATE OR ALTER PROCEDURE SP_UpdateQuestion
    @question_id INT,
    @question_text NVARCHAR(MAX) = NULL,
    @correct_answer VARCHAR(10) = NULL,
    @points INT = NULL,
    @difficulty_level VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE Questions
        SET 
            question_text = ISNULL(@question_text, question_text),
            correct_answer = ISNULL(@correct_answer, correct_answer),
            points = ISNULL(@points, points),
            difficulty_level = ISNULL(@difficulty_level, difficulty_level)
        WHERE question_id = @question_id;
        
        SELECT 'Question updated successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE SP_DeleteQuestion
    @question_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM Questions WHERE question_id = @question_id;
        SELECT 'Question deleted successfully' AS Message;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

-- ===================================
-- 5. EXAM GENERATION
-- ===================================

CREATE OR ALTER PROCEDURE SP_GenerateExam
    @student_id INT,
    @course_id INT,
    @exam_type VARCHAR(20),
    @num_easy INT = 5,
    @num_medium INT = 3,
    @num_hard INT = 2,
    @duration_minutes INT = 120,
    @exam_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if student is enrolled in this course
        IF NOT EXISTS (
            SELECT 1 FROM Student_Courses 
            WHERE student_id = @student_id 
              AND course_id = @course_id 
              AND status = 'active'
        )
        BEGIN
            RAISERROR('Student is not enrolled in this course', 16, 1);
            RETURN;
        END
        
        DECLARE @total_questions INT = @num_easy + @num_medium + @num_hard;
        DECLARE @total_points INT;
        
        -- Create exam
        INSERT INTO Exams (student_id, course_id, exam_type, exam_date, 
                          duration_minutes, total_questions, total_points, status)
        VALUES (@student_id, @course_id, @exam_type, GETDATE(), 
                @duration_minutes, @total_questions, 0, 'generated');
        
        SET @exam_id = SCOPE_IDENTITY();
        
        -- Select random questions (Easy)
        INSERT INTO Exam_Questions (exam_id, question_id, question_order, points)
        SELECT TOP (@num_easy)
            @exam_id,
            question_id,
            ROW_NUMBER() OVER (ORDER BY NEWID()),
            points
        FROM Questions
        WHERE course_id = @course_id 
          AND difficulty_level = 'easy'
        ORDER BY NEWID();
        
        -- Medium
        INSERT INTO Exam_Questions (exam_id, question_id, question_order, points)
        SELECT TOP (@num_medium)
            @exam_id,
            question_id,
            ROW_NUMBER() OVER (ORDER BY NEWID()) + @num_easy,
            points
        FROM Questions
        WHERE course_id = @course_id 
          AND difficulty_level = 'medium'
        ORDER BY NEWID();
        
        -- Hard
        INSERT INTO Exam_Questions (exam_id, question_id, question_order, points)
        SELECT TOP (@num_hard)
            @exam_id,
            question_id,
            ROW_NUMBER() OVER (ORDER BY NEWID()) + @num_easy + @num_medium,
            points
        FROM Questions
        WHERE course_id = @course_id 
          AND difficulty_level = 'hard'
        ORDER BY NEWID();
        
        -- Calculate total points
        SELECT @total_points = SUM(points) FROM Exam_Questions WHERE exam_id = @exam_id;
        UPDATE Exams SET total_points = @total_points WHERE exam_id = @exam_id;
        
        COMMIT TRANSACTION;
        
        SELECT @exam_id AS ExamID, @total_questions AS TotalQuestions, 
               @total_points AS TotalPoints, 'Exam generated successfully' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

-- ===================================
-- 6. SUBMIT EXAM ANSWERS
-- ===================================

CREATE OR ALTER PROCEDURE SP_SubmitExamAnswers
    @exam_id INT,
    @answers NVARCHAR(MAX) -- JSON: [{"question_id":1,"answer":"A"},...]
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM Exams WHERE exam_id = @exam_id AND status IN ('generated', 'in_progress'))
        BEGIN
            RAISERROR('Exam is not available for submission', 16, 1);
            RETURN;
        END
        
        -- Parse JSON and insert answers
        INSERT INTO Student_Answers (exam_id, question_id, student_answer)
        SELECT 
            @exam_id,
            JSON_VALUE(value, '$.question_id'),
            JSON_VALUE(value, '$.answer')
        FROM OPENJSON(@answers);
        
        UPDATE Exams 
        SET status = 'submitted', 
            submitted_date = GETDATE()
        WHERE exam_id = @exam_id;
        
        COMMIT TRANSACTION;
        SELECT 'Answers submitted successfully' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

-- ===================================
-- 7. EXAM CORRECTION
-- ===================================

CREATE OR ALTER PROCEDURE SP_CorrectExam
    @exam_id INT,
    @corrected_by INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM Exams WHERE exam_id = @exam_id AND status = 'submitted')
        BEGIN
            RAISERROR('Exam is not submitted yet', 16, 1);
            RETURN;
        END
        
        -- Auto-correct
        UPDATE sa
        SET 
            sa.is_correct = CASE 
                WHEN sa.student_answer = q.correct_answer THEN 1 
                ELSE 0 
            END,
            sa.points_earned = CASE 
                WHEN sa.student_answer = q.correct_answer THEN eq.points 
                ELSE 0 
            END
        FROM Student_Answers sa
        JOIN Questions q ON sa.question_id = q.question_id
        JOIN Exam_Questions eq ON sa.exam_id = eq.exam_id AND sa.question_id = eq.question_id
        WHERE sa.exam_id = @exam_id;
        
        DECLARE @score DECIMAL(5,2), @total_points INT, @percentage DECIMAL(5,2);
        
        SELECT @score = SUM(points_earned)
        FROM Student_Answers
        WHERE exam_id = @exam_id;
        
        SELECT @total_points = total_points
        FROM Exams
        WHERE exam_id = @exam_id;
        
        SET @percentage = (@score * 100.0) / @total_points;
        
        UPDATE Exams
        SET 
            score = @score,
            percentage = @percentage,
            status = 'corrected',
            corrected_date = GETDATE(),
            corrected_by = @corrected_by
        WHERE exam_id = @exam_id;
        
        COMMIT TRANSACTION;
        
        SELECT @score AS Score, @total_points AS TotalPoints, 
               @percentage AS Percentage, 'Exam corrected successfully' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO

PRINT '✅ All Stored Procedures Created Successfully';
GO