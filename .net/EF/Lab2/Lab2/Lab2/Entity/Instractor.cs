using Lab2.Entity;

namespace Lab2.Entity
{
    public class Instractor
    {
        public int InsId { get; set; }
        public string? InsName { get; set; }
        public string? InsDegree { get; set; }
        public decimal? Salary { get; set; }

        //BelongsTo
        public int? DeptId { get; set; }
        public Department? Department { get; set; }

        //manage
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();


        public ICollection<InstCourse> instCourses { get; set; } = new HashSet<InstCourse>();
    }
}

