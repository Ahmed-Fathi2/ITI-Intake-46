---1  Create a stored procedure without parameters to show the number of students per department name.[use ITI DB] 
create proc Display 
as
select D.Dept_Name , COUNT(*)
from Student S,Department D
where D.Dept_Id= S.Dept_Id
group by D.Dept_Name

exec Display

---2

alter proc PrintE 
as
	begin

		declare @c int 

		select @c=count(*)
		from Works_on W 
		where w.ProjectNo='p1'

		if @c>3
			select 'The number of employees in the project p1 is 3 or more', E.EmpFname,E.EmpLname
			from HumanResource.Employee E

			else
			select 'The following employees work for the project p1', E.EmpFname,E.EmpLname
			from HumanResource.Employee E
		
	end


exec PrintE 


--3 	Create a stored procedure that will be used in case there is 
--		an old employee has left the project and a new one become instead of him. 
--The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number) 
--and it will be used to update works_on table. 

--SELECT TOP (1000) [ESSn]
    --  ,[Pno]
     -- ,[Hours]
 -- FROM [Company_SD].[dbo].[Works_for]

create proc updateEmployee @old_id int , @new_id int , @p_num int
as 
	begin

	update Works_for
	set ESSn = @new_id
	where ESSn= @old_id and Pno= @p_num

	end

exec updateEmployee	669955 , 112233,  300 





--4 
alter table [Project]
add  Budget DECIMAL(18,2);

update[Project]
set Budget = 100000 

CREATE TABLE Project_Audit (
    ProjectNo VARCHAR(20),
    UserName VARCHAR(50),
    ModifiedDate DATETIME,
    Budget_Old DECIMAL(18,2),
    Budget_New DECIMAL(18,2)
);

create trigger g0
on [Project]
after update
as
	BEGIN
    IF UPDATE(Budget)
    BEGIN
        INSERT INTO Project_Audit (ProjectNo, UserName, ModifiedDate, Budget_Old, Budget_New)
        SELECT 
            d.Pnumber,
            USER_NAME() AS UserName,
            GETDATE() AS ModifiedDate,
            d.Budget AS Budget_Old,
            i.Budget AS Budget_New
        FROM inserted i
        INNER JOIN deleted d
            ON i.Pnumber = d.Pnumber;
    END
END


update[Project]
set Budget = 100000 

--5	Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
--“Print a message for user to tell him that he can’t insert a new record in that table”

create trigger g1
on Department
instead of insert
as
	begin
		select 'you can’t insert a new record in  Department table'
	end


INSERT INTO Department
    (Dept_Id, Dept_Name, Dept_Desc, Dept_Location, Dept_Manager, Manager_hiredate)
VALUES
    (80, 'IT', 'Information Technology Department', 'Building A', 11, '2015-06-01');

--6 	 Create a trigger that prevents the insertion Process for Employee table in March [Company DB].

create trigger g2
on Employee
instead of insert
as
	begin
		if month(getdate()) !=  3
	      begin
			insert into Employee
			select * from inserted
		  end
		else
			select 'you cant select in March' 

	end


--7 	Create a trigger on student table after insert to add Row in Student Audit table (Server User Name , Date, Note) 
--      where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”


create table Student_Audit
(
	id int Primary key identity,
	serverName  nvarchar(50),
	dayDate date ,
	note nvarchar(50)
)

alter trigger g3
on Student
after insert
as
	begin
		    insert into Student_Audit (serverName, dayDate, note)
			SELECT 
				@@SERVERNAME AS ServerName,
				GETDATE() AS ActionDate,
				USER_NAME() + 
				' Insert New Row with Key=' + CAST(St_Id AS VARCHAR(20)) + 
				' in table Student' AS ActionDescription
			FROM inserted;
	end

	INSERT INTO Student
    (St_Id, St_Fname, St_Lname, St_Address, St_Age, Dept_Id, St_super)
	VALUES
    (17, 'Fathi', 'Hassan', 'Cairo', 22, NULL, NULL);


--8 Create a trigger on student table instead of delete to add Row in Student Audit table (Server User Name, Date, Note) 
--where note will be“ try to delete Row with Key=[Key Value]”

create trigger g4
on Student
instead of  delete
as
	begin
		    insert into Student_Audit (serverName, dayDate, note)
			SELECT 
				@@SERVERNAME AS ServerName,
				GETDATE() AS ActionDate,
				'try to delete Row with Key=' + CAST(St_Id AS VARCHAR(20))
			from deleted;
	end


delete from Student
where [St_Id] = 17 


