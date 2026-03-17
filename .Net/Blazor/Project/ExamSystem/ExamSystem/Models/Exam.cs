namespace ExamSystem.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Title { get; set; } = string.Empty;

        public Subject? Subject { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
