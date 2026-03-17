namespace ExamSystem.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Text { get; set; } = string.Empty;

        public Exam? Exam { get; set; }
        public List<Answer>? Answers { get; set; }
    }
}
