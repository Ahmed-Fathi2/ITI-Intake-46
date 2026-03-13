using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Infrastructure.Repositories
{
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public IEnumerable<Department> GetAll()
        {
            return dbContext.Departments.ToList();
        }

        public Department? GetById(int id)
        {
            return dbContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Department department)
        {
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
        }

        public void Update(Department department)
        {
            var exist = dbContext.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (exist == null) return;

            exist.Name = department.Name;
            exist.Location = department.Location;
            exist.ManagerId = department.ManagerId;

            dbContext.Departments.Update(exist);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Departments.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            // Check for related entities that reference this department
            var instractorCount = dbContext.Instractors.Count(i => i.DepartmentId == id);
            var courseCount = dbContext.Courses.Count(c => c.DepartmentId == id);

            if (instractorCount > 0 || courseCount > 0)
            {
                throw new InvalidOperationException($"Cannot delete department because it has {instractorCount} instructor(s) and {courseCount} course(s) related to it. Remove related entities first.");
            }

            dbContext.Departments.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
