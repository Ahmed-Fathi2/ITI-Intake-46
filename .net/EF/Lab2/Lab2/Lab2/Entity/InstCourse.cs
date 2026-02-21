using Lab2.Entity;

namespace Lab2.Entity
{
    public class InstCourse
    {

        public int InsId { get; set; }

        public int CrsId { get; set; }

        public string? Evaluation { get; set; }


        public Instractor Instractor { get; set; } = default!;

        public Course Course { get; set; } = default!;
    }
}
