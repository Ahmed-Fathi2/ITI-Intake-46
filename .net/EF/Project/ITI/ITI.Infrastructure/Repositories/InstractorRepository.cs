using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Infrastructure.Repositories
{
    public class InstractorRepository(AppDbContext dbContext) : IInstractorRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public IEnumerable<Instractor> GetAll()
        {
            return dbContext.Instractors.ToList();
        }

        public Instractor? GetById(int id)
        {
            return dbContext.Instractors.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Instractor instractor)
        {
            dbContext.Instractors.Add(instractor);
            dbContext.SaveChanges();
        }

        public void Update(Instractor instractor)
        {
            var exist = dbContext.Instractors.FirstOrDefault(x => x.Id == instractor.Id);
            if (exist == null) return;

            exist.FirstName = instractor.FirstName;
            exist.LastName = instractor.LastName;
            exist.Phone = instractor.Phone;
            exist.DepartmentId = instractor.DepartmentId;

            dbContext.Instractors.Update(exist);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Instractors.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;
            dbContext.Instractors.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
