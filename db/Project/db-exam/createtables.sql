
-- ========================================
-- ITI EXAM SYSTEM - CORRECTED DESIGN
-- 9-Month Program (No Academic Years/Semesters)
-- Tracks → Departments (Fixed Hierarchy)
-- ========================================

-- ===================================
-- 1. BRANCHES (الفروع)
-- ===================================
CREATE TABLE Branches (
    branch_id INT PRIMARY KEY IDENTITY(1,1),
    branch_name NVARCHAR(200) NOT NULL UNIQUE,
    location NVARCHAR(500),
    phone VARCHAR(20),
    created_date DATETIME DEFAULT GETDATE()
);
 
 go 
-- ===================================
-- 2. TRACKS (المسارات الرئيسية)
-- مثل: Content Developments, Information Systems
-- ===================================
CREATE TABLE Tracks (
    track_id INT PRIMARY KEY IDENTITY(1,1),
    track_name NVARCHAR(200) NOT NULL UNIQUE,
    description NVARCHAR(MAX),
    duration_months INT DEFAULT 9, 
    created_date DATETIME DEFAULT GETDATE()
);
go
-- ===================================
-- 3. BRANCH-TRACK OFFERINGS
-- أي فرع يقدم أي تراك
-- ===================================
CREATE TABLE Branch_Track (
    branch_id INT NOT NULL,
    track_id INT NOT NULL,
    PRIMARY KEY (branch_id, track_id),
    FOREIGN KEY (branch_id) REFERENCES Branches(branch_id) ON DELETE CASCADE,
    FOREIGN KEY (track_id) REFERENCES Tracks(track_id) ON DELETE CASCADE
);

go
-- ===================================
-- 4. DEPARTMENTS (الأقسام داخل المسار)
-- مثل: Game Programming, VFX Compositing تحت Content Developments
-- ===================================
CREATE TABLE Departments (
    department_id INT PRIMARY KEY IDENTITY(1,1),
    department_name NVARCHAR(200) NOT NULL,
    description NVARCHAR(500),
    created_date DATETIME DEFAULT GETDATE(),
    track_id INT NOT NULL,
    FOREIGN KEY (track_id) REFERENCES Tracks(track_id) ON DELETE CASCADE,
    UNIQUE (track_id, department_name)
);

go;
-- ===================================
-- ===================================


go
-- ===================================
-- 7. COURSES (الكورسات)
-- ===================================
CREATE TABLE Courses (
    course_id INT PRIMARY KEY IDENTITY(1,1),
    course_name NVARCHAR(200) NOT NULL,
    course_code VARCHAR(20) UNIQUE NOT NULL,
   
    description NVARCHAR(MAX),
    max_degree INT DEFAULT 100,
    min_degree INT DEFAULT 50,
    created_date DATETIME DEFAULT GETDATE()
 --   FOREIGN KEY (department_id) REFERENCES Departments(department_id) ON DELETE CASCADE
);
--alter table  Courses drop column department_id

CREATE TABLE Departments_Course (
    department_id INT Not Null,
    course_id INT Not Null,
    Primary key (department_id,course_id),
    FOREIGN KEY (department_id) REFERENCES Departments(department_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
   
);
go

-- ===================================
-- 6. INSTRUCTORS (المدرسين)
-- ===================================
CREATE TABLE Instructors (
    instructor_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    email VARCHAR(200) UNIQUE NOT NULL,
    phone VARCHAR(20),
    hire_date DATE DEFAULT GETDATE(),
    salary DECIMAL(10,2),
    specialization NVARCHAR(200),
    created_date DATETIME DEFAULT GETDATE()
);

go
-- ===================================
-- 8. COURSE TOPICS (موضوعات الكورس)
-- ===================================
CREATE TABLE Course_Topics (
    topic_id INT PRIMARY KEY IDENTITY(1,1),
    course_id INT NOT NULL,
    topic_name NVARCHAR(300) NOT NULL,
    topic_order INT NOT NULL,
    description NVARCHAR(MAX),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    UNIQUE (course_id, topic_order)
);

go
-- ===================================
-- 9. INSTRUCTOR-COURSE ASSIGNMENT
-- المدرس يدرس كورس في intake معين
-- ===================================
CREATE TABLE Instructor_Course( 
    instructor_id INT NOT NULL,
    course_id INT NOT NULL,
    start_date DATE DEFAULT GETDATE(),
    end_date DATE NULL,
    Primary key(course_id,instructor_id),
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
);

go
-- ===================================
-- 10. STUDENTS (الطلاب)
-- ===================================
CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    email VARCHAR(200) UNIQUE NOT NULL,
    phone VARCHAR(20),
    department_id INT NOT NULL, 
    branch_id INT NOT NULL,
    enrollment_date DATE DEFAULT GETDATE(),
    graduation_date DATE NULL,
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'graduated')),
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (department_id) REFERENCES Departments(department_id) ON DELETE NO ACTION,
    FOREIGN KEY (branch_id) REFERENCES Branches(branch_id) ON DELETE CASCADE
);

go
-- ===================================
-- 11. STUDENT COURSE ENROLLMENT
-- ===================================
CREATE TABLE Student_Courses ( 
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    enrollment_date DATE DEFAULT GETDATE(),
    final_grade DECIMAL(5,2) NULL,
    status VARCHAR(20) DEFAULT 'active' CHECK (status IN ('active', 'completed', 'failed')),
    primary key(student_id,course_id),
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
);

go
-- ===================================
-- 12. QUESTIONS (بنك الأسئلة)
-- ===================================
CREATE TABLE Questions (
    question_id INT PRIMARY KEY IDENTITY(1,1),
    course_id INT NOT NULL,
    question_text NVARCHAR(MAX) NOT NULL,
    question_type VARCHAR(20) NOT NULL CHECK (question_type IN ('true_false', 'mcq')),
    correct_answer VARCHAR(10) NOT NULL,
    points INT DEFAULT 1,
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
 
);

go
-- ===================================
-- 13. QUESTION OPTIONS (خيارات MCQ)
-- ===================================
CREATE TABLE Question_Options (
    option_id INT PRIMARY KEY IDENTITY(1,1),
    question_id INT NOT NULL,
    option_letter VARCHAR(1) NOT NULL CHECK (option_letter IN ('A','B','C','D')),
    option_text NVARCHAR(500) NOT NULL,
    created_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (question_id) REFERENCES Questions(question_id) ON DELETE CASCADE,
    UNIQUE (question_id, option_letter)
);

go
-- ===================================
-- 14. EXAMS (الامتحانات)
-- ===================================
CREATE TABLE Exams (
    exam_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    exam_date DATETIME DEFAULT GETDATE(),
    duration_minutes INT NOT NULL DEFAULT 120,
    total_questions INT NOT NULL,
    total_points INT NOT NULL,
    score DECIMAL(5,2) NULL,
    percentage DECIMAL(5,2) NULL,
    status VARCHAR(20) DEFAULT 'generated' CHECK (status IN ('generated', 'submitted', 'corrected')),
    submitted_date DATETIME NULL,
    corrected_date DATETIME NULL,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE NO ACTION
);

go
-- ===================================
-- 15. EXAM QUESTIONS
-- ===================================
CREATE TABLE Exam_Questions (
    exam_id INT NOT NULL,
    question_id INT NOT NULL,
    PRIMARY KEY (exam_id, question_id),
    FOREIGN KEY (exam_id) REFERENCES Exams(exam_id) ON DELETE CASCADE,
    FOREIGN KEY (question_id) REFERENCES Questions(question_id) ON DELETE NO ACTION,
);
go
-- ===================================
-- 16. STUDENT ANSWERS
-- ===================================
CREATE TABLE Student_Answers (
    answer_id INT PRIMARY KEY IDENTITY(1,1),
    exam_id INT NOT NULL,
    question_id INT NOT NULL,
    student_answer VARCHAR(10) Not NULL CHECK (student_answer IN ('A','B','C','D','a','b','c','d','true','false','TRUE','FALSE')),
    is_correct BIT NULL,
    points_earned INT NULL,
    answered_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (exam_id) REFERENCES Exams(exam_id) ON DELETE CASCADE,
    FOREIGN KEY (question_id) REFERENCES Questions(question_id) ON DELETE NO ACTION,
    UNIQUE (exam_id, question_id)
);
go



--===================================================================================================================
        select 
            @tftotal = count(*),
            @tfcorrect = sum(case when sa.is_correct = 1 then 1 else 0 end),
            @tfwrong = sum(case when sa.is_correct = 0 or sa.is_correct is null then 1 else 0 end)
        from exam_questions eq
        inner join questions q on eq.question_id = q.question_id
        left join student_answers sa on sa.exam_id = eq.exam_id and sa.question_id = q.question_id
        where eq.exam_id = @examid and q.question_type = 'true_false';

      --============================================================================================
        select 
            @mcqtotal = count(*),
            @mcqcorrect = sum(case when sa.is_correct = 1 then 1 else 0 end),
            @mcqwrong = sum(case when sa.is_correct = 0 or sa.is_correct is null then 1 else 0 end)
        from exam_questions eq
        inner join questions q on eq.question_id = q.question_id
        left join student_answers sa on sa.exam_id = eq.exam_id and sa.question_id = q.question_id
        where eq.exam_id = @examid and q.question_type = 'multiple_choice';