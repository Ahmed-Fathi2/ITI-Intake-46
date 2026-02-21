
--1. Create a cursor for Employee table that increases Employee salary by 10% if Salary <3000 
--   and increases it by 20% if Salary >=3000. 
--Use company DB
declare c1 cursor
for select E.Salary from [Employee] E
for update
declare @sal int 
open c1
fetch c1 into @sal
while @@FETCH_STATUS=0
	begin
		if @sal<3000
			update [Employee]
				set Salary=@sal*1.10
			where current of c1
		else if @sal>=3000
			update [Employee]
				set Salary=Salary*1.20
			where current of c1
	
		fetch c1 into @sal
	end
close c1
deallocate c1

--2.Display Department name with its manager name using cursor.
-- Use ITI DB
declare c2 cursor

for 
select D.Dept_Name,I.Ins_Name
from Department D ,  Instructor I
where I.Ins_Id= D.Dept_Manager

for read only

declare @Dept_Name varchar(50),@Ins_Name varchar(50)

open c2

fetch c2 into @Dept_Name,@Ins_Name

while @@FETCH_STATUS=0	
	begin
		select @Dept_Name as Department_Name,@Ins_Name as Instactor_Name
		fetch c2 into @Dept_Name,@Ins_Name  --counter++
	end

close c2

deallocate c2

--3	Try to display all students first name in one cell separated by comma. Using Cursor 

declare c3 cursor

for 
select St_Fname from Student

for read only

declare @St_Fname varchar(50) , @all_Names varchar(500) = ''

open c3

fetch c3 into @St_Fname

while @@FETCH_STATUS=0	
	begin
		set @all_Names = CONCAT(@all_Names , ',' , @St_Fname)
		fetch c3 into @St_Fname
	end

select @all_Names

close c3

deallocate c3

--4.	Create full, differential Backup for SD DB.

backup database SD
to disk = 'D:\iti\db\lab10\sd_full.bak' 

backup database SD
to disk = 'D:\iti\db\lab10\sd_diffi.bak' 
with differential


--5 5.	Create a sequence object that allow values from 1 to 10
--without cycling in a specific column and test it.

create sequence seq
start with 1
increment by 1
minvalue 1
maxvalue 10
no cycle;

create table seq_test
(
id int 
)

insert into seq_test 
values(next value for seq);

select * from seq_test

--6.Use display student’s data (ITI DB) in excel sheet

--7 Transform all functions in day7 to Stored Procedures

create proc get_month_name @d date , @monthname varchar(20) output
as 
	begin

	  set @monthname =format(@d,'MMMM')

	end

	declare @month_name varchar(20)
	exec  get_month_name 
	@d= '3/10/2002',
	@monthname=@month_name output;

	select @month_name As Month_Name  -- adventure db

--------------------------------------------------------------------------------------------------
alter proc get_values_between @start int, @end int
as
	begin
		declare @i int = @start
		create table #result (id int )
		while @i <= @end
		begin
			 insert into #result values (@i)
			 set @i = @i + 1
		end

		select * from #result

	end

exec	get_values_between 5, 10 -- adventure db

-----------------------------------------------------------------------------------------------------

create proc get_stud_depart_Proc @st_no int
as 
	begin


    select d.dept_name, concat( s.st_fname , ' ' , s.st_lname) as full_name 
    from student s
    join department d on s.dept_id = d.dept_id
    where s.st_id = @st_no

	end

exec get_stud_depart_Proc 10


-----------------------------------------------------------------------------------------------------
create Proc check_stud_name_Proc @st_id int , @result varchar(100) output

as
begin
  declare @fname varchar(50), @lname varchar(50), @msg varchar(100)

  select @fname = st_fname, @lname = st_lname from student where st_id = @st_id

   if @fname is null and @lname is null
   set @result = 'first name & last name are null'

    else if @fname is null
      set @result = 'first name is null'

    else if @lname is null
    set @result = 'last name is null'

    else
    set @result = 'first name & last name are not null'

   
end

declare @r varchar(100)
exec check_stud_name_Proc
@st_id= 9 ,
@result =@r output

select @r

--------------------------------------------------------------------------------------

create proc manager_info_proc @manager_id int

as
    select d.dept_name, m.Ins_Name, d.Manager_hiredate
    from department d
    join instructor m on m.Ins_Id = d.Dept_Manager
    where m.ins_id = @manager_id

exec manager_info_proc 2

--------------------------------------------------------------------------------------
create proc get_student_names_proc @type varchar(20)
as
begin
    if @type = 'first name'
         select isnull(st_fname, '') from student
    else if @type = 'last name'
        select isnull(st_lname, '') from student
    else if @type = 'full name'
        select isnull(st_fname, '') + ' ' + isnull(st_lname, '') from student
    return
end


exec get_student_names_proc 'first name'


--8 
create database AdventureWorks_Snap
ON
(
    NAME = 'AdventureWorks2012_Data',
    FILENAME = 'D:\iti\db\lab10\seq.ss'
)
AS SNAPSHOT OF AdventureWorks2012;

SELECT TOP (1000) [DepartmentID]
      ,[Name]
      ,[GroupName]
      ,[ModifiedDate]
  FROM AdventureWorks_Snap.[HumanResources].[Department]

  update AdventureWorks2012.[HumanResources].[Department]
  set GroupName = 'test'
  where DepartmentID=1


  SELECT TOP (1000) [DepartmentID]
      ,[Name]
      ,[GroupName]
      ,[ModifiedDate]
  FROM AdventureWorks2012.[HumanResources].[Department]
  
SELECT TOP (1000) [DepartmentID]
      ,[Name]
      ,[GroupName]
      ,[ModifiedDate]
  FROM AdventureWorks_Snap.[HumanResources].[Department]


