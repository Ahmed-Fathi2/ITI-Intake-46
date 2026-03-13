using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Data;
using WebApplication2.Ecom.DAL.Repositories.CategoryRepository;
using WebApplication2.Ecom.DAL.Repositories.ProductRepository;

namespace Ecom.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IProductRepository ProductRepository { get;}
        public ICategoryRepository CategoryRepository { get;}

        public UnitOfWork(AppDbContext dbContext, 
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)

        {
            _dbContext = dbContext;

            ProductRepository = productRepository;
            
            CategoryRepository = categoryRepository;
        }

   

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

// data inconsistancy 
// db trips
// multi injection 
