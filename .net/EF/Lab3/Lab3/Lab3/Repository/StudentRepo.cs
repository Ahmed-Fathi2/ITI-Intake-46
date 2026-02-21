using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Repository
{

    public class StudentRepo
    {

        public static void Add(Student student)
        {
            var db = new AppDbContext();

            db.Add(student);
            db.SaveChanges();
        }

        public static void AddMany(IEnumerable<Student> students)
        {
            var db = new AppDbContext();

            db.AddRange(students);
            db.SaveChanges();
        }



        public static IEnumerable<Student> GetAll()
        {
            var db = new AppDbContext();

            return db.Students.ToList();
        }


        public static Student? GetById(int id)
        {


            var db = new AppDbContext();

            var std = db.Students.Find(id);

            if (std != null)
                return std;

            else
                return null;
        }


        public static Student? Update(int id, Student student)//DTO
        {


            var db = new AppDbContext();

            var std = db.Students.Find(id);

            if (std != null)
            {

                std.Fname = student.Fname;

                std.Lname = student.Lname;

                std.Address = student.Address;

                std.Age = student.Age;

                db.SaveChanges();

                return std;

            }

            else
                return null;
        }


        public static Student? Delete(int id)
        {


            var db = new AppDbContext();

            var std = db.Students.Find(id);

            if (std != null)
            {

                db.Remove(std);
                db.SaveChanges();

                return std;

            }

            else
                return null;
        }

    }
}
