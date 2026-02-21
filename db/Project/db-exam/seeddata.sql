--🔹 1) Branches (20)
INSERT INTO Branches (branch_name, location, phone)
VALUES
(N'Smart Village',N'6 October','02-1001'),
(N'Nasr City',N'Cairo','02-1002'),
(N'Mansoura',N'Dakahlia','050-1003'),
(N'Alexandria',N'Smouha','03-1004'),
(N'Assiut',N'Assiut','088-1005'),
(N'Ismailia',N'Ismailia','064-1006'),
(N'Minia',N'Minia','086-1007'),
(N'Sohag',N'Sohag','093-1008'),
(N'Aswan',N'Aswan','097-1009'),
(N'Tanta',N'Gharbia','040-1010'),
(N'Fayoum',N'Fayoum','084-1011'),
(N'Zagazig',N'Sharqia','055-1012'),
(N'Damietta',N'Damietta','057-1013'),
(N'Port Said',N'Port Said','066-1014'),
(N'Suez',N'Suez','062-1015'),
(N'Beni Suef',N'Beni Suef','082-1016'),
(N'Qena',N'Qena','096-1017'),
(N'Luxor',N'Luxor','095-1018'),
(N'Marsa Matrouh',N'Matrouh','046-1019'),
(N'El Arish',N'Sinai','068-1020');

--🔹 2) Tracks (20)
INSERT INTO Tracks (track_name, description)
VALUES
(N'Content Development',N'Games & Media'),
(N'Information Systems',N'Web & DB'),
(N'Software Engineering',N'Enterprise Apps'),
(N'AI & Data Science',N'AI ML DL'),
(N'Cyber Security',N'Security'),
(N'Cloud Computing',N'Cloud & DevOps'),
(N'Embedded Systems',N'IoT'),
(N'Industrial Automation',N'PLC'),
(N'UI UX Design',N'Design'),
(N'Business Intelligence',N'Analytics'),
(N'Mobile Development',N'Android iOS'),
(N'Game Development',N'Unity Unreal'),
(N'Backend Engineering',N'APIs'),
(N'Frontend Engineering',N'Web UI'),
(N'Data Engineering',N'Big Data'),
(N'DevOps Engineering',N'CI CD'),
(N'Network Engineering',N'Networks'),
(N'IT Support',N'Support'),
(N'Robotics',N'Robots'),
(N'AR VR',N'Virtual Reality');

--🔹 3) Branch_Track (20)
INSERT INTO Branch_Track (branch_id, track_id)
VALUES
(1,1),(1,2),(1,3),(1,4),
(2,2),(2,5),(2,6),
(3,1),(3,2),
(4,5),(4,6),
(5,8),(6,9),
(7,10),(8,11),
(9,12),(10,13),
(11,14),(12,15),
(13,16);

--🔹 4) Departments (20)
INSERT INTO Departments (department_name, description, track_id)
VALUES
(N'Game Programming',N'Game Logic',1),
(N'3D Animation',N'3D',1),
(N'Web Development',N'Web',2),
(N'Database Systems',N'DB',2),
(N'Software Architecture',N'Architecture',3),
(N'Machine Learning',N'ML',4),
(N'Deep Learning',N'DL',4),
(N'Cyber Defense',N'Security',5),
(N'Cloud Architecture',N'Cloud',6),
(N'DevOps',N'CI CD',6),
(N'Embedded C',N'Embedded',7),
(N'PLC Programming',N'PLC',8),
(N'UI Design',N'UI',9),
(N'UX Research',N'UX',9),
(N'Data Analysis',N'Analysis',10),
(N'Mobile Apps',N'Mobile',11),
(N'Game Engines',N'Engines',12),
(N'Backend APIs',N'APIs',13),
(N'Frontend UI',N'UI',14),
(N'Big Data',N'Big Data',15);

--🔹 5) Courses (20)
INSERT INTO Courses (course_name,course_code,description)
VALUES
(N'Database Fundamentals','DB101',N'Basics'),
(N'Advanced SQL','DB201',N'TSQL'),
(N'ASP.NET Core','WEB301',N'Backend'),
(N'JavaScript','WEB101',N'JS'),
(N'Unity Engine','GAME201',N'Unity'),
(N'Python Basics','PY101',N'Python'),
(N'Machine Learning','ML401',N'ML'),
(N'Deep Learning','DL501',N'DL'),
(N'Cyber Security Basics','SEC101',N'Security'),
(N'Cloud Fundamentals','CLD101',N'Cloud'),
(N'DevOps Basics','DEV201',N'DevOps'),
(N'Embedded C','EMB101',N'C'),
(N'PLC Basics','PLC101',N'PLC'),
(N'UI Principles','UI101',N'UI'),
(N'UX Research','UX201',N'UX'),
(N'Data Analysis','DA101',N'Data'),
(N'Mobile Android','AND101',N'Android'),
(N'Game Physics','GAME301',N'Physics'),
(N'API Design','API201',N'APIs'),
(N'Big Data Intro','BD101',N'Big Data');

--🔹 6) Departments_Course (20)
INSERT INTO Departments_Course (department_id,course_id)
VALUES
(3,1),(4,2),(3,3),(3,4),
(1,5),(6,6),(6,7),(7,8),
(8,9),(9,10),(10,11),(11,12),
(12,13),(13,14),(14,15),
(15,16),(16,17),(17,18),
(18,19),(20,20);

--🔹 7) Instructors (20)
INSERT INTO Instructors (first_name,last_name,email,phone,salary,specialization)
VALUES
(N'Ahmed',N'Mahmoud','i1@iti.eg','0101',15000,N'DB'),
(N'Fatma',N'Hassan','i2@iti.eg','0102',16000,N'Web'),
(N'Omar',N'Khaled','i3@iti.eg','0103',17000,N'AI'),
(N'Mona',N'Ali','i4@iti.eg','0104',18000,N'Software'),
(N'Hassan',N'Ibrahim','i5@iti.eg','0105',15500,N'Games'),
(N'Sara',N'Youssef','i6@iti.eg','0106',16500,N'UI'),
(N'Mohamed',N'Samir','i7@iti.eg','0107',17500,N'DevOps'),
(N'Nour',N'Adel','i8@iti.eg','0108',18500,N'Security'),
(N'Ali',N'Reda','i9@iti.eg','0109',14500,N'Python'),
(N'Reem',N'Tarek','i10@iti.eg','0110',19000,N'Mobile'),
(N'Amr',N'Sayed','i11@iti.eg','0111',16000,N'Cloud'),
(N'Dina',N'Fathy','i12@iti.eg','0112',17000,N'PLC'),
(N'Karim',N'Hany','i13@iti.eg','0113',16500,N'Embedded'),
(N'Hala',N'Kamal','i14@iti.eg','0114',15500,N'UX'),
(N'Mostafa',N'Ashraf','i15@iti.eg','0115',18000,N'Data'),
(N'Esraa',N'Maged','i16@iti.eg','0116',17500,N'BI'),
(N'Tamer',N'Soliman','i17@iti.eg','0117',16000,N'Games'),
(N'Rania',N'Adel','i18@iti.eg','0118',18500,N'API'),
(N'Yara',N'Hossam','i19@iti.eg','0119',15000,N'Frontend'),
(N'Sherif',N'Nabil','i20@iti.eg','0120',19000,N'BigData');

--🔹 8) Instructor_Course (20)
INSERT INTO Instructor_Course (instructor_id,course_id)
VALUES
(1,1),(1,2),(2,3),(2,4),
(5,5),(9,6),(3,7),(3,8),
(8,9),(11,10),(7,11),(13,12),
(12,13),(6,14),(14,15),
(15,16),(10,17),(17,18),
(18,19),(20,20);

--🔹 9) Students (20)
INSERT INTO Students (first_name,last_name,email,phone,department_id,branch_id)
VALUES
(N'Ali',N'Mohamed','s1@iti.eg','0111',3,1),
(N'Nour',N'Ahmed','s2@iti.eg','0112',3,1),
(N'Mariam',N'Hassan','s3@iti.eg','0113',6,2),
(N'Youssef',N'Ibrahim','s4@iti.eg','0114',7,2),
(N'Khaled',N'Samir','s5@iti.eg','0115',1,3),
(N'Sara',N'Ali','s6@iti.eg','0116',13,4),
(N'Mohamed',N'Reda','s7@iti.eg','0117',10,5),
(N'Heba',N'Tarek','s8@iti.eg','0118',8,6),
(N'Adel',N'Mahmoud','s9@iti.eg','0119',4,1),
(N'Reem',N'Salem','s10@iti.eg','0120',6,2),
(N'Yara',N'Hossam','s11@iti.eg','0121',15,7),
(N'Tamer',N'Sayed','s12@iti.eg','0122',16,8),
(N'Dina',N'Fathy','s13@iti.eg','0123',17,9),
(N'Karim',N'Hany','s14@iti.eg','0124',18,10),
(N'Esraa',N'Maged','s15@iti.eg','0125',19,11),
(N'Mostafa',N'Ashraf','s16@iti.eg','0126',20,12),
(N'Rania',N'Adel','s17@iti.eg','0127',9,13),
(N'Amr',N'Soliman','s18@iti.eg','0128',11,14),
(N'Sherif',N'Nabil','s19@iti.eg','0129',12,15),
(N'Yasmine',N'Saad','s20@iti.eg','0130',14,16);

--🔹 10) Student_Courses (20)
INSERT INTO Student_Courses (student_id,course_id)
VALUES
(1,1),(1,3),(2,1),(3,6),(4,7),
(5,5),(6,14),(7,11),(8,9),
(9,2),(10,6),(11,16),(12,17),
(13,18),(14,19),(15,20),
(16,10),(17,8),(18,12),(19,13);

--🔹 11) Questions (20)
INSERT INTO Questions (course_id,question_text,question_type,correct_answer,points)
VALUES
(1,N'SQL is declarative','true_false','true',2),
(1,N'JOIN combines tables','true_false','true',2),
(1,N'COUNT returns rows','mcq','A',3),
(3,N'MVC has 3 layers','true_false','true',2),
(3,N'Controller handles logic','true_false','true',2),
(6,N'Python is interpreted','true_false','true',2),
(6,N'Lists are mutable','true_false','true',2),
(7,N'ML needs data','true_false','true',2),
(7,N'Overfitting is bad','true_false','true',2),
(8,N'DL uses NN','true_false','true',2),
(9,N'Firewall is security','true_false','true',2),
(10,N'Cloud is scalable','true_false','true',2),
(11,N'CI/CD automates deploy','true_false','true',2),
(12,N'C is low level','true_false','true',2),
(13,N'PLC controls machines','true_false','true',2),
(14,N'UI focuses visuals','true_false','true',2),
(15,N'UX focuses user','true_false','true',2),
(16,N'Data analysis finds insights','true_false','true',2),
(19,N'API connects systems','true_false','true',2),
(20,N'Big data has volume','true_false','true',2);

--🔹 12) Question_Options (MCQ)
INSERT INTO Question_Options (question_id,option_letter,option_text)
VALUES
(3,'A','COUNT()'),
(3,'B','SUM()'),
(3,'C','AVG()'),
(3,'D','TOTAL()');

--🔹 13) Exams (20)
INSERT INTO Exams (student_id,course_id,total_questions,total_points)
VALUES
(1,1,5,10),(2,1,5,10),(3,6,5,10),(4,7,5,10),
(5,5,5,10),(6,14,5,10),(7,11,5,10),(8,9,5,10),
(9,2,5,10),(10,6,5,10),(11,16,5,10),(12,17,5,10),
(13,18,5,10),(14,19,5,10),(15,20,5,10),
(16,10,5,10),(17,8,5,10),(18,12,5,10),
(19,13,5,10),(20,15,5,10);

--🔹 14) Exam_Questions (Sample)
INSERT INTO Exam_Questions (exam_id,question_id)
VALUES
(1,1),(1,2),(1,3),(1,4),(1,5);

--🔹 15) Student_Answers (Sample)
INSERT INTO Student_Answers (exam_id,question_id,student_answer)
VALUES
(1,1,'true'),
(1,2,'true'),
(1,3,'A'),
(1,4,'true'),
(1,5,'true');



-- Disable FK constraints
EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';

-- Delete data
DELETE FROM Student_Answers;
DELETE FROM Exam_Questions;
DELETE FROM Exams;
DELETE FROM Question_Options;
DELETE FROM Questions;
DELETE FROM Student_Courses;
DELETE FROM Students;
DELETE FROM Instructor_Course;
DELETE FROM Instructors;
DELETE FROM Course_Topics;
DELETE FROM Departments_Course;
DELETE FROM Courses;
DELETE FROM Departments;
DELETE FROM Branch_Track;
DELETE FROM Tracks;
DELETE FROM Branches;

-- Enable FK constraints
EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL';

PRINT '✅ All tables data deleted successfully';


DBCC CHECKIDENT ('Branches', RESEED, 0);
DBCC CHECKIDENT ('Tracks', RESEED, 0);
DBCC CHECKIDENT ('Departments', RESEED, 0);
DBCC CHECKIDENT ('Courses', RESEED, 0);
DBCC CHECKIDENT ('Instructors', RESEED, 0);
DBCC CHECKIDENT ('Students', RESEED, 0);
DBCC CHECKIDENT ('Questions', RESEED, 0);
DBCC CHECKIDENT ('Question_Options', RESEED, 0);
DBCC CHECKIDENT ('Exams', RESEED, 0);
DBCC CHECKIDENT ('Student_Answers', RESEED, 0);
