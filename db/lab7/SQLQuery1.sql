-- return month name from date
create function get_month_name (@d date)
returns varchar(20)
as
begin
  declare @monthname varchar(20)

  set @monthname =format(@d,'MMMM')
    return @monthname
end
go
select dbo.get_month_name('2025-10-01') as month_name
go


------------------------------------------------------------------------------------------------

-- values between two integers

create function get_values_between(@start int, @end int)
returns @result table (val int)
as
begin
    declare @i int = @start
    while @i <= @end
    begin
     insert into @result values(@i)
     set @i = @i + 1
    end
    return
end
go

select * from dbo.get_values_between(5, 10)
go

------------------------------------------------------------------------------------------------

--  takes student no and returns department name with student full name

create function get_stud_depart2(@st_no int)
returns table
as
return
(
    select d.dept_name, concat( s.st_fname , ' ' , s.st_lname) as full_name
    from student s
    join department d on s.dept_id = d.dept_id
    where s.st_id = @st_no
)
go

select * from dbo.get_stud_depart2(9)
go


------------------------------------------------------------------------------------------------

--  check if first name or last name null

create function check_stud_name(@st_id int)
returns varchar(100)
as
begin
  declare @fname varchar(50), @lname varchar(50), @msg varchar(100)
  select @fname = st_fname, @lname = st_lname from student where st_id = @st_id
   if @fname is null and @lname is null
   set @msg = 'first name & last name are null'
    else if @fname is null
      set @msg = 'first name is null'
    else if @lname is null
    set @msg = 'last name is null'
    else
    set @msg = 'first name & last name are not null'

    return @msg
end
go

select dbo.check_stud_name(9) as name_status
go

------------------------------------------------------------------------------------------------

--  takes manager id and displays department name, manager name and hiring date

create function manager_info(@manager_id int)
returns table
as
return
(
    select d.dept_name, m.Ins_Name, d.Manager_hiredate
    from department d
    join instructor m on m.Ins_Id = d.Dept_Manager
    where m.ins_id = @manager_id
)
go

select * from dbo.manager_info(1)
go

------------------------------------------------------------------------------------------------

-- return names based on string parameter

create function get_student_names(@type varchar(20))
returns @result table (name varchar(100))
as
begin
    if @type = 'first name'
        insert into @result select isnull(st_fname, '') from student
    else if @type = 'last name'
        insert into @result select isnull(st_lname, '') from student
    else if @type = 'full name'
        insert into @result select isnull(st_fname, '') + ' ' + isnull(st_lname, '') from student
    return
end
go
select * from dbo.get_student_names('full name')
go

------------------------------------------------------------------------------------------------
-- student no and first name without last char

select st_id, left(st_fname, len(st_fname) - 1) as fname_without_last_char
from student
go

------------------------------------------------------------------------------------------------

-- delete all grades for students located in sd department

update sc
set sc.grade = null
from stud_course sc
join student s on sc.st_id = s.st_id
join department d on s.dept_id = d.dept_id
where d.dept_name = 'sd'

------------------------------------------------------------------------------------------------
create table organization
(
    id int identity(1,1) primary key,
    position_name varchar(50),
    node hierarchyid
)
go

insert into organization values ('ceo', hierarchyid::GetRoot())
insert into organization values ('manager', hierarchyid::GetRoot().GetDescendant(null, null))
insert into organization values ('employee', hierarchyid::GetRoot().GetDescendant(
 (select node from organization where position_name='manager'), null))
go

select * from organization
go

------------------------------------------------------------------------------------------------
--insert 3000 rows in student table
declare @i int = 1
while @i <= 3000
begin
    insert into student(st_id, st_fname, st_lname)
    values(@i, 'Ahmed', 'Fathi')
    set @i = @i + 1
end
go
