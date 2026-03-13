using ITI.Application.Dtos;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        public IEnumerable<AllDepartmentDto> GetAll();
        public AllDepartmentDto? GetById(int id);
        public void Add(CreateDepartmentDto createDepartmentDto);
        public void Update(UpdateDepartmentDto updateDepartmentDto);
        public void Delete(int id);
    }
}
