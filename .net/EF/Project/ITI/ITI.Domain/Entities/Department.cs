namespace ITI.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string? Location { get; set; }

        public int ManagerId { get; set; }
        public Instractor Instractor { get; set; } 

        public ICollection<Instractor> Instractors { get; set; } = new HashSet<Instractor>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
