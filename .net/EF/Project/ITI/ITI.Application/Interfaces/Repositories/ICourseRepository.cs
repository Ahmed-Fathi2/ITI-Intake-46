using ITI.Domain.Entities;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
    }
}
