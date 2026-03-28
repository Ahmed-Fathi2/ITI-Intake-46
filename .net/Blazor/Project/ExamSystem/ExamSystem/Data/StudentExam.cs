using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Data
{
    public class StudentExam
    {
        public int Id { get; set; }

        public string StudentId { get; set; } = string.Empty;
        public ApplicationUser? Student { get; set; }

        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? SubmittedAt { get; set; }

        public int Score { get; set; } // Number of correct answers
        public int TotalQuestions { get; set; }
        public double Percentage => TotalQuestions > 0 ? (double)Score / TotalQuestions * 100 : 0;

        public bool IsCompleted => SubmittedAt.HasValue;

        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
    }
}