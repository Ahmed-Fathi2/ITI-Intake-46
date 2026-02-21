-- ========================================
-- EXAM SYSTEM DATABASE SCHEMA
-- Fixed Version - No Cascade Path Issues
-- ========================================
-- ===================================
-- 2. جدول الفروع (Branches)
-- ===================================
CREATE TABLE Branches (
    branch_id INT PRIMARY KEY IDENTITY(1,1),
    branch_name NVARCHAR(200) NOT NULL,
    location NVARCHAR(500),
    phone VARCHAR(20),
    created_date DATETIME DEFAULT GETDATE()
);
PRINT '✓ Branches table created';
GO

-- ===================================
-- 3. جدول التراكات (Tracks)
-- ===================================
CREATE TABLE Tracks (
    track_id INT PRIMARY KEY IDENTITY(1,1),
    track_name NVARCHAR(200) NOT NULL,
    description NVARCHAR(MAX),
    created_date DATETIME DEFAULT GETDATE()
);
PRINT '✓ Tracks table created';
GO

-- ===================================
-- 4. جدول العلاقة بين الفروع والتراكات
-- ===================================
CREATE TABLE Branch_Tracks (
    branch_id INT NOT NULL,
    track_id INT NOT NULL,
    start_date DATE DEFAULT GETDATE(),
    PRIMARY KEY (branch_id, track_id),
    FOREIGN KEY (branch_id) REFERENCES Branches(branch_id) ON DELETE CASCADE,
    FOREIGN KEY (track_id) REFERENCES Tracks(track_id) ON DELETE CASCADE
);
PRINT '✓ Branch_Tracks table created';
GO

-- ===================================
-- 5. جدول الأقسام (Departments)
-- ===================================
CREATE TABLE Departments (
    department_id INT PRIMARY KEY IDENTITY(1,1),
    track_id INT NOT NULL,
    department_name NVARCHAR(200) NOT NULL,
    description NVARCHAR(MAX),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (track_id) REFERENCES Tracks(track_id) ON DELETE CASCADE
);
PRINT '✓ Departments table created';
GO

-- ===================================
-- 6. جدول المدرسين (Instructors)
-- ===================================
CREATE TABLE Instructors (
    instructor_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    email VARCHAR(200) UNIQUE NOT NULL,
    phone VARCHAR(20),
    hire_date DATE DEFAULT GETDATE(),
    salary DECIMAL(10,2),
    created_date DATETIME DEFAULT GETDATE()
);
PRINT '✓ Instructors table created';
GO

-- ===================================
-- 7. جدول الكورسات (Courses)
-- ===================================
CREATE TABLE Courses (
    course_id INT PRIMARY KEY IDENTITY(1,1),
    course_name NVARCHAR(200) NOT NULL,
    department_id INT NOT NULL,
    instructor_id INT,
    credits INT DEFAULT 3,
    description NVARCHAR(MAX),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (department_id) REFERENCES Departments(department_id) ON DELETE CASCADE,
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id) ON DELETE SET NULL
);
PRINT '✓ Courses table created';
GO

-- ===================================
-- 8. جدول الطلاب (Students)
-- ===================================
CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    email VARCHAR(200) UNIQUE NOT NULL,
    phone VARCHAR(20),
    branch_id INT NOT NULL,
    track_id INT NOT NULL,
    enrollment_date DATE DEFAULT GETDATE(),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (branch_id) REFERENCES Branches(branch_id) ON DELETE NO ACTION,
    FOREIGN KEY (track_id) REFERENCES Tracks(track_id) ON DELETE NO ACTION
);
PRINT '✓ Students table created';
GO

-- ===================================
-- 9. جدول تسجيل الطلاب في الكورسات
-- ===================================
CREATE TABLE Student_Courses (
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    enrollment_date DATE DEFAULT GETDATE(),
    grade DECIMAL(5,2),
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'completed', 'dropped')),
    PRIMARY KEY (student_id, course_id),
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
);
PRINT '✓ Student_Courses table created';
GO

-- ===================================
-- 10. جدول الأسئلة (Questions)
-- ===================================
CREATE TABLE Questions (
    question_id INT PRIMARY KEY IDENTITY(1,1),
    course_id INT NOT NULL,
    question_text NVARCHAR(MAX) NOT NULL,
    question_type VARCHAR(20) NOT NULL CHECK (question_type IN ('true_false', 'multiple_choice')),
    correct_answer NVARCHAR(100) NOT NULL,
    points INT DEFAULT 1,
    difficulty_level VARCHAR(20) CHECK (difficulty_level IN ('easy', 'medium', 'hard')),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
);
PRINT '✓ Questions table created';
GO

-- ===================================
-- 11. جدول خيارات الأسئلة (MCQ فقط)
-- ===================================
CREATE TABLE Question_Options (
    option_id INT PRIMARY KEY IDENTITY(1,1),
    question_id INT NOT NULL,
    option_number INT NOT NULL CHECK (option_number BETWEEN 1 AND 4),
    option_text NVARCHAR(500) NOT NULL,
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (question_id) REFERENCES Questions(question_id) ON DELETE CASCADE,
    UNIQUE (question_id, option_number)
);
PRINT '✓ Question_Options table created';
GO

-- ===================================
-- 12. جدول امتحانات الطلاب
-- ===================================
CREATE TABLE Student_Exams (
    exam_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    exam_date DATETIME DEFAULT GETDATE(),
    total_questions INT NOT NULL,
    score DECIMAL(5,2) NULL,
    percentage DECIMAL(5,2) NULL,
    status VARCHAR(20) DEFAULT 'generated' CHECK (status IN ('generated', 'submitted', 'corrected')),
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE NO ACTION
);
PRINT '✓ Student_Exams table created';
GO

-- ===================================
-- 13. جدول أسئلة الامتحان المولدة
-- ✅ FIXED: Changed question_id cascade to NO ACTION
-- ===================================
CREATE TABLE Exam_Questions (
    exam_id INT NOT NULL,
    question_id INT NOT NULL,
    question_order INT NOT NULL,
    PRIMARY KEY (exam_id, question_id),
    FOREIGN KEY (exam_id) REFERENCES Student_Exams(exam_id) ON DELETE CASCADE,
    FOREIGN KEY (question_id) REFERENCES Questions(question_id) ON DELETE NO ACTION
);
PRINT '✓ Exam_Questions table created';
GO

-- ===================================
-- 14. جدول إجابات الطلاب
-- ===================================
CREATE TABLE Student_Answers (
    answer_id INT PRIMARY KEY IDENTITY(1,1),
    exam_id INT NOT NULL,
    question_id INT NOT NULL,
    student_answer NVARCHAR(100),
    is_correct BIT NULL,
    points_earned INT NULL,
    answered_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (exam_id) REFERENCES Student_Exams(exam_id) ON DELETE CASCADE,
    FOREIGN KEY (question_id) REFERENCES Questions(question_id) ON DELETE NO ACTION,
    UNIQUE (exam_id, question_id)
);
PRINT '✓ Student_Answers table created';
GO

PRINT '';
PRINT '========================================';
PRINT 'All tables created successfully!';
PRINT '========================================';
GO

-- ===================================
-- Verification Query
-- ===================================
SELECT 
    TABLE_NAME as TableName,
    (SELECT COUNT(*) 
     FROM INFORMATION_SCHEMA.COLUMNS 
     WHERE TABLE_NAME = t.TABLE_NAME) as ColumnCount
FROM INFORMATION_SCHEMA.TABLES t
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;


IF OBJECT_ID('Student_Answers', 'U') IS NOT NULL DROP TABLE Student_Answers;
IF OBJECT_ID('Exam_Questions', 'U') IS NOT NULL DROP TABLE Exam_Questions;
IF OBJECT_ID('Student_Exams', 'U') IS NOT NULL DROP TABLE Student_Exams;
IF OBJECT_ID('Question_Options', 'U') IS NOT NULL DROP TABLE Question_Options;
IF OBJECT_ID('Questions', 'U') IS NOT NULL DROP TABLE Questions;
IF OBJECT_ID('Student_Courses', 'U') IS NOT NULL DROP TABLE Student_Courses;
IF OBJECT_ID('Courses', 'U') IS NOT NULL DROP TABLE Courses;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;
IF OBJECT_ID('Branch_Tracks', 'U') IS NOT NULL DROP TABLE Branch_Tracks;
IF OBJECT_ID('Students', 'U') IS NOT NULL DROP TABLE Students;
IF OBJECT_ID('Instructors', 'U') IS NOT NULL DROP TABLE Instructors;
IF OBJECT_ID('Tracks', 'U') IS NOT NULL DROP TABLE Tracks;
IF OBJECT_ID('Branches', 'U') IS NOT NULL DROP TABLE Branches;
IF OBJECT_ID('Institutes', 'U') IS NOT NULL DROP TABLE Institutes;
GO