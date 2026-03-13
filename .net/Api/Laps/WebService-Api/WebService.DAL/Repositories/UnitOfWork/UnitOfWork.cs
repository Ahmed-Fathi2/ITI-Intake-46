using WebService.DAL.Repositories.ProductRepository;

namespace WebService.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IProductRepository ProductRepository { get ;  }

        public UnitOfWork(AppDbContext dbContext , IProductRepository productRepository )
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
        }


        public async Task SaveAsync()
        {
             await _dbContext.SaveChangesAsync();
        }
    }
}
