using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Infrastructure.Repositories
{
    public class CourseSessionAttendanceRepository(AppDbContext dbContext) : ICourseSessionAttendanceRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public IEnumerable<CourseSessionAttendance> GetAll()
        {
            return dbContext.CourseSessionAttendances.ToList();
        }

        public CourseSessionAttendance? GetById(int id)
        {
            return dbContext.CourseSessionAttendances.FirstOrDefault(x => x.Id == id);
        }

        public void Add(CourseSessionAttendance attendance)
        {
            dbContext.CourseSessionAttendances.Add(attendance);
            dbContext.SaveChanges();
        }

        public void Update(CourseSessionAttendance attendance)
        {
            var exist = dbContext.CourseSessionAttendances.FirstOrDefault(x => x.Id == attendance.Id);
            if (exist == null) return;

            exist.Grade = attendance.Grade;
            exist.Notes = attendance.Notes;
            exist.StudentId = attendance.StudentId;
            exist.CourseSessionId = attendance.CourseSessionId;

            dbContext.CourseSessionAttendances.Update(exist);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.CourseSessionAttendances.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;
            dbContext.CourseSessionAttendances.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
