namespace Lab2.Entity
{
    public class Student
    {
        public int StId { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; } 

        public string? Address { get; set; }
         public int? Age { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }


        public int? StSuper { get; set; }
        public Student? StudSuper { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<StudCourse> StudCourses { get; set; } = new HashSet<StudCourse>();

    }
}
