using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Domain.Entities;
using System.Linq;

namespace ITI.Application.Services
{
    public class CourseSessionAttendanceService(ICourseSessionAttendanceRepository attendanceRepository, IStudentRepository studentRepository, ICourseSessionRepository courseSessionRepository) : ICourseSessionAttendanceService
    {
        private readonly ICourseSessionAttendanceRepository attendanceRepository = attendanceRepository;
        private readonly IStudentRepository studentRepository = studentRepository;
        private readonly ICourseSessionRepository courseSessionRepository = courseSessionRepository;

        public IEnumerable<AllCourseSessionAttendanceDto> GetAll()
        {
            var list = attendanceRepository.GetAll().ToList();
            var students = studentRepository.GetAll().ToDictionary(s => s.Id);
            var sessions = courseSessionRepository.GetAll().ToDictionary(s => s.Id);

            return list.Select(a => new AllCourseSessionAttendanceDto(
                a.Id,
                a.Grade,
                a.Notes,
                a.StudentId,
                a.CourseSessionId,
                students.ContainsKey(a.StudentId) ? $"{students[a.StudentId].FirstName} {students[a.StudentId].LastName}".Trim() : null,
                sessions.ContainsKey(a.CourseSessionId) ? sessions[a.CourseSessionId].Title : null
            )).ToList();
        }

        public AllCourseSessionAttendanceDto? GetById(int id)
        {
            var a = attendanceRepository.GetById(id);
            if (a == null) return null;
            var s = studentRepository.GetById(a.StudentId);
            var cs = courseSessionRepository.GetById(a.CourseSessionId);
            return new AllCourseSessionAttendanceDto(a.Id, a.Grade, a.Notes, a.StudentId, a.CourseSessionId, s == null ? null : $"{s.FirstName} {s.LastName}".Trim(), cs?.Title);
        }

        public void Add(CreateCourseSessionAttendanceDto dto)
        {
            var a = new CourseSessionAttendance { Grade = dto.Grade, Notes = dto.Notes, StudentId = dto.StudentId, CourseSessionId = dto.CourseSessionId };
            attendanceRepository.Add(a);
        }

        public void Update(UpdateCourseSessionAttendanceDto dto)
        {
            var a = attendanceRepository.GetById(dto.Id);
            if (a == null) return;
            a.Grade = dto.Grade;
            a.Notes = dto.Notes;
            a.StudentId = dto.StudentId;
            a.CourseSessionId = dto.CourseSessionId;
            attendanceRepository.Update(a);
        }

        public void Delete(int id)
        {
            attendanceRepository.Delete(id);
        }
    }
}
