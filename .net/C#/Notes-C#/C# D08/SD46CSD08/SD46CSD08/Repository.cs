using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD08
{
    public static class Repository
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>() 
        {
            new Employee{Id=1,Name="Ziad",Age=25,Salary=1234,DeptId=10},
            new Employee{Id=2,Name="Sara",Age=26,Salary=2234,DeptId=20},
            new Employee{Id=3,Name="Ahmed",Age=27,Salary=3234,DeptId=30},
            new Employee{Id=4,Name="Mohamed",Age=28,Salary=4234,DeptId=20},
            new Employee{Id=5,Name="Ibrahim",Age=29,Salary=5234,DeptId=20},
            new Employee{Id=6,Name="Osama",Age=30,Salary=6234,DeptId=10},
            new Employee{Id=7,Name="Aalaa",Age=31,Salary=7234,DeptId=10},
            new Employee{Id=8,Name="Reem",Age=24,Salary=8234,DeptId=20},
            new Employee{Id=9,Name="Waleed",Age=23,Salary=9234,DeptId=30},
            new Employee{Id=10,Name="Bassel",Age=22,Salary=10234,DeptId=10},
        };
    }
}
