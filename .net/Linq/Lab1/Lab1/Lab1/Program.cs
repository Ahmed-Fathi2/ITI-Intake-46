using Lab1.Entity;
using Lab1.Repository;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var students = Repo.GetAllStudents();

            var tracks=Repo.GetAllTrasks();
            #region Lab1

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("========================= 1 =====================================");

            ////1
            ////var studs = from e in students
            ////            select e;
            ////foreach(var stud in studs)
            ////{
            ////    Console.WriteLine(stud);
            ////}

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 2===================================");

            ////2
            ////var studentsV2 = students.Select(x => new { x.Id, x.fName, x.lName, x.Age, x.Salary });

            ////foreach (var stud in studentsV2)
            ////{
            ////    Console.WriteLine(stud);
            ////}

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("============================ 3 ==================================");

            ////3
            ////var studentsV3 = from student in students
            ////         where student.Age >30
            ////         select student;

            ////foreach (var stud in studentsV3)
            ////{
            ////    Console.WriteLine(stud);
            ////}

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("========================== 4 ====================================");

            ////4
            ////var studentsV3 = students.Where(s => s.Salary < 5000);
            ////Display(studentsV3);

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 5 ===================================");


            ////5

            ////var studentsV4 =from student in students
            ////                where student.Salary>4000 && student.trackId==1
            ////                orderby student.fName descending , student.lName descending
            ////                select student;
            ////Display(studentsV4);

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 6 ===================================");


            ////var studentsV5 = students
            ////                .Where(s => s.trackId == 1 && s.fName.Contains("m"))
            ////                .OrderBy(s => s.Salary);

            ////Display(studentsV5);

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 7 ===================================");


            ////var studentsV6 = students.First(s => s.Salary > 10000); // Found ? Return Std : Exception.
            ////var studentsV7 = students.FirstOrDefault(s => s.Salary > 10000); //Found ? Return Std : Null

            ////Console.WriteLine(studentsV7);


            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 8 ===================================");

            ////var studentsV8 = students.Last(s => s.Salary > 10000); // Found ? Return Std : Exception.
            ////var studentsV9 = students.LastOrDefault(s => s.Salary > 10000); //Found ? Return Std : Null
            ////Console.WriteLine(studentsV8);

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 9 ===================================");

            ////var studentsV9 = students.Single(s => s.Salary > 5000); // NotFound || Find More Than one  ?  Exception : Return Std .
            ////var studentsV10 = students.SingleOrDefault(s => s.Salary > 5000); //NotFound ?  Null : Find More Than one ? Exception :  Return Std
            ////Console.WriteLine(studentsV10);

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 10 ===================================");

            ////var studentsV11 = students.Single(s => s.trackId ==8); // NotFound || Find More Than one  ?  Exception : Return Std .
            ////var studentsV12 = students.SingleOrDefault(s => s.trackId ==8); //NotFound ?  Null : Find More Than one ? Exception :  Return Std
            ////Console.WriteLine(studentsV11);

            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 11===================================");

            //var studentsV13 = students.ElementAt(400); // out of index range --> Exception 
            //Console.WriteLine(studentsV13);



            //Console.WriteLine("==============================================================");
            //Console.WriteLine("=========================== 12===================================");

            //int sortByChoice;
            //while (true)
            //{
            //    Console.WriteLine("Do You want To Sort Students due to :");
            //    Console.WriteLine("1-Id");
            //    Console.WriteLine("2-Name");
            //    Console.WriteLine("3-Salary");
            //    Console.WriteLine("4-Age");
            //    Console.Write("Enter Your Choice [1-4]: ");

            //    if (int.TryParse(Console.ReadLine(), out sortByChoice) && sortByChoice >= 1 && sortByChoice <= 4)
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Invalid input! Please enter a number between 1 and 4.\n");
            //}

            //int sortTypeChoice;
            //while (true)
            //{
            //    Console.WriteLine("Do You want To Sort Students ASC/DESC:");
            //    Console.WriteLine("1-ASC");
            //    Console.WriteLine("2-DESC");
            //    Console.Write("Enter Your Choice [1-2]: ");

            //    if (int.TryParse(Console.ReadLine(), out sortTypeChoice) && (sortTypeChoice == 1 || sortTypeChoice == 2))
            //    {
            //        break; 
            //    }
            //    Console.WriteLine("Invalid input! Please enter 1 or 2.\n");
            //}



            //var sorted = Helper.SortStudent(sortByChoice, sortTypeChoice, students);

            //Display(sorted);

            #endregion

            #region
            //1
            //var s1 = students.Take(4).ToList();
            //Display(s1);

            //2
            //var s2 = students.Where(x=>x.Salary>5000).Take(3).ToList();
            //Display(s2);

            //3
            //var s3 = students.TakeLast(4);
            //Display(s3);

            //4
            //var s4 = students.Skip(1).Take(2);
            //Display(s4);

            //5
            //var s5 = students.Where(x=>x.FName.Length<5 && x.LName.Length<5);
            //Display(s5);

            //6
            //var stdcom = new StudComp();

            //var s6 = students.Distinct(stdcom);
            //Display(s6);


            //7
            //var s7 = students.Select(x => new {Name= x.FName,Id= x.Id });

            //foreach (var std in s7)
            //{
            //    Console.WriteLine($"{std.Id} : {std.Name}");
            //}

            //8

            var s8 = from student in students
                     select new
                     {
                         Name = student.FName,
                         Id = student.Id
                     };

            foreach (var std in s8)
            {
                Console.WriteLine($"{std.Id} : {std.Name}");
            }


            #endregion


        }

        private static void Display(IEnumerable<Student> students)
       {
            foreach (var stud in students)
            {
                Console.WriteLine(stud);
            }
        }
    }
}
