using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Repositories.ProductRepository
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public IEnumerable<Product> GetAll()
        {
         return _dbContext.Products.Include(x => x.Category);

        }

        public Product? GetById(int id)
        {
           var product= _dbContext.Products
                           .Include(x => x.Category)
                           .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public void Insert(Product product)
        {
            _dbContext.Add(product);
        }
        public void Delete(Product product)
        {
            _dbContext.Remove(product);
        }


        public bool Any(string Name)
        {
        return  _dbContext.Products.Any(x => x.Name == Name);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
