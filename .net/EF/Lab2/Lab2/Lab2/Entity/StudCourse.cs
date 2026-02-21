using Lab2.Entity;

namespace Lab2.Entity
{
    public class StudCourse
    {

        public int CrsId { get; set; }

        public int StId { get; set; }

        public int? Grade { get; set; }


        public Student Student { get; set; } = default!;

        public Course Course { get; set; }=default!;



    }
}

