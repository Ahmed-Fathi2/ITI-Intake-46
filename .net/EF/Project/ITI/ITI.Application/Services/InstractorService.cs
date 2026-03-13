using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Domain.Entities;
using System.Linq;

namespace ITI.Application.Services
{
    public class InstractorService(IInstractorRepository instractorRepository) : IInstractorService
    {
        private readonly IInstractorRepository instractorRepository = instractorRepository;

        public IEnumerable<AllInstractorDto> GetAll()
        {
            return instractorRepository.GetAll().Select(x => new AllInstractorDto(x.Id, x.FirstName, x.LastName, x.Phone, x.DepartmentId)).ToList();
        }

        public AllInstractorDto? GetById(int id)
        {
            var ins = instractorRepository.GetById(id);
            if (ins == null) return null;
            return new AllInstractorDto(ins.Id, ins.FirstName, ins.LastName, ins.Phone, ins.DepartmentId);
        }

        public void Add(CreateInstractorDto dto)
        {
            var entity = new Instractor { FirstName = dto.FirstName, LastName = dto.LastName, Phone = dto.Phone, DepartmentId = dto.DepartmentId };
            instractorRepository.Add(entity);
        }

        public void Update(UpdateInstractorDto dto)
        {
            var entity = instractorRepository.GetById(dto.Id);
            if (entity == null) return;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Phone = dto.Phone;
            entity.DepartmentId = dto.DepartmentId;
            instractorRepository.Update(entity);
        }

        public void Delete(int id)
        {
            instractorRepository.Delete(id);
        }
    }
}
