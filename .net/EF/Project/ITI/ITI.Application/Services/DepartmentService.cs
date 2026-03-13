using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Domain.Entities;

namespace ITI.Application.Services
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository = departmentRepository;

        public IEnumerable<AllDepartmentDto> GetAll()
        {
            return departmentRepository.GetAll().Select(x => new AllDepartmentDto(x.Id, x.Name, x.Location, x.ManagerId)).ToList();
        }

        public AllDepartmentDto? GetById(int id)
        {
            var d = departmentRepository.GetById(id);
            if (d == null) return null;
            return new AllDepartmentDto(d.Id, d.Name, d.Location, d.ManagerId);
        }

        public void Add(CreateDepartmentDto createDepartmentDto)
        {
            var dept = new Department { Name = createDepartmentDto.Name, Location = createDepartmentDto.Location, ManagerId = createDepartmentDto.ManagerId };
            departmentRepository.Add(dept);
        }

        public void Update(UpdateDepartmentDto updateDepartmentDto)
        {
            var dept = departmentRepository.GetById(updateDepartmentDto.Id);
            if (dept == null) return;
            dept.Name = updateDepartmentDto.Name;
            dept.Location = updateDepartmentDto.Location;
            dept.ManagerId = updateDepartmentDto.ManagerId;
            departmentRepository.Update(dept);
        }

        public void Delete(int id)
        {
            departmentRepository.Delete(id);
        }
    }
}
