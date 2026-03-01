namespace ITI.Domain.Entities
{
    public class CourseSessionAttendance
    {
        public int Id { get; set; }
        public int? Grade { get; set; }
        public string? Notes { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;

        public int CourseSessionId { get; set; }
        public CourseSession CourseSession { get; set; } = default!;
    }
}
