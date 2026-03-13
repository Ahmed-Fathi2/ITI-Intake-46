using WebService.DAL.Repositories.ProductRepository;

namespace WebService.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get;  }
        Task SaveAsync();
    }
}
