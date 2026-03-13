using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Infrastructure.Repositories
{
    public class CourseRepository(AppDbContext dbContext) : ICourseRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public IEnumerable<Course> GetAll()
        {
            return dbContext.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return dbContext.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
        }

        public void Update(Course course)
        {
            var exist = dbContext.Courses.FirstOrDefault(x => x.Id == course.Id);
            if (exist == null) return;

            exist.Name = course.Name;
            exist.Duration = course.Duration;
            exist.InstractorId = course.InstractorId;
            exist.DepartmentId = course.DepartmentId;

            dbContext.Courses.Update(exist);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Courses.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;
            dbContext.Courses.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
