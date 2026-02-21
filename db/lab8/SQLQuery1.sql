
--1
create view v1
as
select S.St_Fname+' '+S.St_Lname As FullName , C.Crs_Name
from Student S , Course C , Stud_Course SC
where   s.St_Id= SC.St_Id 
	and C.Crs_Id = SC.Crs_Id
	and Sc.Grade>50

select * from v1



-- 2. Create an Encrypted view that displays manager names and the topics they teach. 

create view v_manager_topics
with encryption
as
select d.dept_manager, t.top_name
from department d
join instructor i on i.dept_id = d.dept_id
join ins_course ic on ic.ins_id = i.ins_id
join course c on c.crs_id = ic.crs_id
join topic t on t.top_id = c.top_id;



-- 3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 

create view v3
as
select I.Ins_Name,D.Dept_Name
from  Instructor I , Department D 
where D.Dept_Id = I.Dept_Id
and D.Dept_Name in('SD','Java') 

select * from v3


--4 Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;

create view v5
as
select *
from Student S
where S.St_Address in ('Alex','Cairo')
with check option

Update V5 set st_address='tanta'
Where st_address='alex';

select * from v5


--5 5.	Create a view that will display the project name and the number of employees work on it. 
--“Use SD database”

create view v6
as
select P.Pname,count(*) as numofemployee
from Project P , Works_for W 
where P.Pnumber = W.Pno
group by P.Pname

select * from v6

--6	Create index on column (Hiredate) that allow u to cluster 
--the data in table Department. What will happen?

CREATE CLUSTERED INDEX idx_Department_Hiredate
ON Department (Manager_hiredate);

-- error ->>> because table has already cluster index on pk and table has only one cluster index

--7 
CREATE UNIQUE INDEX idx_Student_Age
ON Student(St_Age);

-- error---> dublication

--8
create table DailyTransactions
(
 dayId int primary key,
 amout int 

)
insert into DailyTransactions 
values
(1, 1000),
(2, 2000),
(3, 1000);


create table LastTransactions
(
 TransactionId int primary key,
 amout int 

)
insert into LastTransactions 
values
(1, 4000),
(4, 2000),
(2, 10000);

MERGE LastTransactions AS Target
USING DailyTransactions AS Source
ON Target.TransactionId = Source.dayId


WHEN MATCHED THEN
    UPDATE SET Target.amout = Source.amout

WHEN NOT MATCHED BY TARGET THEN
    INSERT (TransactionId, amout)
    VALUES (Source.dayId, Source.amout)

WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

   select * from LastTransactions

    -----------------------------------------------------------------------------------------------------
   -- Part2: use SD_DB
--Create view named   “v_clerk” that will display employee#,project#, 
--the date of hiring of all the jobs of the type 'Clerk'.


create view v_clerk
as
select
    W.EmpNo,
    W.ProjectNo,
    W.Enter_Date
FROM Works_on W
WHERE W.Job = 'Clerk';

select * from v_clerk


--2 Create view named  “v_without_budget” that will display all the projects data without budget
create view v_without_budget1
as
select P.ProjectName,P.ProjectNo
from Company.Project P
where P.Budget is Null

select * from v_without_budget1

--3	Create view named  “v_count “ that will display the project name and the # of jobs in it
create view v_count
as
Select P.ProjectName as Pname , count(*) as numofjobs
from Works_on W , Company.Project P
where P.ProjectNo = W.ProjectNo  
group by P.ProjectName

select * from v_count



--4 	 Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
--use the previously created view  “v_clerk”

Select W.EmpNo
from v_clerk W
where W.ProjectNo ='p2'

--5 	modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 


Alter view v_without_budget1
as
select *
from Company.Project P
where P.Budget is Null and P.ProjectNo in('p1','p2')

select * from v_without_budget1


--6 	Delete the views  “v_ clerk” and “v_count”
drop view v_clerk, v_count;

--7 	Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
create view v7
as
select E.EmpNo , E.EmpLname
from HumanResource.Employee E , Company.Department D
where D.DeptNo='d2'

select * from v7


--8 8)	Display the employee  lastname that contains letter “J”
--Use the previous view created in Q#7

select D.EmpLname
from v7 as D 
where D.EmpLname like  '%j%'


--9 Create view named “v_dept” that will display the department# and department name.
create view v_dept1(DeptName, DeptNo)
as
select D.DeptName , D.DeptNo
from Company.Department D

select * from v_dept1




--10 10)	using the previous view try enter new department data 
--where dept# is ’d4’ and dept name is ‘Development’

insert into v_dept1 (DeptName, DeptNo)
values ('Development', 'd4');

--11 

create view v_2006_check as
select E.EmpNo, P.ProjectNo, W.Enter_Date
from Works_on W
join HumanResource.Employee E on W.EmpNo = E.EmpNo 
join company.project P on W.ProjectNo = P.ProjectNo
where W.Enter_Date >= '2006-01-01'
  and W.Enter_Date <= '2006-12-31';

 select * from v_2006_check





