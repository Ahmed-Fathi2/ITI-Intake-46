using WebService.DAL.Repositories.GenericRepository;

namespace WebService.DAL.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        Task<Product?> GetProductByCategoryAsync(int id);

        Task<IQueryable<Product>> GetAllProducts();
    }
}
