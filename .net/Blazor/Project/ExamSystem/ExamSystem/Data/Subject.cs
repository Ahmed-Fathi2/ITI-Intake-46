using System.ComponentModel.DataAnnotations;

namespace ExamSystem.Data
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}