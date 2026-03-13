using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Infrastructure.Repositories
{
    public class StudentCourseRepository(AppDbContext dbContext) : IStudentCourseRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public IEnumerable<StudentCourse> GetAll()
        {
            return dbContext.StudentCourses.ToList();
        }

        public StudentCourse? GetByKeys(int studentId, int courseId)
        {
            return dbContext.StudentCourses.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
        }

        public void Add(StudentCourse studentCourse)
        {
            dbContext.StudentCourses.Add(studentCourse);
            dbContext.SaveChanges();
        }

        public void Delete(int studentId, int courseId)
        {
            var entity = dbContext.StudentCourses.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
            if (entity == null) return;
            dbContext.StudentCourses.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
