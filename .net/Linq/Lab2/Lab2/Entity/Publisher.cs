namespace Lab2.Entity
{
    public class Publisher
    {
        public String Name { get; set; }
        public String WebSite { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
