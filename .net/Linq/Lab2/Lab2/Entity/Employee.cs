namespace Lab2.Entity
{
   public class Employee
    {
       
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public int DeptId { get; set; }

        public Department Department { get; set; } = default!;

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary}, DeptId: {DeptId}";
        }
      
    }
}
