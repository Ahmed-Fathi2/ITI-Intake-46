using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return  _dbContext.Categories;
        }

        public Category? GetById(int id)
        {
           var category= _dbContext.Categories
                         .FirstOrDefault(x => x.Id == id);

            return category;
        }

        public void Insert(Category category)
        {
            _dbContext.Add(category);
        }

        public void Delete(Category category)
        {

            _dbContext.Remove(category);
        }
        public void Save()
        {
             _dbContext.SaveChanges();
        }
    }
}
