  select 
    s.* ,d.department_name as deptName ,
    b.branch_name as BranchName ,
    t.track_name as trackName
  from Students s, Departments d  , Branches b , Tracks t 
  where  s.department_id= d.department_id
  and    s.branch_id = b.branch_id
  and    t.track_id= d.track_id
  and    s.department_id=3


  ------------------------------------------------------------------------------------
  select 
    CONCAT_WS(' ',s.first_name,s.last_name)as full_name ,
    c.course_name , 
   CONVERT(nvarchar(200), CAST((sc.final_grade * 100.0) / c.max_degree AS DECIMAL(5,2)))+' % ' AS percentage
  from Student_Courses sc, Students s ,Courses c 
  where s.student_id=sc.student_id and c.course_id= sc.course_id
  and s.student_id= 1  
  --------------------------------------------------------------------------------------
    select c.course_name, count(*)  as total_numof_student
  from Instructor_Course ic , Courses c , Student_Courses sc 
  where c.course_id = ic.course_id and ic.instructor_id=1 and c.course_id = sc.course_id
  group by c.course_name,c.course_id
  ---------------------------------------------------------------------------------------
  select ct.topic_name
  from Course_Topics ct
  where ct.course_id = 2
  --------------------------------------------------------------------------------------
  --=======================
  --NOT Complete 
  --=======================
  SELECT TOP (1000) [option_id]
      ,[question_id]
      ,[option_letter]
      ,[option_text]
      ,[created_date]
  FROM [ExamV3].[dbo].[Question_Options]

  SELECT TOP (1000) [exam_id]
      ,[question_id]
  FROM [ExamV3].[dbo].[Exam_Questions]




  select * 
  from Exam_Questions eq , Questions q 
  where q.question_id= eq.question_id
    and eq.exam_id=1 
---------------------------------------------------------------------------------------

  select e.exam_id ,e.student_id, q.question_text , q.question_type , sa.student_answer
  from Exams e ,Student_Answers sa  , Questions q 
  where e.exam_id= sa.exam_id and q.question_id=sa.question_id 
  and e.student_id=1
  and e.exam_id = 21
  -------------------------------------------------------------------------------------



  

