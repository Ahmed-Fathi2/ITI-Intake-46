SELECT * FROM Employee;

SELECT Fname, Lname, Salary, Dno FROM Employee;

SELECT Pname, Plocation, Dnum FROM Project;

SELECT Fname + ' ' + Lname AS FullName, (Salary * 12 * 0.1) AS ANNUAL_COMM FROM Employee;

SELECT SSN, Fname + ' ' + Lname AS FullName FROM Employee WHERE Salary > 1000;

SELECT SSN, Fname + ' ' + Lname AS FullName FROM Employee WHERE (Salary * 12) > 10000;

SELECT Fname, Lname, Salary FROM Employee WHERE Sex = 'F';

SELECT Dnum, Dname FROM Departments WHERE MGRSSN = 968574;

SELECT Pnumber, Pname, Plocation FROM Project WHERE Dnum = 10;