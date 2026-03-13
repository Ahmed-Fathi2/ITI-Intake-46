using ITI.Application.Dtos;
using System.Collections.Generic;

namespace ITI.Application.Interfaces.Services
{
    public interface IInstractorService
    {
        IEnumerable<AllInstractorDto> GetAll();
        AllInstractorDto? GetById(int id);
        void Add(CreateInstractorDto dto);
        void Update(UpdateInstractorDto dto);
        void Delete(int id);
    }
}
