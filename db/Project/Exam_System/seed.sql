-- ========================================
-- COMPLETE SYSTEM FLOW
-- من البداية للنهاية - كل الجداول
-- ========================================

-- ========================================
-- PHASE 1: إعداد المعهد والبنية التحتية
-- ========================================

PRINT '========================================';
PRINT 'PHASE 1: Setting Up Institute Structure';
PRINT '========================================';
GO

-- 1.1 إنشاء المعهد الرئيسي
--INSERT INTO Institutes (institute_name, address, phone)
--VALUES ('ITI - Information Technology Institute', 'Nasr City, Cairo, Egypt', '+20-2-22617100');
--PRINT '✓ Institute created: ITI';

-- 1.2 إنشاء الفروع
INSERT INTO Branches (branch_name, location, phone)
VALUES 
    ('Smart Village Branch', '6th of October City, Giza', '+20-2-35351000'),
    ('Assiut Branch', 'Assiut, Upper Egypt', '+20-88-2411122'),
    ('Mansoura Branch', 'Mansoura, Delta', '+20-50-2264400'),
    ('Alex Branch', 'Alexandria', '+20-3-5821555');
PRINT '✓ 4 Branches created';

-- 1.3 إنشاء التراكات (التخصصات)
INSERT INTO Tracks (track_name, description)
VALUES 
    ('Web Development', 'Full-stack web development using modern technologies'),
    ('Mobile Development', 'iOS and Android native and cross-platform development'),
    ('Data Science & AI', 'Machine learning, AI, and data analysis'),
    ('Digital Marketing', 'SEO, Social Media, and Content Marketing'),
    ('UI/UX Design', 'User interface and user experience design');
PRINT '✓ 5 Tracks created';

-- 1.4 ربط الفروع بالتراكات (أي فرع يقدم أي تراك)
INSERT INTO Branch_Tracks (branch_id, track_id)
VALUES 
    -- Smart Village: كل التراكات
    (1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
    -- Assiut: Web + Mobile + Digital Marketing
    (2, 1), (2, 2), (2, 4),
    -- Mansoura: Web + Data Science
    (3, 1), (3, 3),
    -- Alex: Web + UI/UX
    (4, 1), (4, 5);
PRINT '✓ Branch-Track relationships created';

-- 1.5 إنشاء الأقسام داخل كل تراك
INSERT INTO Departments (track_id, department_name, description)
VALUES 
    -- Web Development Departments
    (1, 'Frontend Development', 'HTML, CSS, JavaScript, React, Vue'),
    (1, 'Backend Development', 'Node.js, PHP, Python, Databases'),
    (1, 'DevOps', 'CI/CD, Docker, Kubernetes, Cloud'),
    -- Mobile Development Departments
    (2, 'Android Development', 'Kotlin, Java, Android SDK'),
    (2, 'iOS Development', 'Swift, SwiftUI, iOS SDK'),
    (2, 'Cross-Platform', 'React Native, Flutter'),
    -- Data Science Departments
    (3, 'Machine Learning', 'ML algorithms and models'),
    (3, 'Deep Learning', 'Neural networks and AI'),
    (3, 'Data Analysis', 'Statistics and visualization'),
    -- Digital Marketing Departments
    (4, 'SEO & SEM', 'Search engine optimization'),
    (4, 'Social Media', 'Facebook, Instagram, LinkedIn'),
    -- UI/UX Departments
    (5, 'UI Design', 'Visual design and prototyping'),
    (5, 'UX Research', 'User research and testing');
PRINT '✓ 13 Departments created';
GO

-- ========================================
-- PHASE 2: إضافة المدرسين
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 2: Adding Instructors';
PRINT '========================================';
GO

INSERT INTO Instructors (first_name, last_name, email, phone, salary)
VALUES 
    ('Ahmed', 'Hassan', 'ahmed.hassan@iti.gov.eg', '+20-100-1234567', 8000.00),
    ('Sara', 'Mohamed', 'sara.mohamed@iti.gov.eg', '+20-100-2345678', 7500.00),
    ('Khaled', 'Ali', 'khaled.ali@iti.gov.eg', '+20-100-3456789', 9000.00),
    ('Nour', 'Khaled', 'nour.khaled@iti.gov.eg', '+20-100-4567890', 7000.00),
    ('Omar', 'Youssef', 'omar.youssef@iti.gov.eg', '+20-100-5678901', 8500.00),
    ('Mona', 'Samy', 'mona.samy@iti.gov.eg', '+20-100-6789012', 7200.00);
PRINT '✓ 6 Instructors added';
GO

-- ========================================
-- PHASE 3: إنشاء الكورسات
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 3: Creating Courses';
PRINT '========================================';
GO

INSERT INTO Courses (course_name, department_id, instructor_id, credits, description)
VALUES 
    -- Backend Development Courses
    ('Database Systems', 2, 1, 4, 'SQL Server, MySQL, Database Design'),
    ('SQL Advanced', 2, 1, 3, 'Advanced queries, optimization, indexing'),
    ('Node.js Backend', 2, 3, 4, 'Express, REST APIs, Authentication'),
    -- Frontend Development Courses
    ('HTML & CSS', 1, 2, 3, 'Responsive design, Flexbox, Grid'),
    ('JavaScript Fundamentals', 1, 2, 4, 'ES6+, DOM manipulation, Async'),
    ('React Framework', 1, 5, 4, 'Components, Hooks, State Management'),
    -- Mobile Development Courses
    ('Android Development', 4, 4, 5, 'Kotlin, Android Studio, Material Design'),
    ('iOS Development', 5, 6, 5, 'Swift, Xcode, UIKit'),
    -- Data Science Courses
    ('Python for Data Science', 9, 3, 4, 'NumPy, Pandas, Matplotlib'),
    ('Machine Learning', 7, 5, 5, 'Scikit-learn, ML algorithms');
PRINT '✓ 10 Courses created';
GO

-- ========================================
-- PHASE 4: تسجيل الطلاب
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 4: Student Registration';
PRINT '========================================';
GO

INSERT INTO Students (first_name, last_name, email, phone, branch_id, track_id)
VALUES 
    -- Web Development Students
    ('Mohamed', 'Ali', 'mohamed.ali@student.iti.gov.eg', '+20-101-1111111', 1, 1),
    ('Fatma', 'Ahmed', 'fatma.ahmed@student.iti.gov.eg', '+20-101-2222222', 1, 1),
    ('Hassan', 'Ibrahim', 'hassan.ibrahim@student.iti.gov.eg', '+20-101-3333333', 2, 1),
    -- Mobile Development Students
    ('Laila', 'Mahmoud', 'laila.mahmoud@student.iti.gov.eg', '+20-101-4444444', 1, 2),
    ('Youssef', 'Khaled', 'youssef.khaled@student.iti.gov.eg', '+20-101-5555555', 1, 2),
    -- Data Science Students
    ('Nada', 'Samy', 'nada.samy@student.iti.gov.eg', '+20-101-6666666', 3, 3),
    ('Karim', 'Hany', 'karim.hany@student.iti.gov.eg', '+20-101-7777777', 1, 3),
    -- UI/UX Students
    ('Mariam', 'Osama', 'mariam.osama@student.iti.gov.eg', '+20-101-8888888', 4, 5),
    -- More Web Dev Students
    ('Amr', 'Tarek', 'amr.tarek@student.iti.gov.eg', '+20-101-9999999', 1, 1),
    ('Dina', 'Farid', 'dina.farid@student.iti.gov.eg', '+20-101-0000000', 2, 1);
PRINT '✓ 10 Students registered';
GO

-- ========================================
-- PHASE 5: تسجيل الطلاب في الكورسات
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 5: Student Course Enrollment';
PRINT '========================================';
GO

INSERT INTO Student_Courses (student_id, course_id, status)
VALUES 
    -- Student 1: Mohamed Ali (Web Dev) - 4 courses
    (1, 1, 'active'), -- Database Systems
    (1, 2, 'active'), -- SQL Advanced
    (1, 5, 'active'), -- JavaScript
    (1, 6, 'active'), -- React
    
    -- Student 2: Fatma Ahmed (Web Dev) - 3 courses
    (2, 1, 'active'), -- Database Systems
    (2, 4, 'active'), -- HTML & CSS
    (2, 5, 'active'), -- JavaScript
    
    -- Student 3: Hassan Ibrahim (Web Dev) - 2 courses
    (3, 1, 'active'), -- Database Systems
    (3, 3, 'active'), -- Node.js
    
    -- Student 4: Laila Mahmoud (Mobile) - 2 courses
    (4, 7, 'active'), -- Android
    (4, 1, 'active'), -- Database (general course)
    
    -- Student 5: Youssef Khaled (Mobile) - 2 courses
    (5, 8, 'active'), -- iOS
    (5, 1, 'active'), -- Database
    
    -- Student 6: Nada Samy (Data Science) - 2 courses
    (6, 9, 'active'), -- Python for DS
    (6, 10, 'active'), -- Machine Learning
    
    -- Student 7: Karim Hany (Data Science) - 2 courses
    (7, 9, 'active'), -- Python for DS
    (7, 1, 'active'), -- Database
    
    -- Student 9: Amr Tarek (Web Dev) - 3 courses
    (9, 1, 'active'), -- Database
    (9, 2, 'active'), -- SQL Advanced
    (9, 5, 'active'), -- JavaScript
    
    -- Student 10: Dina Farid (Web Dev) - 2 courses
    (10, 1, 'active'), -- Database
    (10, 4, 'active'); -- HTML & CSS
PRINT '✓ Students enrolled in courses';
GO

-- ========================================
-- PHASE 6: إضافة الأسئلة لكورس Database Systems
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 6: Adding Questions to Database Systems Course';
PRINT '========================================';
GO

-- True/False Questions
INSERT INTO Questions (course_id, question_text, question_type, correct_answer, points, difficulty_level)
VALUES 
    (1, 'SQL stands for Structured Query Language', 'true_false', 'True', 1, 'easy'),
    (1, 'A Primary Key can contain NULL values', 'true_false', 'False', 1, 'easy'),
    (1, 'Foreign Keys maintain referential integrity between tables', 'true_false', 'True', 1, 'medium'),
    (1, 'TRUNCATE command can be rolled back in a transaction', 'true_false', 'False', 1, 'medium'),
    (1, 'Indexes improve query performance', 'true_false', 'True', 1, 'easy'),
    (1, 'A table can have multiple Primary Keys', 'true_false', 'False', 1, 'easy'),
    (1, 'CASCADE DELETE removes related records automatically', 'true_false', 'True', 1, 'medium'),
    (1, 'VARCHAR and CHAR store data in the same way', 'true_false', 'False', 1, 'medium'),
    (1, 'A view is a virtual table', 'true_false', 'True', 1, 'easy'),
    (1, 'Stored Procedures can return multiple result sets', 'true_false', 'True', 1, 'hard');
PRINT '✓ 10 True/False questions added';

-- Multiple Choice Questions
INSERT INTO Questions (course_id, question_text, question_type, correct_answer, points, difficulty_level)
VALUES 
    (1, 'What does RDBMS stand for?', 'multiple_choice', '2', 2, 'easy'),
    (1, 'Which SQL command is used to retrieve data?', 'multiple_choice', '3', 2, 'easy'),
    (1, 'Which constraint ensures unique values in a column?', 'multiple_choice', '1', 2, 'easy'),
    (1, 'What is the correct syntax for creating a table?', 'multiple_choice', '2', 2, 'medium'),
    (1, 'Which JOIN returns all rows from both tables?', 'multiple_choice', '4', 2, 'medium'),
    (1, 'What is Normalization?', 'multiple_choice', '3', 2, 'medium'),
    (1, 'Which clause is used for filtering groups?', 'multiple_choice', '2', 2, 'hard'),
    (1, 'What is the purpose of an Index?', 'multiple_choice', '1', 2, 'medium'),
    (1, 'Which isolation level prevents dirty reads?', 'multiple_choice', '3', 2, 'hard'),
    (1, 'What does ACID stand for in databases?', 'multiple_choice', '4', 2, 'hard');
PRINT '✓ 10 Multiple Choice questions added';
GO

-- Adding Options for Multiple Choice Questions (Questions 11-20)
INSERT INTO Question_Options (question_id, option_number, option_text)
VALUES 
    -- Question 11: RDBMS
    (11, 1, 'Relational Data Management System'),
    (11, 2, 'Relational Database Management System'),
    (11, 3, 'Remote Database Management System'),
    (11, 4, 'Real Database Management System'),
    
    -- Question 12: Retrieve data
    (12, 1, 'INSERT'),
    (12, 2, 'UPDATE'),
    (12, 3, 'SELECT'),
    (12, 4, 'DELETE'),
    
    -- Question 13: Unique constraint
    (13, 1, 'UNIQUE'),
    (13, 2, 'CHECK'),
    (13, 3, 'DEFAULT'),
    (13, 4, 'NOT NULL'),
    
    -- Question 14: Create table syntax
    (14, 1, 'MAKE TABLE table_name'),
    (14, 2, 'CREATE TABLE table_name (columns)'),
    (14, 3, 'NEW TABLE table_name'),
    (14, 4, 'BUILD TABLE table_name'),
    
    -- Question 15: JOIN types
    (15, 1, 'INNER JOIN'),
    (15, 2, 'LEFT JOIN'),
    (15, 3, 'RIGHT JOIN'),
    (15, 4, 'FULL OUTER JOIN'),
    
    -- Question 16: Normalization
    (16, 1, 'Adding more tables to database'),
    (16, 2, 'Removing all relationships'),
    (16, 3, 'Organizing data to reduce redundancy'),
    (16, 4, 'Creating backup copies'),
    
    -- Question 17: HAVING clause
    (17, 1, 'WHERE'),
    (17, 2, 'HAVING'),
    (17, 3, 'GROUP BY'),
    (17, 4, 'ORDER BY'),
    
    -- Question 18: Index purpose
    (18, 1, 'Speed up data retrieval'),
    (18, 2, 'Store more data'),
    (18, 3, 'Create relationships'),
    (18, 4, 'Delete records faster'),
    
    -- Question 19: Isolation level
    (19, 1, 'READ UNCOMMITTED'),
    (19, 2, 'REPEATABLE READ'),
    (19, 3, 'READ COMMITTED'),
    (19, 4, 'SERIALIZABLE'),
    
    -- Question 20: ACID
    (20, 1, 'Advanced Computer Integration Design'),
    (20, 2, 'Automatic Consistent Isolation Database'),
    (20, 3, 'Applied Core Integration Development'),
    (20, 4, 'Atomicity Consistency Isolation Durability');
PRINT '✓ Options added for all MCQ questions';
GO

-- ========================================
-- PHASE 7: توليد الامتحان للطالب
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 7: EXAM GENERATION';
PRINT '========================================';
PRINT 'Student: Mohamed Ali (ID: 1)';
PRINT 'Course: Database Systems';
PRINT '========================================';
GO

-- توليد امتحان بـ 10 أسئلة عشوائية
EXEC SP_GenerateExam 
    @StudentID = 1,
    @CourseName = 'Database Systems',
    @NumberOfQuestions = 10;
GO

-- ========================================
-- PHASE 8: الطالب يجاوب على الأسئلة
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 8: STUDENT ANSWERING QUESTIONS';
PRINT '========================================';
PRINT 'Mohamed Ali is taking the exam...';
PRINT '========================================';
GO

-- ملاحظة: الأسئلة المولدة عشوائية، لكن هنفترض أرقام معينة للمثال
-- في الواقع، لازم تشوف الأسئلة اللي طلعت من SP_GenerateExam الأول

-- إجابات افتراضية (هتتغير حسب الأسئلة المولدة)
-- True/False answers
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 1, @StudentAnswer = 'True';   -- Correct
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 2, @StudentAnswer = 'False';  -- Correct
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 3, @StudentAnswer = 'True';   -- Correct
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 5, @StudentAnswer = 'False';  -- Wrong (correct is True)
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 9, @StudentAnswer = 'True';   -- Correct

-- MCQ answers
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 11, @StudentAnswer = '2';     -- Correct
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 12, @StudentAnswer = '3';     -- Correct
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 13, @StudentAnswer = '2';     -- Wrong (correct is 1)
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 15, @StudentAnswer = '4';     -- Correct
EXEC SP_SubmitExamAnswers @ExamID = 1, @QuestionID = 16, @StudentAnswer = '3';     -- Correct

PRINT '';
PRINT '✓ All 10 questions answered';
GO

-- ========================================
-- PHASE 9: تصحيح الامتحان
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 9: EXAM CORRECTION';
PRINT '========================================';
GO

EXEC SP_CorrectExam @ExamID = 1;
GO

-- ========================================
-- PHASE 10: استعلامات تحليلية
-- ========================================

PRINT '';
PRINT '========================================';
PRINT 'PHASE 10: ANALYTICS & REPORTS';
PRINT '========================================';
GO

-- 10.1 عرض كل الطلاب المسجلين في Database Systems
PRINT '--- Students Enrolled in Database Systems ---';
SELECT 
    s.student_id,
    s.first_name + ' ' + s.last_name AS StudentName,
    s.email,
    b.branch_name AS Branch,
    t.track_name AS Track,
    sc.enrollment_date
FROM Students s
INNER JOIN Student_Courses sc ON s.student_id = sc.student_id
INNER JOIN Courses c ON sc.course_id = c.course_id
INNER JOIN Branches b ON s.branch_id = b.branch_id
INNER JOIN Tracks t ON s.track_id = t.track_id
WHERE c.course_name = 'Database Systems'
ORDER BY s.student_id;
GO

-- 10.2 عرض جميع الامتحانات مع النتائج
PRINT '';
PRINT '--- All Exam Results ---';
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
    se.status
FROM Student_Exams se
INNER JOIN Students s ON se.student_id = s.student_id
INNER JOIN Courses c ON se.course_id = c.course_id
WHERE se.status = 'corrected'
ORDER BY se.exam_date DESC;
GO

-- 10.3 إحصائيات الأسئلة (أصعب وأسهل الأسئلة)
PRINT '';
PRINT '--- Question Statistics ---';
SELECT 
    q.question_id,
    LEFT(q.question_text, 50) + '...' AS Question,
    q.question_type,
    q.difficulty_level,
    COUNT(sa.answer_id) AS TotalAnswers,
    SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) AS CorrectAnswers,
    CAST(SUM(CASE WHEN sa.is_correct = 1 THEN 1 ELSE 0 END) * 100.0 / COUNT(sa.answer_id) AS DECIMAL(5,2)) AS SuccessRate
FROM Questions q
LEFT JOIN Student_Answers sa ON q.question_id = sa.question_id
WHERE q.course_id = 1
GROUP BY q.question_id, q.question_text, q.question_type, q.difficulty_level
HAVING COUNT(sa.answer_id) > 0
ORDER BY SuccessRate ASC;
GO

-- 10.4 أداء الطلاب عبر كل الامتحانات
PRINT '';
PRINT '--- Student Performance Overview ---';
SELECT 
    s.student_id,
    s.first_name + ' ' + s.last_name AS StudentName,
    COUNT(se.exam_id) AS TotalExams,
    AVG(se.percentage) AS AverageScore,
    MAX(se.percentage) AS BestScore,
    MIN(se.percentage) AS WorstScore
FROM Students s
INNER JOIN Student_Exams se ON s.student_id = se.student_id
WHERE se.status = 'corrected'
GROUP BY s.student_id, s.first_name, s.last_name
ORDER BY AverageScore DESC;
GO

-- 10.5 إحصائيات الكورسات
PRINT '';
PRINT '--- Course Statistics ---';
SELECT 
    c.course_id,
    c.course_name,
    d.department_name,
    i.first_name + ' ' + i.last_name AS Instructor,
    COUNT(DISTINCT sc.student_id) AS EnrolledStudents,
    COUNT(DISTINCT se.exam_id) AS TotalExams,
    AVG(se.percentage) AS AverageExamScore
FROM Courses c
INNER JOIN Departments d ON c.department_id = d.department_id
LEFT JOIN Instructors i ON c.instructor_id = i.instructor_id
LEFT JOIN Student_Courses sc ON c.course_id = sc.course_id
LEFT JOIN Student_Exams se ON c.course_id = se.course_id AND se.status = 'corrected'
GROUP BY c.course_id, c.course_name, d.department_name, i.first_name, i.last_name
ORDER BY EnrolledStudents DESC;
GO

-- 10.6 الفروع والتراكات المتاحة
PRINT '';
PRINT '--- Available Tracks per Branch ---';
SELECT 
    b.branch_name,
    STRING_AGG(t.track_name, ', ') AS AvailableTracks,
    COUNT(DISTINCT t.track_id) AS TrackCount
FROM Branches b
INNER JOIN Branch_Tracks bt ON b.branch_id = bt.branch_id
INNER JOIN Tracks t ON bt.track_id = t.track_id
GROUP BY b.branch_id, b.branch_name
ORDER BY TrackCount DESC;
GO

PRINT '';
PRINT '========================================';
PRINT 'COMPLETE FLOW FINISHED SUCCESSFULLY!';
PRINT '========================================';
PRINT 'Summary:';
PRINT '- Institute & Branches: Created';
PRINT '- Tracks & Departments: Created';
PRINT '- Instructors: Added';
PRINT '- Courses: Created';
PRINT '- Students: Registered';
PRINT '- Questions: Added to courses';
PRINT '- Exam: Generated & Submitted';
PRINT '- Results: Corrected & Analyzed';
PRINT '========================================';