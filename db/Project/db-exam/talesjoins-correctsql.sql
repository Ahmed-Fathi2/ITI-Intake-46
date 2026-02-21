SELECT TOP (1000) [exam_id]
      ,[student_id]
      ,[course_id]
      ,[exam_date]
      ,[duration_minutes]
      ,[total_questions]
      ,[total_points]
      ,[score]
      ,[percentage]
      ,[status]
      ,[submitted_date]
      ,[corrected_date]
  FROM [Exams]
  where exam_id=1


  SELECT TOP (1000) [answer_id]
      ,[exam_id]
      ,[question_id]
      ,[student_answer]
      ,[is_correct]
      ,[points_earned]
      ,[answered_date]
  FROM [Student_Answers]
  where exam_id=1


  SELECT TOP (1000) [question_id]
      ,[course_id]
      ,[question_text]
      ,[question_type]
      ,[correct_answer]
      ,[points]
      ,[created_date]
  FROM [Questions]

go
  create proc Correct_Exam @exam_id int
  as
  begin
  
    if not exists (select 1 from Exams where exam_id= @exam_id)
    begin 
    print 'Error: No Exam with this exam id'
    end

    update sa
    set is_correct = case 
        when sa.student_answer=q.correct_answer then 1 
        else 0 
        end, 
        points_earned = case 
        when sa.student_answer=q.correct_answer then q.points
        else 0
        end
    from Student_Answers sa 
    join Questions q
    on q.question_id = sa.question_id
    where sa.exam_id=1

    declare @score int ;

    select @score=sum(points_earned)
    from Student_Answers
    where exam_id=1




    declare @tot_points int;

    select @tot_points = total_points
    from Exams
    where exam_id=1




    declare @percent decimal(5,2)

    set @percent= (@score*100)/@tot_points

    update Exams 
    set score = @score ,
        percentage = @percent ,
        status='corrected',
        corrected_date=GETDATE()
    where exam_id=1





  end

