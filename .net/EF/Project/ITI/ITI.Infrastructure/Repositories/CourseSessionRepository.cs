using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace ITI.Infrastructure.Repositories
{
    public class CourseSessionRepository(AppDbContext dbContext) : ICourseSessionRepository
    {
        private readonly AppDbContext dbContext = dbContext;

        public IEnumerable<CourseSession> GetAll()
        {
            return dbContext.CourseSessions.ToList();
        }

        public CourseSession? GetById(int id)
        {
            return dbContext.CourseSessions.FirstOrDefault(x => x.Id == id);
        }

        public void Add(CourseSession session)
        {
            dbContext.CourseSessions.Add(session);
            dbContext.SaveChanges();
        }

        public void Update(CourseSession session)
        {
            var exist = dbContext.CourseSessions.FirstOrDefault(x => x.Id == session.Id);
            if (exist == null) return;

            exist.Date = session.Date;
            exist.Title = session.Title;
            exist.CourseId = session.CourseId;
            exist.InstractorId = session.InstractorId;

            dbContext.CourseSessions.Update(exist);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.CourseSessions.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;
            dbContext.CourseSessions.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
