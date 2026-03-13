using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Ecom.DAL.Repositories.CategoryRepository;
using WebApplication2.Ecom.DAL.Repositories.ProductRepository;

namespace Ecom.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        void Save();
    }
}
