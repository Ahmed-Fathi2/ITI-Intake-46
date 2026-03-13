using ITI.Application.Dtos;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Services
{
    public interface ICourseSessionAttendanceService
    {
        IEnumerable<AllCourseSessionAttendanceDto> GetAll();
        AllCourseSessionAttendanceDto? GetById(int id);
        void Add(CreateCourseSessionAttendanceDto dto);
        void Update(UpdateCourseSessionAttendanceDto dto);
        void Delete(int id);
    }
}
