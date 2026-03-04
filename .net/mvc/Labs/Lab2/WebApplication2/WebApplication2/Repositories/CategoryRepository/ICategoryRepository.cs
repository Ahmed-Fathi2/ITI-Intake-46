using WebApplication2.Entities;

namespace WebApplication2.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {

        IEnumerable<Category> GetAll();

        Category? GetById(int id);

        void Insert(Category product);

        void Delete(Category product);
        //bool Any(string Name);

        void Save();
    }
}
