namespace ITI.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Duration { get; set; }


        public int InstractorId { get; set; }
        public Instractor Instractor { get; set; } = default!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;


        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<CourseSession> CourseSessions { get; set; } = new HashSet<CourseSession>();

    }
}
