using ITI.Domain.Entities;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();
        public Department? GetById(int id);
        public void Add(Department department);
        public void Update(Department department);
        public void Delete(int id);
    }
}
