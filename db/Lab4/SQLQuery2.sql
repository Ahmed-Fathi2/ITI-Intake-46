--[1]
select D.Dependent_name,D.Sex 
from [Dependent] D , Employee E
where  E.SSN = D.ESSN 
and D.Sex= 'F'
and E.Sex = 'F'
union
select D.Dependent_name,D.Sex 
from [Dependent] D , Employee E
where  E.SSN = D.ESSN 
and D.Sex= 'M'
and E.Sex = 'M'

--[2]
  select P.Pname , sum(Hours)
  from Works_for W, Project P
  where P.Pnumber = w.Pno
  group by P.Pname

--[3]
  select * 
  from Departments D
  where D.Dnum =
				(select Top(1) Dno
                  from Employee
				  order by SSN )

--[4]
  select
  D.Dname , 
  MAX(E.Salary)  as maxsalary,
  MIN (E.Salary) as minsalary,
  AVG(E.Salary)  as avgsalary
  from Employee E , Departments D
  where D.Dnum = E.Dno
  Group by D.Dname

--[5]
select (E.Fname+' '+E.Lname) as MgrFullName
from Employee E ,  Departments D
where E.SSN = D.MGRSSN
and E.SSN not in (select ESSN from Dependent)

--[6]
select  Dnum,Dname,count(*) AS EmployeeCount
from Departments D, Employee E
where D.Dnum = E.Dno
group by Dnum,Dname
having AVG(E.Salary) < (select AVG(Salary) from Employee)

--[7]

select (E.Fname+' '+E.Lname) as FullName , P.Pname
from Employee E , Works_for W , Project P 
where E.SSN = W.ESSn and P.Pnumber= W.Pno
order by E.Dno, E.Lname , E.Fname 

--[8]

select Salary
from Employee
where Salary in
				(select distinct Top (2) Salary
				   from Employee  
				   order by Salary desc
				)
--[9]


select * 
from Employee 
where (Fname+' '+Lname) in (select Dependent_name from Dependent)


--[10]


select 
    E.SSN,
    E.Fname + ' ' + E.Lname AS FullName
from 
    Employee as E
where 
     exists (
        select 1
        from Dependent as D
        where D.ESSN = E.SSN
    );



--[11]
insert into Departments values('DEPT IT',100,112233,'2006-11-1')

--[12]
  update Departments
  set MGRSSN=968574
  where Dnum=100

  update Departments
  set MGRSSN=102672
  where Dnum=20

  update  Employee
  set Superssn= 102672
  where SSN = 102660

  --[13]

update departments
set mgrssn = 102672
where mgrssn = 223344;


update employee
set superssn = 102672
where superssn = 223344;

update works_for
set essn = 102672
where essn = 223344;


delete from dependent
where essn = 223344;

delete from employee
where ssn = 223344;


  --[14]

update Employee
set Salary = Salary * 1.3
from Employee E , Works_for W , Project P 
where E.SSN = W.ESSn and P.Pnumber= W.Pno and P.Pname = 'Al Rabwah'
