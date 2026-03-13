using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Domain.Entities;
using System.Linq;

namespace ITI.Application.Services
{
    public class CourseSessionService(ICourseSessionRepository courseSessionRepository, ICourseRepository courseRepository, IInstractorRepository instractorRepository) : ICourseSessionService
    {
        private readonly ICourseSessionRepository courseSessionRepository = courseSessionRepository;
        private readonly ICourseRepository courseRepository = courseRepository;
        private readonly IInstractorRepository instractorRepository = instractorRepository;

        public IEnumerable<AllCourseSessionDto> GetAll()
        {
            var sessions = courseSessionRepository.GetAll().ToList();
            var courses = courseRepository.GetAll().ToDictionary(c => c.Id);
            var ins = instractorRepository.GetAll().ToDictionary(i => i.Id);

            return sessions.Select(s => new AllCourseSessionDto(
                s.Id,
                s.Title,
                s.Date,
                s.CourseId,
                s.InstractorId,
                courses.ContainsKey(s.CourseId) ? courses[s.CourseId].Name : null,
                ins.ContainsKey(s.InstractorId) ? $"{ins[s.InstractorId].FirstName} {ins[s.InstractorId].LastName}".Trim() : null
            )).ToList();
        }

        public AllCourseSessionDto? GetById(int id)
        {
            var s = courseSessionRepository.GetById(id);
            if (s == null) return null;
            var c = courseRepository.GetById(s.CourseId);
            var ins = instractorRepository.GetById(s.InstractorId);
            return new AllCourseSessionDto(s.Id, s.Title, s.Date, s.CourseId, s.InstractorId, c?.Name, ins == null ? null : $"{ins.FirstName} {ins.LastName}".Trim());
        }

        public void Add(CreateCourseSessionDto dto)
        {
            var s = new CourseSession { Date = dto.Date, Title = dto.Title, CourseId = dto.CourseId, InstractorId = dto.InstractorId };
            courseSessionRepository.Add(s);
        }

        public void Update(UpdateCourseSessionDto dto)
        {
            var s = courseSessionRepository.GetById(dto.Id);
            if (s == null) return;
            s.Date = dto.Date;
            s.Title = dto.Title;
            s.CourseId = dto.CourseId;
            s.InstractorId = dto.InstractorId;
            courseSessionRepository.Update(s);
        }

        public void Delete(int id)
        {
            courseSessionRepository.Delete(id);
        }
    }
}
