using Microsoft.EntityFrameworkCore;
using WebService.DAL.Repositories.GenericRepository;

namespace WebService.DAL.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }

        public  async Task<IQueryable<Product>> GetAllProducts()
        {
            var products= _dbContext.Products.Include(x=>x.Category).AsQueryable();
            return products;
        }

        public async Task<Product?> GetProductByCategoryAsync(int id)
        {
            var product=  await _dbContext.Products
                    .Include(c=>c.Category)
                    .FirstOrDefaultAsync(p => p.Id == id);

            if(product is not null)
            {
                return product;
            }
            return null;
        }
    }
}
