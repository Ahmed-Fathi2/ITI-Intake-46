using Lab2.Entity;

namespace Lab2.Entity
{
    public class Course
    {

        public int CrsId { get; set; }
        public string? CrsName { get; set; }
        public int? CrsDuration { get; set; }
        public int? TopId { get; set; }
        public Topic? Topic { get; set; }

        public ICollection<StudCourse> StudCourses { get; set; } = new HashSet<StudCourse>();

        public ICollection<InstCourse> instCourses { get; set; } = new HashSet<InstCourse>();

    }
}
