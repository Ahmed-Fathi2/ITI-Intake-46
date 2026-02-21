namespace Lab2.Entity
{
    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;

        public List<Subject> subjects { get; set; } = default!;

    }
}
