using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD46CSD06
{
    public class Employee:IComparable,ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        public object Clone()
        {
            return new Employee 
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                Salary = this.Salary,
                DeptId = this.DeptId
            };
        }

        public int CompareTo(object? obj)
        {
            //this
            //obj
            var right=obj as Employee;
            return this.Name.CompareTo(right.Name);
            //return this.Age.CompareTo(right.Age);
        }


        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{Salary}:{DeptId}";
        }
    }
}
