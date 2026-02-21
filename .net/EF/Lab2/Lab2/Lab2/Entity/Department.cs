using Lab2.Entity;

namespace Lab2.Entity
{
    public class Department
    {

        public int DeptId { get; set; }
        public string? DeptName { get; set; }
        public string? DeptDesc { get; set; }
        public string? DeptLocation { get; set; }
        public DateOnly? ManagerHireDate { get; set; }

        // ManagedBy
        public int? DeptManager { get; set; } // forgein key
        public Instractor? Instractor { get; set; }


        public ICollection<Student> Students { get; set; } = new HashSet<Student>();


        //Include
        public ICollection<Instractor> Instractors { get; set; } = new HashSet<Instractor>();
    }
}

