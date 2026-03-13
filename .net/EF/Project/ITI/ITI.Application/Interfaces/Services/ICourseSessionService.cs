using ITI.Application.Dtos;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Services
{
    public interface ICourseSessionService
    {
        IEnumerable<AllCourseSessionDto> GetAll();
        AllCourseSessionDto? GetById(int id);
        void Add(CreateCourseSessionDto dto);
        void Update(UpdateCourseSessionDto dto);
        void Delete(int id);
    }
}
