using ITI.Domain.Entities;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Repositories
{
    public interface IStudentCourseRepository
    {
        IEnumerable<StudentCourse> GetAll();
        StudentCourse? GetByKeys(int studentId, int courseId);
        void Add(StudentCourse studentCourse);
        void Delete(int studentId, int courseId);
    }
}
