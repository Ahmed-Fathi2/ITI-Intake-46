using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Data
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int DurationMinutes { get; set; } = 60; // Default 1 hour

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
    }
}