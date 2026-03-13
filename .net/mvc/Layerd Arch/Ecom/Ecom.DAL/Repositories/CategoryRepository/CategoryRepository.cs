using Ecom.DAL.Repositories.GenericRepository;
using WebApplication2.Data;
using WebApplication2.Ecom.DAL.Models;

namespace WebApplication2.Ecom.DAL.Repositories.CategoryRepository
{
    public class CategoryRepository :GenericRepository<Category>,ICategoryRepository
    {
      
        public CategoryRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
