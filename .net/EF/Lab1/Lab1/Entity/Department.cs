using System.ComponentModel.DataAnnotations;

namespace Lab1.Entity
{
    public class Department
    {
        public int Id { get; set; }

        [MinLength(2)]
        public string Name { get; set; }=string.Empty;


        public ICollection<Student> Students { get; set; } = new HashSet<Student>();


        public override string ToString()
        {
            return $"Id = {Id}  , Name = {Name}";
        }
    }
}
