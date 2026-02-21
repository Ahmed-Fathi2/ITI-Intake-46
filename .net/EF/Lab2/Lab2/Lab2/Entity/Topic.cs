namespace Lab2.Entity
{
    public class Topic
    {
        public int TopId { get; set; }
        public string? TopName { get; set; }

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
