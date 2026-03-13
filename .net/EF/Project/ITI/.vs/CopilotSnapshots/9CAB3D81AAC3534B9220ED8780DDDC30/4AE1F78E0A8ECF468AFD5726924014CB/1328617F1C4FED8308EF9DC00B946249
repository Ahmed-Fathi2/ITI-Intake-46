using ITI.Application.Dtos;
using ITI.Application.Interfaces.Repositories;
using ITI.Domain.Entities;
using ITI.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Infrastructure.Repositories
{
    public class StudentRepository(AppDbContext dbContext) : IStudentRepository
    {
        private readonly AppDbContext dbContext = dbContext;


        public IEnumerable<Student> GetAll()
        {
            
            return  dbContext.Students.ToList();
        }
        public void Add(Student student)
        {
            dbContext.Students.Add(student);
          var x =  dbContext.SaveChanges();
        }

        public Student? GetById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.Id == id);

            if(student == null)
            {
                return null;
            }
            return student;
        }
    }
}
