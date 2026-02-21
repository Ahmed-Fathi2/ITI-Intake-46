-- ========================================
-- REPORTS - CORRECTED VERSION
-- For 9-Month Program (No Semesters)
-- ========================================

-- ===================================
-- REPORT 1: Students by Department
-- ===================================
CREATE OR ALTER PROCEDURE RPT_StudentsByDepartment
    @department_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        s.student_id AS 'Student ID',
        s.first_name + ' ' + s.last_name AS 'Student Name',
        s.email AS 'Email',
        s.phone AS 'Phone',
        b.branch_name AS 'Branch',
        d.department_name AS 'Department',
        t.track_name AS 'Track',
        i.intake_name AS 'Intake',
        s.enrollment_date AS 'Enrollment Date',
        s.status AS 'Status',
        COUNT(DISTINCT sc.course_id) AS 'Total Courses Enrolled',
        AVG(sc.final_grade) AS 'Average Grade'
    FROM Students s
    JOIN Departments d ON s.department_id = d.department_id
    JOIN Tracks t ON d.track_id = t.track_id
    JOIN Intakes i ON s.intake_id = i.intake_id
    JOIN Branches b ON i.branch_id = b.branch_id
    LEFT JOIN Student_Courses sc ON s.student_id = sc.student_id AND sc.status = 'completed'
    WHERE s.department_id = @department_id
    GROUP BY 
        s.student_id, s.first_name, s.last_name, s.email, s.phone,
        b.branch_name, d.department_name, t.track_name, 
        i.intake_name, s.enrollment_date, s.status
    ORDER BY s.student_id;
END;
GO


RPT_StudentsByDepartment 9
-- ===================================
-- REPORT 2: Student Grades (All Courses)
-- With Percentage for each course
-- ===================================
CREATE OR ALTER PROCEDURE RPT_StudentGradesAllCourses
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Student Info
    SELECT 
        s.student_id AS 'Student ID',
        s.first_name + ' ' + s.last_name AS 'Student Name',
        d.department_name AS 'Department',
        t.track_name AS 'Track',
        b.branch_name AS 'Branch',
        i.intake_name AS 'Intake'
    FROM Students s
    JOIN Departments d ON s.department_id = d.department_id
    JOIN Tracks t ON d.track_id = t.track_id
    JOIN Intakes i ON s.intake_id = i.intake_id
    JOIN Branches b ON i.branch_id = b.branch_id
    WHERE s.student_id = @student_id;
    
    -- Courses and Grades with Percentage
    SELECT 
        c.course_code AS 'Course Code',
        c.course_name AS 'Course Name',
        inst.first_name + ' ' + inst.last_name AS 'Instructor',
        c.max_degree AS 'Max Degree',
        sc.final_grade AS 'Final Grade',
        CAST((sc.final_grade * 100.0 / c.max_degree) AS DECIMAL(5,2)) AS 'Percentage %',
        sc.grade_letter AS 'Grade',
        sc.status AS 'Status',
        CASE 
            WHEN sc.final_grade >= c.min_degree THEN 'Pass'
            WHEN sc.final_grade < c.min_degree THEN 'Fail'
            ELSE 'Pending'
        END AS 'Result'
    FROM Student_Courses sc
    JOIN Courses c ON sc.course_id = c.course_id
    LEFT JOIN Instructors inst ON sc.instructor_id = inst.instructor_id
    WHERE sc.student_id = @student_id
    ORDER BY c.course_name;
    
    -- Summary
    SELECT 
        COUNT(*) AS 'Total Courses',
        SUM(CASE WHEN sc.status = 'completed' THEN 1 ELSE 0 END) AS 'Completed',
        SUM(CASE WHEN sc.status = 'active' THEN 1 ELSE 0 END) AS 'In Progress',
        AVG(CASE WHEN sc.final_grade IS NOT NULL THEN 
            (sc.final_grade * 100.0 / c.max_degree) 
            ELSE NULL END) AS 'Overall GPA %',
        SUM(CASE WHEN sc.final_grade >= c.min_degree THEN 1 ELSE 0 END) AS 'Passed',
        SUM(CASE WHEN sc.final_grade < c.min_degree THEN 1 ELSE 0 END) AS 'Failed'
    FROM Student_Courses sc
    JOIN Courses c ON sc.course_id = c.course_id
    WHERE sc.student_id = @student_id;
END;
GO

-- ===================================
-- REPORT 3: Instructor Courses & Student Count
-- ===================================
CREATE OR ALTER PROCEDURE RPT_InstructorCoursesAndStudents
    @instructor_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Instructor Info
    SELECT 
        i.instructor_id AS 'Instructor ID',
        i.first_name + ' ' + i.last_name AS 'Instructor Name',
        i.email AS 'Email',
        i.specialization AS 'Specialization'
    FROM Instructors i
    WHERE i.instructor_id = @instructor_id;
    
    -- Courses and Student Count
    SELECT 
        c.course_code AS 'Course Code',
        c.course_name AS 'Course Name',
        d.department_name AS 'Department',
        t.track_name AS 'Track',
        intake.intake_name AS 'Intake',
        b.branch_name AS 'Branch',
        COUNT(DISTINCT sc.student_id) AS 'Number of Students',
        ica.start_date AS 'Teaching Start Date',
        c.credits AS 'Credits'
    FROM Instructor_Course_Assignments ica
    JOIN Courses c ON ica.course_id = c.course_id
    JOIN Departments d ON c.department_id = d.department_id
    JOIN Tracks t ON d.track_id = t.track_id
    JOIN Intakes intake ON ica.intake_id = intake.intake_id
    JOIN Branches b ON intake.branch_id = b.branch_id
    LEFT JOIN Student_Courses sc ON c.course_id = sc.course_id 
        AND sc.instructor_id = @instructor_id
        AND sc.status IN ('active', 'completed')
    WHERE ica.instructor_id = @instructor_id
    GROUP BY 
        c.course_code, c.course_name, d.department_name, t.track_name,
        intake.intake_name, b.branch_name, ica.start_date, c.credits
    ORDER BY intake.intake_name DESC, c.course_name;
    
    -- Summary
    SELECT 
        COUNT(DISTINCT ica.course_id) AS 'Total Courses Teaching',
        COUNT(DISTINCT intake.branch_id) AS 'Branches',
        SUM(student_count.cnt) AS 'Total Students Across All Courses'
    FROM Instructor_Course_Assignments ica
    JOIN Intakes intake ON ica.intake_id = intake.intake_id
    LEFT JOIN (
        SELECT course_id, instructor_id, COUNT(*) as cnt
        FROM Student_Courses
        WHERE status IN ('active', 'completed')
        GROUP BY course_id, instructor_id
    ) student_count ON ica.course_id = student_count.course_id 
        AND ica.instructor_id = student_count.instructor_id
    WHERE ica.instructor_id = @instructor_id;
END;
GO

-- ===================================
-- REPORT 4: Course Topics
-- ===================================
CREATE OR ALTER PROCEDURE RPT_CourseTopics
    @course_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Course Info
    SELECT 
        c.course_id AS 'Course ID',
        c.course_code AS 'Course Code',
        c.course_name AS 'Course Name',
        d.department_name AS 'Department',
        t.track_name AS 'Track',
        c.credits AS 'Credits',
        c.description AS 'Description'
    FROM Courses c
    JOIN Departments d ON c.department_id = d.department_id
    JOIN Tracks t ON d.track_id = t.track_id
    WHERE c.course_id = @course_id;
    
    -- Topics
    SELECT 
        ct.topic_order AS 'Order',
        ct.topic_name AS 'Topic Name',
        ct.description AS 'Description',
        COUNT(q.question_id) AS 'Questions Count',
        ct.created_date AS 'Created Date'
    FROM Course_Topics ct
    LEFT JOIN Questions q ON ct.topic_id = q.topic_id
    WHERE ct.course_id = @course_id
    GROUP BY ct.topic_order, ct.topic_name, ct.description, ct.created_date
    ORDER BY ct.topic_order;
    
    -- Summary
    SELECT 
        COUNT(*) AS 'Total Topics',
        SUM(CASE WHEN q.question_id IS NOT NULL THEN 1 ELSE 0 END) AS 'Topics with Questions'
    FROM Course_Topics ct
    LEFT JOIN Questions q ON ct.topic_id = q.topic_id
    WHERE ct.course_id = @course_id;
END;
GO

-- ===================================
-- REPORT 5: Exam Questions with Choices
-- ===================================
CREATE OR ALTER PROCEDURE RPT_ExamQuestionsWithChoices
    @exam_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Exam Header
    SELECT 
        e.exam_id AS 'Exam ID',
        s.first_name + ' ' + s.last_name AS 'Student Name',
        c.course_code AS 'Course Code',
        c.course_name AS 'Course Name',
        e.exam_type AS 'Exam Type',
        e.exam_date AS 'Exam Date',
        e.duration_minutes AS 'Duration (Minutes)',
        e.total_questions AS 'Total Questions',
        e.total_points AS 'Total Points',
        e.status AS 'Status'
    FROM Exams e
    JOIN Students s ON e.student_id = s.student_id
    JOIN Courses c ON e.course_id = c.course_id
    WHERE e.exam_id = @exam_id;
    
    -- Questions (Freeform - All info in one row)
    SELECT 
        eq.question_order AS 'Q#',
        q.question_text AS 'Question',
        q.question_type AS 'Type',
        eq.points AS 'Points',
        q.difficulty_level AS 'Difficulty',
        
        -- All choices in one column
        CASE 
            WHEN q.question_type = 'mcq' THEN
                STUFF((
                    SELECT CHAR(13) + CHAR(10) + qo.option_letter + ') ' + qo.option_text
                    FROM Question_Options qo
                    WHERE qo.question_id = q.question_id
                    ORDER BY qo.option_letter
                    FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)'), 1, 2, '')
            WHEN q.question_type = 'true_false' THEN 'A) True' + CHAR(13) + CHAR(10) + 'B) False'
            ELSE ''
        END AS 'Choices',
        
        ct.topic_name AS 'Topic'
    FROM Exam_Questions eq
    JOIN Questions q ON eq.question_id = q.question_id
    LEFT JOIN Course_Topics ct ON q.topic_id = ct.topic_id
    WHERE eq.exam_id = @exam_id
    ORDER BY eq.question_order;
    
    -- Alternative: Separate rows per option
    SELECT 
        eq.question_order AS 'Q#',
        q.question_text AS 'Question',
        qo.option_letter AS 'Option',
        qo.option_text AS 'Option Text',
        eq.points AS 'Points'
    FROM Exam_Questions eq
    JOIN Questions q ON eq.question_id = q.question_id
    LEFT JOIN Question_Options qo ON q.question_id = qo.question_id
    WHERE eq.exam_id = @exam_id
      AND q.question_type = 'mcq'
    ORDER BY eq.question_order, qo.option_letter;
END;
GO

-- ===================================
-- REPORT 6: Exam with Student Answers
-- ===================================
CREATE OR ALTER PROCEDURE RPT_ExamWithStudentAnswers
    @exam_id INT,
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Verify exam belongs to student
    IF NOT EXISTS (
        SELECT 1 FROM Exams 
        WHERE exam_id = @exam_id AND student_id = @student_id
    )
    BEGIN
        SELECT 'Error: Exam does not belong to this student' AS Message;
        RETURN;
    END
    
    -- Exam Header with Results
    SELECT 
        e.exam_id AS 'Exam ID',
        s.first_name + ' ' + s.last_name AS 'Student Name',
        s.student_id AS 'Student ID',
        c.course_code AS 'Course Code',
        c.course_name AS 'Course Name',
        e.exam_type AS 'Exam Type',
        e.exam_date AS 'Exam Date',
        e.submitted_date AS 'Submitted Date',
        e.duration_minutes AS 'Duration (Minutes)',
        e.total_questions AS 'Total Questions',
        e.total_points AS 'Total Points',
        e.score AS 'Score Earned',
        e.percentage AS 'Percentage %',
        e.status AS 'Status',
        CASE 
            WHEN e.percentage >= 50 THEN 'PASS'
            WHEN e.percentage < 50 THEN 'FAIL'
            ELSE 'Pending'
        END AS 'Result'
    FROM Exams e
    JOIN Students s ON e.student_id = s.student_id
    JOIN Courses c ON e.course_id = c.course_id
    WHERE e.exam_id = @exam_id;
    
    -- Questions with Student Answers
    SELECT 
        eq.question_order AS 'Q#',
        q.question_text AS 'Question',
        q.question_type AS 'Type',
        
        -- Choices
        CASE 
            WHEN q.question_type = 'mcq' THEN
                STUFF((
                    SELECT CHAR(13) + CHAR(10) + qo.option_letter + ') ' + qo.option_text
                    FROM Question_Options qo
                    WHERE qo.question_id = q.question_id
                    ORDER BY qo.option_letter
                    FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)'), 1, 2, '')
            WHEN q.question_type = 'true_false' THEN 'A) True' + CHAR(13) + CHAR(10) + 'B) False'
            ELSE ''
        END AS 'Choices',
        
        sa.student_answer AS 'Student Answer',
        q.correct_answer AS 'Correct Answer',
        
        CASE 
            WHEN sa.is_correct = 1 THEN '✓ Correct'
            WHEN sa.is_correct = 0 THEN '✗ Wrong'
            ELSE 'Not Answered'
        END AS 'Result',
        
        sa.points_earned AS 'Points Earned',
        eq.points AS 'Max Points',
        q.difficulty_level AS 'Difficulty',
        ct.topic_name AS 'Topic'
    FROM Exam_Questions eq
    JOIN Questions q ON eq.question_id = q.question_id
    LEFT JOIN Student_Answers sa ON eq.exam_id = sa.exam_id 
        AND eq.question_id = sa.question_id
    LEFT JOIN Course_Topics ct ON q.topic_id = ct.topic_id
    WHERE eq.exam_id = @exam_id
    ORDER BY eq.question_order;
    
    -- Performance Analysis by Difficulty
    SELECT 
        q.difficulty_level AS 'Difficulty Level',
        COUNT(*) AS 'Total Questions',
        SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) AS 'Correct Answers',
        SUM(CASE WHEN sa.is_correct = 0 THEN 1 ELSE 0 END) AS 'Wrong Answers',
        SUM(CASE WHEN sa.student_answer IS NULL THEN 1 ELSE 0 END) AS 'Not Answered',
        CAST(AVG(CAST(sa.is_correct AS FLOAT)) * 100 AS DECIMAL(5,2)) AS 'Accuracy %'
    FROM Exam_Questions eq
    JOIN Questions q ON eq.question_id = q.question_id
    LEFT JOIN Student_Answers sa ON eq.exam_id = sa.exam_id 
        AND eq.question_id = sa.question_id
    WHERE eq.exam_id = @exam_id
    GROUP BY q.difficulty_level
    ORDER BY 
        CASE q.difficulty_level 
            WHEN 'easy' THEN 1 
            WHEN 'medium' THEN 2 
            WHEN 'hard' THEN 3 
        END;
END;
GO

-- ===================================
-- BONUS: Student Performance Summary
-- ===================================
CREATE OR ALTER PROCEDURE RPT_StudentPerformanceSummary
    @student_id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        c.course_name AS 'Course',
        COUNT(e.exam_id) AS 'Exams Taken',
        AVG(e.percentage) AS 'Average Score %',
        MAX(e.percentage) AS 'Best Score %',
        MIN(e.percentage) AS 'Lowest Score %',
        SUM(CASE WHEN e.percentage >= 50 THEN 1 ELSE 0 END) AS 'Passed',
        SUM(CASE WHEN e.percentage < 50 THEN 1 ELSE 0 END) AS 'Failed'
    FROM Exams e
    JOIN Courses c ON e.course_id = c.course_id
    WHERE e.student_id = @student_id
      AND e.status = 'corrected'
    GROUP BY c.course_name
    ORDER BY c.course_name;
END;
GO

PRINT '✅ All Reports Created Successfully';
GO