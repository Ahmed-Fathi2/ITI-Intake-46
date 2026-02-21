sp_addtype loc ,'nchar(2)'  
go
create rule r1 as @x in ('NY','DS','KW') 
 go
create default def1 as 'NY' 
go
sp_bindrule r1,loc
go
sp_bindefault def1,loc



create table Department(
DeptNo nchar(100) Primary key ,
DeptName varchar(50) ,
Location loc
)
--drop table Department

insert into Department(DeptNo,DeptName,Location)
values('d1','Research','NY'),('d2','Accounting','DS'),('d3','Markiting','KW')

create table Employee(
EmpNo int primary key ,
EmpFname nvarchar(50) Not Null,
EmpLname nvarchar(50) Not Null,
DeptNo nchar(100) ,
Salary int Unique,
constraint Fk_Employee_Depart Foreign key (DeptNo) references Department(DeptNo)
)
create rule rsalary as @S<6000
go

sp_bindrule rsalary, 'Employee.Salary'

insert into Employee(EmpNo,EmpFname,EmpLname,DeptNo,Salary)
values(25348,'Mathew','Smith','d3',2500),(10102,'Ann','Jones','d3',3000)

-------------------------------------------------------------------------------
--Testing Referential Integrity	

--1-Add new employee with EmpNo =11111 In the works_on table [what will happen]
insert into Works_on(EmpNo,ProjectNo,Job,Enter_Date)
values(11111,'p1','test','2002-01-12')
-- The INSERT statement conflicted with the FOREIGN KEY constraint
--"FK_Works_on_Employee". The conflict occurred in database "test",
--table "HumanResource.Employee", column 'EmpNo'.


--2-Change the employee number 10102  to 11111  in the works on table [what will happen]
update Works_on
set EmpNo = 11111
where EmpNo=10102
-- The INSERT statement conflicted with the FOREIGN KEY constraint
--"FK_Works_on_Employee". The conflict occurred in database "test",
--table "HumanResource.Employee", column 'EmpNo'.

--3-Modify the employee number 10102 in the employee table to 22222. [what will happen]
update HumanResource.Employee
set EmpNo = 22222
where EmpNo=10102
--The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee".
--The conflict occurred in database "test", table "dbo.Works_on", column 'EmpNo'.

--4-Delete the employee with id 10102
delete HumanResource.Employee
where EmpNo= 10102
--The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee".
--The conflict occurred in database "test", table "dbo.Works_on", column 'EmpNo'.

---------------------------------------------------------------------------------
alter table Employee
add 
TelephoneNumber  nchar(15)

alter table Employee
drop column TelephoneNumber  

create schema Company 
create schema 	HumanResource  

alter schema Company transfer Department  
alter schema HumanResource transfer  Employee 

-----------------------------------------------------------------
SELECT 
    CONSTRAINT_NAME,
    CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME = 'Employee';
-----------------------------------------------------------------
create Synonym  Emp
for HumanResource.Employee

	Select * from Employee -- error
	Select * from [HumanResource].Employee
	Select * from Emp
	Select * from [HumanResource].Emp -- error

------------------------------------------------------------------

update Company.Project
set Budget = Budget+(Budget*.1)
from  Company.Project P ,Works_on W
where P.ProjectNo = W.ProjectNo
and w.EmpNo = 10102 and w.Job= 'Manager'

-------------------------------------------------------------
update Company.Department
set DeptName = 'Company.Department'
from  Company.Department D ,HumanResource.Employee E
where D.DeptNo= E.DeptNo
and E.EmpFname ='James'

-----------------------------------------------------------
update Works_on
set Enter_Date = '2007-12-12'
from  Company.Department D ,Works_on W , HumanResource.Employee E
where E.EmpNo = W.EmpNo and D.DeptNo = E.DeptNo
and w.ProjectNo = 'p1' and D.DeptName = 'Sales'

------------------------------------------------------------
delete  Works_on
from  Company.Department D ,Works_on W , HumanResource.Employee E
where E.EmpNo = W.EmpNo and D.DeptNo = E.DeptNo
and D.Location= 'KW'
------------------------------------------------------------

