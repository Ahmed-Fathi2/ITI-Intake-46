
create function get_month (@d date)
returns varchar(20)
	begin

		declare @month_name varchar(20)

	   set @month_name = format(@d,'MMMM')
	  -- set @month_name =month(@d)

		
		 return @month_name 
	end
go
select dbo.get_month ('10/1/2025')

---------------------------------------------------------------------------------------------------------------
-- Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
go
alter function get_range (@num1 int , @num2 int)
returns @t table(number int)
begin
	declare @i int = @num1
	while @i <= @num2
	begin
		insert into @t values(@i)
		set @i = @i+1
	end

	return
end
go
select * from get_range(-5,10)

---------------------------------------------------------------------------------------------------------------
--3.Create inline function that takes Student No and returns Department Name with Student full name.
go
alter function get_student_info (@id int)
returns table
as
return
(
	select D.Dept_Name, concat_ws(' - ',S.St_Fname,S.St_Lname)as full_name
	from Student S , Department D 
	where  D.Dept_Id= S.Dept_Id and S.St_Id= @id

)
go
select * from get_student_info (2)

---------------------------------------------------------------------------------------------------------------
go
create function get_name (@id int)
returns varchar(50)
begin
	
	declare @f_name varchar(20) ,@l_name varchar(20) , @result varchar(50)

	select @f_name=S.St_Fname , @l_name= S.St_Lname
	from Student S
	where S.St_Id = @id
	
	if @f_name is null and @l_name is null
	set @result= 'First name & last name are null'

	else if @f_name is null
	set @result= 'first name is null'

	else if @l_name is null
	set @result= 'last name is null'
	
	else 
	set @result= 'First name & last name are not null'


	return @result
	
end

go
select dbo.get_name(12)

---------------------------------------------------------------------------------------------------------------

--Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
go
create function get_manger_info (@id int)
returns table
as
return
(
	select D.Dept_Name,I.Ins_Name
	from Instructor I , Department D
	where I.Ins_Id= D.Dept_Manager and I.Ins_Id = @id

)
go

select * from get_manger_info(1)

------------------------------------------------------------------------------------------------------------------------

go
create function get_stud_name (@Required_name varchar(50))
returns @t table( _name  varchar(20) )
as 
begin

	if @Required_name = 'first name'
	insert into @t
	select  isnull(S.St_Fname , ' ') from Student S 

	else if @Required_name = 'last name'
	insert into @t
	select  isnull(S.St_Lname , ' ') from Student S 

	else if @Required_name = 'full name'
	insert into @t
	select  concat_ws(' - ' , S.St_Fname ,S.St_Lname) from Student S 


	return
end

go
select * from get_stud_name ('full name')

