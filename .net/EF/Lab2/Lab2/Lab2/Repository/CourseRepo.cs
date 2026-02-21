using Lab2.Data;
using Lab2.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Repository
{
    public class CourseRepo
    {

        public static void Add(Course course)
        {
            var db = new AppDbContext();

            db.Add(course);
            db.SaveChanges();
        }

        public static void AddMany(IEnumerable<Course> courses)
        {
            var db = new AppDbContext();

            db.AddRange(courses);
            db.SaveChanges();
        }



        public static IEnumerable<Course> GetAll()
        {
            var db = new AppDbContext();

            return db.Courses.ToList();
        }


        public static Course? GetById(int id)
        {


            var db = new AppDbContext();

            var crs = db.Courses.Find(id);

            if (crs != null)
                return crs;

            else
               return null;
        }


        public static Course? Update(int id, Course course)//DTO
        {


            var db = new AppDbContext();

            var crs = db.Courses.Find(id);

            if (crs != null)
            {

                crs.CrsName = course.CrsName;

                crs.CrsDuration = course.CrsDuration;

                db.SaveChanges();

                return crs;

            }

            else
                return null;
        }


        public static Course? Delete(int id)
        {


            var db = new AppDbContext();

            var crs = db.Courses.Find(id);

            if (crs != null)
            {

                db.Remove(crs);
                db.SaveChanges();

                return crs;

            }

            else
                return null;
        }

    }
}
