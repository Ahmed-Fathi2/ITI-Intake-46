
--[1]
select count(*)
from Student 
where St_Age is not null

--[2]
select distinct Ins_Name
from Instructor

--[3]

select 
E.St_Id as [Student ID],
concat (E.St_Fname,' ',E.St_Lname)As [Student FullName] , 
D.Dept_Name as [Department name]
from Student E , Department D
where D.Dept_Id= E.Dept_Id

--[4]
select I.Ins_Name,D.Dept_Name
from Instructor I left outer join Department D
on D.Dept_Id = I.Dept_Id

--[5]
select concat (S.St_Fname,' ',S.St_Lname)As [Student FullName] , C.Crs_Name
from Student S , Stud_Course SC ,Course C
where  S.St_Id = Sc.St_Id and C.Crs_Id= Sc.Crs_Id 
and Sc.Grade is not null

--[6]

select count(*), T.Top_Name 
from Course C , Topic T
where T.Top_Id  = C.Top_Id
group by T.Top_Name

--[7]
select MAX(Salary) MaxSalary , MIN(Salary) MinSalary
from Instructor

select * from Instructor

--[8]
select * 
from Instructor
where Salary < (select AVG(Salary) from Instructor)

--[9]
select D.Dept_Name
from Department D , Instructor I
where D.Dept_Id = i.Dept_Id
and I.Salary = (select min(salary) from Instructor)

--[10]
select Top(2) Salary
from Instructor
order by Salary desc

--[11]
select  Ins_Name , coalesce(convert(nvarchar(50),Salary), 'bonus')
from Instructor 

--[12]
select avg(Salary) As AvgSalaries
from Instructor

--[13]
select S.St_Fname, sup.*
from Student S , Student sup
where sup.St_Id = s.St_super

--[14]
SELECT 
    Dept_Id,
    Ins_Name,
    Salary
FROM (
    SELECT 
        Dept_Id,
        Ins_Name,
        Salary,
        ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY Salary DESC) AS RankNum
    FROM Instructor
    WHERE Salary IS NOT NULL
) AS Ranked
WHERE RankNum <= 2
ORDER BY Dept_Id, Salary DESC;


SELECT 
    Dept_Id,
    St_Id,
    St_Fname,
    St_Lname
FROM (
    SELECT 
        Dept_Id,
        St_Id,
        St_Fname,
        St_Lname,
        ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY NEWID()) AS RandNum
    FROM Student
) AS Randomized
WHERE RandNum = 1;






