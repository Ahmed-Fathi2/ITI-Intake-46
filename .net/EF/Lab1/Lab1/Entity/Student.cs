using System.ComponentModel.DataAnnotations;

namespace Lab1.Entity
{
    public class Student
    {

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }=string.Empty;
        public int Age { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; } = default!;


        public override string ToString()
        {
            return $"Id = {Id} , Name = {Name}  , Age = {Age} , DepartmentId = {DepartmentId} ";
        }
    }
}
