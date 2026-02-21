using Lab3.Models;
using Lab3.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region StudentCrud
            Console.WriteLine("======================================================================================");

            //Add Student

            //var s1 = new Student
            //{
            //    Fname = "Ahmed",
            //    Lname = "Mohamed",
            //    Address = "Cairo",
            //    Age = 22,
            //    DepartmentId = 1
            //};

            //var s2 = new Student
            //{
            //    Fname = "Heba",
            //    Lname = "Moahmed",
            //    Address = "Cairo",
            //    Age = 22,
            //    DepartmentId = 2,
            //    StSuper = 3

            //};

            //StudentRepo.Add(s1);
            //Console.WriteLine("Student Added");

            Console.WriteLine("======================================================================================");

            //// Add Many

            //var list = new List<Student>
            //{
            //    new Student { Fname="Habiba", Lname="Mohamed", Address="Zag", Age=18, DepartmentId=2,StSuper=5 },
            //    new Student { Fname="Mohamed", Lname="Fathi", Address="Alex", Age=33, DepartmentId=3,StSuper=3 }
            //};

            //StudentRepo.AddMany(list);
            //Console.WriteLine("Many Students Added");


            Console.WriteLine("======================================================================================");

            // Get All

            //var students = StudentRepo.GetAll();

            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.StId} - {s.Fname} {s.Lname}");
            //}

            Console.WriteLine("======================================================================================");

            //// Get By Id


            //var st = StudentRepo.GetById(11);
            //if (st != null)
            //    Console.WriteLine($"Found: {st.Fname} {st.Lname}");

            //else
            //    Console.WriteLine("Student Not Found");





            //Console.WriteLine("======================================================================================");

            // Update

            //var updateDto = new Student
            //{
            //    Fname = "Heba",
            //    Lname = "Ahmed",
            //    Address = "Updated Address",
            //    Age = 30
            //};



            //var result = StudentRepo.Update(3, updateDto);
            //if (result != null)
            //    Console.WriteLine("Updated");

            //else
            //    Console.WriteLine("Student Not Found");


            ////Console.WriteLine("======================================================================================");

            ////// Delete

            var res = StudentRepo.Delete(11);
            if (res != null)
                Console.WriteLine("Deleted");

            else
                Console.WriteLine("Student Not Found");

            #endregion




        }
    }
}
