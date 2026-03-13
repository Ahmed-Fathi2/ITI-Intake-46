using ITI.Domain.Entities;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Repositories
{
    public interface ICourseSessionRepository
    {
        IEnumerable<CourseSession> GetAll();
        CourseSession? GetById(int id);
        void Add(CourseSession session);
        void Update(CourseSession session);
        void Delete(int id);
    }
}
