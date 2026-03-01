namespace WebApplication2.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }

        public int CategoryId { get; set; }


        public string? ImageUrl { get; set; }

        public Category Category { get; set; } = default!;
    }
}
