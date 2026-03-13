using ITI.Domain.Entities;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Repositories
{
    public interface ICourseSessionAttendanceRepository
    {
        IEnumerable<CourseSessionAttendance> GetAll();
        CourseSessionAttendance? GetById(int id);
        void Add(CourseSessionAttendance attendance);
        void Update(CourseSessionAttendance attendance);
        void Delete(int id);
    }
}
