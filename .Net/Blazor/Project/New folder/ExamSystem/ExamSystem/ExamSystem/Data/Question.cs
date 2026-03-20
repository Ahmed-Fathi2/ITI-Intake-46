using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Data
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        public int Order { get; set; } // For ordering questions

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
    }
}