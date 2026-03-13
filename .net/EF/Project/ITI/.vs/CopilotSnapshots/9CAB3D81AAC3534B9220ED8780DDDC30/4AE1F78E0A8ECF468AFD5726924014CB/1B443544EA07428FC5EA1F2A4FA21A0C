using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Domain.Entities;

namespace ITI.Application.Services
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        private readonly IStudentRepository studentRepository = studentRepository;

      
        public IEnumerable<AllStudentDto> GetAll()
        {
            var students = studentRepository.GetAll().Select(x => new AllStudentDto(
                      Id:x.Id,
                      FirstName: x.FirstName,
                      LastName: x.LastName,
                      Phone: x.Phone
                )).ToList();

            return students;
        }

        public void Add(CreateStudentDto createStudentDto)
        {

            var student = new Student
            {
                FirstName = createStudentDto.FirstName,
                LastName = createStudentDto.LastName,
                Phone = createStudentDto.Phone
            };

            studentRepository.Add(student);

        
           
        }

        public AllStudentDto? GetById(int id)
        {
            var student = studentRepository.GetById(id);

            if(student == null)
            {
                return null;
            }

            var studentDto = new AllStudentDto(
                Id: student.Id,
                FirstName: student.FirstName,
                LastName: student.LastName,
                Phone: student.Phone
                );

            return studentDto;
        }
    }

}
