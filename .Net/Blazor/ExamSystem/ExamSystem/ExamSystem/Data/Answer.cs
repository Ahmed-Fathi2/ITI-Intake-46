using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Data
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        public bool IsCorrect { get; set; }
    }
}