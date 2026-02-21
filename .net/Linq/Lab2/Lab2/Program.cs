using Lab2.Entity;
using Lab2.Repository;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = Repo.GetEmployees();

            var departments = Repo.GetDepartments();

            #region part1
            //1
            //var s1 = employees.Take(4).ToList();
            //Display(s1);

            ////2
            //var s2 = employees.Where(x => x.Salary > 5000).Take(3).ToList();
            //Display(s2);

            ////3
            //var s3 = employees.TakeLast(4);
            //Display(s3);

            ////4
            //var s4 = employees.Skip(1).Take(2);
            //Display(s4);

            ////5
            //var s5 = employees.Where(x => x.Name.Length < 5 );
            //Display(s5);

            ////6
            //var stdcom = new StudComp();

            //var s6 = employees.Distinct(stdcom);
            //Display(s6);


            ////7
            //var s7 = employees.Select(x => new { Name = x.Name, Id = x.Id });

            //foreach (var std in s7)
            //{
            //    Console.WriteLine($"{std.Id} : {std.Name}");
            //}

            ////8

            //var s8 = from employee in employees
            //         select new
            //         {
            //             Name = employee.Name,
            //             Id = employee.Id
            //         };

            //foreach (var emp in s8)
            //{
            //    Console.WriteLine($" {emp.Id} : {emp.Name}");
            //}

            //9

            //var s9 = from emp in employees
            //         join dept in departments
            //         on emp.DeptId equals dept.DeptId
            //         select new
            //         {
            //             empName = emp.Name,
            //             empDepart = dept.DeptName
            //         };

            //foreach (var emp in s9)
            //{
            //    Console.WriteLine($"{emp.empName} : {emp.empDepart}");
            //}

            //10
            //var s10 = employees.Join(
            //    departments,
            //    e => e.DeptId,
            //    d => d.DeptId,
            //    (emp, dept) => new { empName= emp.Name, empDepart=dept.DeptName });

            //foreach (var emp in s10)
            //{
            //    Console.WriteLine($"{emp.empName} : {emp.empDepart}");
            //}

            //11

            //var s11 = employees.Join(
            //    departments,
            //    e => e.DeptId,
            //    d => d.DeptId,
            //    (emp, dept) => new { empName = emp.Name, empDepart = dept.DeptName })
            //    .GroupBy(x => x.empDepart);

            //foreach (var emp in s11)
            //{
            //    Console.WriteLine($"DeptName : {emp.Key}");

            //    foreach (var employee in emp)
            //    {
            //        Console.WriteLine($"{employee.empName} ");
            //    }
            //    Console.WriteLine("===================================");

            //}

            //12

            //var s12 = from emp in employees
            //          join dept in departments
            //          on emp.DeptId equals dept.DeptId 
            //          group emp by dept.DeptName into g
            //          select g;

            //foreach (var emp in s12)
            //{
            //    Console.WriteLine($"DeptName : {emp.Key}");

            //    foreach (var employee in emp)
            //    {
            //        Console.WriteLine($"{employee.Name}");
            //    }
            //Console.WriteLine("===================================");

            //}

            //13
            //var s13 = employees.Max(employee => employee.Salary);
            //var s14 = employees.Min(employee => employee.Salary);
            //var s15 = employees.Average(employee => employee.Salary);

            //14
            List<int> nums1 = [1, 2, 3, 4, 5, 6];
            List<int> nums2 = [1, 2, 3, 4, 5, 6, 7, 8];


            //---------------------------------------
            //var s14 = nums2.Except(nums1);

            //foreach (int i in s14)
            //{
            //    Console.WriteLine(i);
            //}

            //---------------------------------------

            //var s15 = nums2.Concat(nums1);
            //foreach (int i in s15)
            //{
            //    Console.WriteLine(i);
            //}

            //---------------------------------------
            //var s15 = nums2.Union(nums1);
            //foreach (int i in s15)
            //{
            //    Console.WriteLine(i);
            //}

            //---------------------------------------

            //var s15 = nums2.Intersect(nums1);
            //foreach (int i in s15)
            //{
            //    Console.WriteLine(i);
            //}

            //---------------------------------------

            //var names = new List<string> { "Ahmed", "Ali", "Sara" };
            //var phones = new List<string> { "0100", "0111", "0122" };

            //var s16 = names.Zip(phones, (name, phone) => new
            //{
            //    name = name,
            //    phone = phone,
            //});

            //foreach (var data in s16)
            //{
            //    Console.WriteLine(data);
            //}
            #endregion

            #region part2
            //1
            List<int> numbers = [3, 9, 5, 7, 6, 4, 2, 1, 3, 0];

            var nums = numbers.Order().Distinct().ToList();

            //foreach (int num in nums)
            //{
            //    Console.WriteLine(num);
            //}

            //2

            //foreach (var num in nums)
            //{
            //    Console.WriteLine($"Number = {num} , Multiply = {num*num}");
            //}


            //3
            List<string> names = ["Ahmed", "mohamed", "fathi", "heba", "ali", "moo"];

            //var namesEqualthree= names.Where(x=>x.Length == 3).ToList();

            //foreach (var name in namesEqualthree)
            //{
            //    Console.WriteLine($"{name}");
            //}



            //var namesConatinsA = names.Where(x => x.ToLower().Contains("a")).OrderBy(x=>x.Length);

            //foreach (var name in namesConatinsA)
            //{
            //    Console.WriteLine($"{name}");
            //}


            //var firstTwoNames = names.Take(2);

            //foreach (var name in firstTwoNames)
            //{
            //    Console.WriteLine($"{name}");
            //}

            //var firstTwoNames = names.Take(2);

            //foreach (var name in firstTwoNames)
            //{
            //    Console.WriteLine($"{name}");
            //}


            //==============================================================


            var students = Repo.GetStudents();

            //var stds = students.Select(s => new
            //{
            //    FullName = $"{s.FirstName} {s.LastName}",
            //    NumOFSubjects = s.subjects.Count()
            //});

            //foreach (var student in stds)
            //{
            //    Console.WriteLine($"FullName = {student.FullName} , NumOFSubjects = {student.NumOFSubjects} ");
            //}


            //var stds = students.OrderByDescending(x=>x.FirstName)
            //    .ThenBy(y=>y.LastName)
            //    .Select(s => new
            //    {
            //        FullName = $"{s.FirstName} {s.LastName}",
            //    });

            //foreach (var student in stds)
            //{
            //    Console.WriteLine($"FullName = {student.FullName}  ");
            //}







            //var s = students.Select(x => new
            //{
            //    FullName = $"{x.FirstName} {x.LastName}",
            //    Subjects = x.subjects.Select(x => x.Name),
            //});


            //foreach (var student in s)
            //{
            //    Console.WriteLine(student.FullName);
            //    Console.WriteLine("--------------------------------");
            //    foreach (var sub in student.Subjects)
            //    {
            //        Console.WriteLine(sub);

            //    }

            //    Console.WriteLine("==============================\n\n");
            //}

            //var result = students
            //             .SelectMany(s => s.subjects, (student, subject) => new
            //             {
            //                 StudentName = $"{student.FirstName} {student.LastName}",
            //                 SubjectName = subject.Name
            //             })
            //             .ToList();

            //foreach (var student in result)
            //{
            //    Console.WriteLine($" StudentName = {student.StudentName} , SubjectName = {student.SubjectName} ");
            //}
            //Console.WriteLine("========\n\n\n\n");




            //var res = students.GroupBy(x => new { FN = x.FirstName, LN = x.LastName });

            //foreach (var student in res)
            //{
            //    Console.WriteLine($"{student.Key.FN} {student.Key.LN} \n");
            //    foreach (var std in student)
            //    {
            //        foreach (var sub in std.subjects)
            //        {
            //            Console.WriteLine(sub.Name);
            //        }
            //    }

            //    Console.WriteLine("=======================");
            //}







            #endregion


            #region part3

            var books = SampleData.Books;
            var subjects = SampleData.Subjects;

            //var b1 = books.Select(x => new
            //{
            //    BookISBN = x.Isbn,
            //    BookTitle = x.Title,
            //});

            //foreach (var book in b1)
            //{
            //    Console.WriteLine($"BooKIsbn = { book.BookISBN}  , BookTitle = {book.BookTitle}");
            //}



            //var b2 = books.Where(x => x.Price > 25).Take(3);
            //foreach (var book in b2)
            //{
            //    Console.WriteLine($"BooKIsbn = {book.Title}");
            //}



            //var b3 = books.Select(x => new
            //{
            //    BookTitle = x.Title,
            //    BookPublisher = x.Publisher.Name,
            //});

            //foreach (var book in b3)
            //{
            //    Console.WriteLine($" BookTitle = {book.BookTitle} , BookPublisher = {book.BookPublisher}");
            //}




            //var b4 = books.Where(x => x.Price > 20).Count();

            //    Console.WriteLine($" #Books = {b4}");



            ////var b5 = books.OrderBy(x => x.Subject.Name)
            ////    .ThenByDescending(x => x.Price)
            ////    .Select(x => new
            ////    {

            ////        BookTitle = x.Title,
            ////        BookPrice = x.Price,
            ////        BooKSubject = x.Subject.Name

            ////    });

            ////foreach (var book in b5)
            ////{
            ////    Console.WriteLine($"BookTitle = {book.BookTitle} , BookPrice = {book.BookPrice} , BooKSubject = {book.BooKSubject}");
            ////}





            var b11 = from book in books
                      join sub in subjects
                      on book.Subject.Name equals sub.Name
                      group book by sub.Name into g
                      select g;


            foreach (var book in b11)
            {
                Console.WriteLine($" subject : {book.Key}");
                Console.WriteLine("-----------------");
                foreach (var bk in book)
                {
                    Console.WriteLine($"BookIS BookTitle = {bk.Title}  , BooKSubject = {bk.Subject.Name}");
                }
                Console.WriteLine("====================");
            }


            //var b0 = books.GroupBy(x => new { s = x.Subject.Name, p = x.Publisher.Name });

            //foreach (var book in b0)
            //{
            //    Console.WriteLine($" subject : {book.Key.s} , publisher : {book.Key.p}");
            //    Console.WriteLine("-----------------");
            //    foreach (var bk in book)
            //    {
            //        Console.WriteLine($"BookIS BookTitle = {bk.Title}  ");
            //    }
            //    Console.WriteLine("====================");
            //}



            #endregion
        }

        private static void Display(IEnumerable<Employee> students)
        {
            foreach (var stud in students)
            {
                Console.WriteLine(stud);
            }
        }
    }
}
