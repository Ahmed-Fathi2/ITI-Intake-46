Alter proc sp_correctexam
    @examid int
as
begin
    set nocount on;

    declare @totalquestions int;
    declare @answeredquestions int;
    declare @correctanswers int;
    declare @totalpoints int;
    declare @earnedpoints int;
    declare @percentage decimal(5,2);
    declare @studentid int;
    declare @courseid int;
    declare @studentname nvarchar(200);
    declare @coursename nvarchar(200);


    begin try
        begin transaction;

      --============================================================================================
        if not exists (select 1 from Exams where exam_id = @examid)
        begin
            raiserror('exam not found!', 16, 1);
            return;
        end
     --============================================================================================

        declare @examstatus varchar(20);
        select @examstatus = status from Exams where exam_id = @examid;

        if @examstatus = 'generated'
        begin
            raiserror('exam not submitted yet!', 16, 1);
            return;
        end

        if @examstatus = 'corrected'
        begin
            print 'warning: exam already corrected! re-correcting...';
        end
     --============================================================================================
        select @answeredquestions = count(*)
        from student_answers
        where exam_id = @examid;

        insert into student_answers (exam_id, question_id, student_answer, is_correct, points_earned)
        select eq.exam_id, eq.question_id, null, 0, 0
        from exam_questions eq
        where eq.exam_id = @examid
          and not exists (
              select 1 from student_answers sa
              where sa.exam_id = eq.exam_id and sa.question_id = eq.question_id
          );

    --============================================================================================
        update sa
        set 
            sa.is_correct = case 
                when lower(ltrim(rtrim(sa.student_answer))) = lower(ltrim(rtrim(q.correct_answer))) 
                then 1 else 0 end,
            sa.points_earned = case 
                when lower(ltrim(rtrim(sa.student_answer))) = lower(ltrim(rtrim(q.correct_answer))) 
                then q.points else 0 end
        from student_answers sa
        inner join questions q on sa.question_id = q.question_id
        where sa.exam_id = @examid;
      --============================================================================================
        select @correctanswers = count(*)
        from student_answers
        where exam_id = @examid and is_correct = 1;

        select @totalpoints = sum(q.points)
        from exam_questions eq
        inner join questions q on eq.question_id = q.question_id
        where eq.exam_id = @examid;

        select @earnedpoints = isnull(sum(points_earned), 0)
        from student_answers
        where exam_id = @examid;

     --============================================================================================       
        if @totalpoints > 0
            set @percentage = (@earnedpoints * 100.0) / @totalpoints;
        else
            set @percentage = 0;


        update Exams
        set 
            score = @earnedpoints,
            percentage = @percentage,
            status = 'corrected'
        where exam_id = @examid;
     --============================================================================================
        select @studentid = student_id,
               @courseid = course_id,
               @totalquestions = total_questions
        from Exams
        where exam_id = @examid;

        select @studentname = first_name + ' ' + last_name
        from students where student_id = @studentid;

        select @coursename = course_name
        from courses where course_id = @courseid;

        commit transaction;

    
    print '========================================';
    print '        exam correction report';
    print '========================================';
    print 'student: ' + @studentname;
    print 'course: ' + @coursename;
    print 'exam id: ' + cast(@examid as varchar);
    print 'total questions: ' + cast(@totalquestions as varchar);
    print 'answered: ' + cast(@answeredquestions as varchar);
    print 'correct: ' + cast(@correctanswers as varchar);
    print 'wrong: ' + cast(@answeredquestions - @correctanswers as varchar);
    print '----------------------------------------';
    print 'note: unanswered questions are counted as wrong';
    print '----------------------------------------';
    print 'total points: ' + cast(@totalpoints as varchar);
    print 'earned points: ' + cast(@earnedpoints as varchar);
    print 'percentage: ' + cast(@percentage as varchar) + '%';
    print 'result: ' + case when @percentage >= 50 then 'passed' else 'failed' end;
    print '========================================';


    end try
    begin catch
        if @@trancount>0 rollback transaction;
        print 'error: ' + error_message();
    end catch
end;
go


exec sp_correctexam 1


