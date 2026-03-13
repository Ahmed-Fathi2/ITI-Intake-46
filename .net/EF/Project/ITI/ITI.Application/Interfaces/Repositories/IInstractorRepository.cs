using ITI.Domain.Entities;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Repositories
{
    public interface IInstractorRepository
    {
        IEnumerable<Instractor> GetAll();
        Instractor? GetById(int id);
        void Add(Instractor instractor);
        void Update(Instractor instractor);
        void Delete(int id);
    }
}
