namespace ExamSystem.Data
{
    public class StudentAnswer
    {
        public int Id { get; set; }

        public int StudentExamId { get; set; }
        public StudentExam? StudentExam { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        public int SelectedAnswerId { get; set; }
        public Answer? SelectedAnswer { get; set; }

        public bool IsCorrect => SelectedAnswer?.IsCorrect ?? false;
    }
}