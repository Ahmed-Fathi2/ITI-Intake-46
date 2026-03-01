namespace ITI.Domain.Entities
{
    public class CourseSession
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Title { get; set; }



        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public int InstractorId { get; set; }
        public Instractor Instractor { get; set; } = default!;

        public ICollection<CourseSessionAttendance> CourseSessionAttendances { get; set; } = new HashSet<CourseSessionAttendance>();
    }
}
