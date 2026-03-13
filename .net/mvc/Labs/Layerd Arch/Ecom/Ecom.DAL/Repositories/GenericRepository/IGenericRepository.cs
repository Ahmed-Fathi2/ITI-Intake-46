using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.DAL.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Insert(T entity);
        void Delete(T entity);

        //void Update(T entity);  ---> Has A Problem of Update All Props even if Not Sent to update , set with default value





    }
}
