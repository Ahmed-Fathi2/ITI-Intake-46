using Lab2.Entity;
using Lab2.Repository;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region StudentCrud
            Console.WriteLine("======================================================================================");

            // Add Student

            //var s1 = new Student
            //{
            //    FName = "Ahmed",
            //    LName = "Ali",
            //    Address = "Cairo",
            //    Age = 22,
            //    DepartmentId = 1
            //};

            //var s2 = new Student
            //{
            //    FName = "Ahmed",
            //    LName = "Fathi",
            //    Address = "Cairo",
            //    Age = 22,
            //    DepartmentId = 2,
            //    StSuper=3

            //};

            //Repo.Add(s2);
            //Console.WriteLine("Student Added");

            Console.WriteLine("======================================================================================");

            //// Add Many

            //var list = new List<Student>
            //{
            //    new Student { FName="Mona", LName="Hassan", Address="Giza", Age=21, DepartmentId=2,StSuper=5 },
            //    new Student { FName="Omar", LName="Samy", Address="Alex", Age=23, DepartmentId=3,StSuper=3 }
            //};

            //Repo.AddMany(list);
            //Console.WriteLine("Many Students Added");


            Console.WriteLine("======================================================================================");

            // Get All

            //var students = Repo.GetAll();

            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.StId} - {s.FName} {s.LName}");
            //}

            Console.WriteLine("======================================================================================");

            //// Get By Id


            //var st = StudentRepo.GetById(1);
            //if (st != null)
            //    Console.WriteLine($"Found: {st.FName} {st.LName}");

            //else
            //    Console.WriteLine("Student Not Found");


            //}


            //Console.WriteLine("======================================================================================");

            // Update

            //var updateDto = new Student
            //{
            //    FName = "Updated",
            //    LName = "Name",
            //    Address = "Updated Address",
            //    Age = 30
            //};



            //var result=  StudentRepo.Update(31, updateDto);
            //  if (result != null)
            //      Console.WriteLine("Updated");

            //  else
            //      Console.WriteLine("Student Not Found");
            ////Console.WriteLine("======================================================================================");

            ////// Delete

            //var res = StudentRepo.Delete(7);
            //if (res != null)
            //    Console.WriteLine("Deleted");

            //else
            //    Console.WriteLine("Student Not Found");

            try
            {
                var x =int.Parse( Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("error");
            }
            Console.WriteLine("continue");
            #endregion


            #region CourseCrud
            //  ADD Course
            //var newCourse = new Course
            //{
            //    CrsName = "C# Basics",
            //    CrsDuration = 40,
            //    TopId = 1   
            //};

            //CourseRepo.Add(newCourse);
            //Console.WriteLine("Course Added ");


            //    //  ADD MANY
            //    var courses = new List<Course>
            //{
            //    new Course{ CrsName="ASP.NET Core", CrsDuration=60, TopId=1 },
            //    new Course{ CrsName="SQL Server", CrsDuration=35, TopId=2 }
            //};

            //    CourseRepo.AddMany(courses);
            //    Console.WriteLine("Courses Added ");


            //    //  GET ALL
            //var allCourses = CourseRepo.GetAll();

            //Console.WriteLine("All Courses:");
            //foreach (var c in allCourses)
            //{
            //    Console.WriteLine($"{c.CrsId} - {c.CrsName} ({c.CrsDuration})");
            //}


            //  GET BY ID


            //var course = CourseRepo.GetById(10);

            //if (course != null)
            //    Console.WriteLine($"Found Course: {course.CrsName}");

            //else
            //    Console.WriteLine("Course Not Found");



            ////  UPDATE
            //  var updatedCourse = new Course
            //  {
            //      CrsName = "Advanced C#",
            //      CrsDuration = 55
            //  };

            //var crs=  CourseRepo.Update(1, updatedCourse);
            //  if (crs != null)
            //  {
            //      Console.WriteLine("Course Updated ");
            //  }
            //  else
            //  {
            //      Console.WriteLine("Course Not Found");
            //  }


            //  DELETE
            //var crs = CourseRepo.Delete(1);
            //if (crs != null)
            //{
            //    Console.WriteLine("Course Deleted ");
            //}
            //else
            //{
            //    Console.WriteLine("Course Not Found");
            //}

            #endregion
        }
    }
}

