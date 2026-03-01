namespace ITI.Domain.Entities
{
    public class Instractor
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        //belongs to one department
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;

        // May manage one Dept or Not
        public Department? MangedDepartment { get; set; } 

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<CourseSession> CourseSessions { get; set; } = new HashSet<CourseSession>();
    }
}
