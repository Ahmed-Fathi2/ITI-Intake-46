using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD07
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Employee employee &&
                   Id == employee.Id &&
                   Name == employee.Name &&
                   Age == employee.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Age);
        }


        //public override bool Equals(object? obj)
        //{
        //    var right=obj as Employee;
        //    return this.Id==right.Id&& this.Name==right.Name&& this.Age==right.Age;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Id,Name,Age);
        //}


        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}";
        }

        public static bool operator ==(Employee? left, Employee? right)
        {
            return EqualityComparer<Employee>.Default.Equals(left, right);
        }

        public static bool operator !=(Employee? left, Employee? right)
        {
            return !(left == right);
        }
    }
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    } 


    /////////////////////////////////////////////
    

    record Person(int id,string name,int age);


}
