using Ecom.DAL.Repositories.GenericRepository;
using WebApplication2.Ecom.DAL.Models;

namespace WebApplication2.Ecom.DAL.Repositories.ProductRepository
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllWithCategories();

        Product? GetByIdWithCategory(int id);

        bool Any(string Name);

        //void Save();


    }
}
