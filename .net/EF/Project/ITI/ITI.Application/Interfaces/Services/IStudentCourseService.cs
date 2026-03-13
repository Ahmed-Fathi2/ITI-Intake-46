using ITI.Application.Dtos;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Services
{
    public interface IStudentCourseService
    {
        IEnumerable<AllStudentCourseDto> GetAll();
        AllStudentCourseDto? GetByKeys(int studentId, int courseId);
        void Add(CreateStudentCourseDto dto);
        void Delete(int studentId, int courseId);
    }
}
