using ITI.Application.Dtos;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Services
{
    public interface ICourseService
    {
        IEnumerable<AllCourseDto> GetAll();
        AllCourseDto? GetById(int id);
        void Add(CreateCourseDto dto);
        void Update(UpdateCourseDto dto);
        void Delete(int id);
    }
}
