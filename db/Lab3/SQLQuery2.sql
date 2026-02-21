
select D.Dnum,D.Dname,E.SSN,E.Fname+''+E.Lname As FullName
from Departments D , Employee E
where  E.SSN= D.MGRSSN
  


select D.Dname,P.Pname
from Departments D , Project P
where D.Dnum=P.Dnum



select * 
from Employee E , [Dependent] D
where E.SSN = D.ESSN




select Pnumber,Pname , Plocation
from Project  
where City in ('Cairo' , 'Alex')



select Pnumber,Pname , Plocation, City, Dnum As DepartmentNumber
from Project  
where Pname like 'a%'



SELECT *
  FROM Employee
  where Dno = 30 and Salary between 1000 and 2000


 SELECT DISTINCT (E.Fname + ' ' + E.Lname) AS FullName
	FROM Employee E
	JOIN Works_for W ON E.SSN = W.ESSn
	JOIN Project P ON W.Pno = P.Pnumber
	WHERE E.Dno = 10
	  AND P.Pname = 'AL Rabwah'
	  AND W.Hours >= 10;


SELECT *  
  FROM Employee X , Employee Y 
  where Y.SSN = X.Superssn 
  and Y.Fname like 'Kamel' 
  and Y.Lname like 'Mohamed'



  SELECT (E.Fname + ' ' + E.Lname) AS EmployeeFullName , P.Pname
  FROM Employee E , Project  P, Works_for W
  where E.SSN = W.ESSn and P.Pnumber = W.Pno
  order by p.Pname




  select P.Pnumber , D.Dname , E.Lname,E.Address , E.Bdate
  from Project P, Departments D ,Employee E
  where D.Dnum = P.Dnum 
  and E.SSN = D.MGRSSN
  and P.City like 'Cairo'


SELECT E.*
FROM Employee E , Departments D
where  E.SSN = D.Mgrssn



  select * 
  from Employee E left outer join Dependent D
  on  E.SSN = D.ESSN


  INSERT INTO Employee 
(Fname, Lname, SSN, Bdate, Address, Sex, Salary, Superssn, Dno)
VALUES 
('Ahmed', 'Fathy', 102672, '2001-07-10', 'Cairo', 'M', 3000, 112233, 30);



INSERT INTO Employee (Fname, Lname, SSN, Bdate, Address, Sex, Dno)
VALUES ('Omar', 'Ali', 102660, '2000-05-15', 'Cairo', 'M', 30);


UPDATE Employee
SET Salary = Salary * 1.2
WHERE SSN = 102672;

