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
        public void Update(Student student)
        {
            var exist = dbContext.Students.FirstOrDefault(x => x.Id == student.Id);
            if (exist == null) return;

            exist.FirstName = student.FirstName;
            exist.LastName = student.LastName;
            exist.Phone = student.Phone;

            //dbContext.Students.Update(exist);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) return;

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
