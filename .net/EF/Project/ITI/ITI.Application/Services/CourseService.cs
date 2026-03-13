using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Domain.Entities;
using System.Linq;

namespace ITI.Application.Services
{
    public class CourseService(ICourseRepository courseRepository, IInstractorRepository instractorRepository, IDepartmentRepository departmentRepository) : ICourseService
    {
        private readonly ICourseRepository courseRepository = courseRepository;
        private readonly IInstractorRepository instractorRepository = instractorRepository;
        private readonly IDepartmentRepository departmentRepository = departmentRepository;

        public IEnumerable<AllCourseDto> GetAll()
        {
            var courses = courseRepository.GetAll().ToList();
            var instractors = instractorRepository.GetAll().ToDictionary(i => i.Id);
            var depts = departmentRepository.GetAll().ToDictionary(d => d.Id);

            return courses.Select(c => new AllCourseDto(
                c.Id,
                c.Name,
                c.Duration,
                c.InstractorId,
                c.DepartmentId,
                instractors.ContainsKey(c.InstractorId) ? $"{instractors[c.InstractorId].FirstName} {instractors[c.InstractorId].LastName}".Trim() : null,
                depts.ContainsKey(c.DepartmentId) ? depts[c.DepartmentId].Name : null
            )).ToList();
        }

        public AllCourseDto? GetById(int id)
        {
            var c = courseRepository.GetById(id);
            if (c == null) return null;
            var ins = instractorRepository.GetById(c.InstractorId);
            var dep = departmentRepository.GetById(c.DepartmentId);
            return new AllCourseDto(c.Id, c.Name, c.Duration, c.InstractorId, c.DepartmentId, ins == null ? null : $"{ins.FirstName} {ins.LastName}".Trim(), dep?.Name);
        }

        public void Add(CreateCourseDto dto)
        {
            var c = new Course { Name = dto.Name, Duration = dto.Duration, InstractorId = dto.InstractorId, DepartmentId = dto.DepartmentId };
            courseRepository.Add(c);
        }

        public void Update(UpdateCourseDto dto)
        {
            var c = courseRepository.GetById(dto.Id);
            if (c == null) return;
            c.Name = dto.Name;
            c.Duration = dto.Duration;
            c.InstractorId = dto.InstractorId;
            c.DepartmentId = dto.DepartmentId;
            courseRepository.Update(c);
        }

        public void Delete(int id)
        {
            courseRepository.Delete(id);
        }
    }
}
