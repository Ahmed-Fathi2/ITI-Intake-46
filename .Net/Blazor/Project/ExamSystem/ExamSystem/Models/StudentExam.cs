namespace ExamSystem.Models
{
    public class StudentExam
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public int ExamId { get; set; }
        public int Score { get; set; }
        public DateTime SubmittedAt { get; set; }

        public ApplicationUser? Student { get; set; }
        public Exam? Exam { get; set; }
    }
}
