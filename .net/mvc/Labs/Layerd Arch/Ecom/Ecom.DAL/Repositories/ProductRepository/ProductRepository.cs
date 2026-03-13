using Ecom.DAL.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Ecom.DAL.Models;

namespace WebApplication2.Ecom.DAL.Repositories.ProductRepository
{
    public class ProductRepository :GenericRepository<Product>,IProductRepository
    {
        

        public ProductRepository(AppDbContext dbContext):base(dbContext)
        {

        }
        

        public IEnumerable<Product> GetAllWithCategories()
        {
            return _dbContext.Products.Include(x => x.Category);

        }

        public Product? GetByIdWithCategory(int id)
        {
            var product = _dbContext.Products
                            .Include(x => x.Category)
                            .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public bool Any(string Name)
        {
            return _dbContext.Products.Any(x => x.Name == Name);
        }
       
    }
}
