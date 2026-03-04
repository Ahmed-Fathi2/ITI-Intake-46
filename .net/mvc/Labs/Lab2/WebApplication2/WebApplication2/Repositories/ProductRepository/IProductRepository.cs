using WebApplication2.Entities;

namespace WebApplication2.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product? GetById(int id);

        void Insert(Product product);

        void Delete(Product product);
        bool Any(string Name);

        void Save();


    }
}
