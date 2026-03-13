using Lab1.Data;
using Lab1.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();
            #region part1
            var departments = new List<Department>
            {
                new Department {  Name = "HR" },
                new Department {  Name = "IT" },
                new Department {  Name = "Finance" },
                new Department {  Name = "Marketing" },
                new Department {  Name = "Sales" }
            };

            var students = new List<Student>
            {
                new Student { Name="Ahmed",   Age=22, Salary=5000, DepartmentId=1 },
                new Student { Name="Sara",    Age=21, Salary=4500, DepartmentId=2 },
                new Student { Name="Omar",    Age=23, Salary=5200, DepartmentId=3 },
                new Student { Name="Mona",    Age=32, Salary=7000, DepartmentId=1 },
                new Student { Name="Ali",     Age=24, Salary=4800, DepartmentId=4 },
                new Student { Name="Nour",    Age=22, Salary=4600, DepartmentId=5 },
                new Student { Name="Hassan",  Age=21, Salary=4300, DepartmentId=2 },
                new Student { Name="Laila",   Age=23, Salary=5100, DepartmentId=4 },
                new Student { Name="Youssef", Age=55, Salary=9000, DepartmentId=3 },
                new Student { Name="Salma",   Age=22, Salary=4700, DepartmentId=1 }
            };


            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.AddRange(departments);
            db.AddRange(students);

            db.SaveChanges();

            //var stds= db.Students.ToList(); 


            //foreach (var student in stds)
            //{
            //    Console.WriteLine(student);
            //}


            //Console.WriteLine("==================================");

            //var depts = db.Departments.ToList();

            //foreach (var departs in depts)
            //{
            //    Console.WriteLine(departs);
            //}


            //Console.WriteLine("==================================");

            //var stdsWithDepts = db.Students.Include(x => x.Department);


            //foreach (var std in stdsWithDepts)
            //{
            //    Console.WriteLine($"{std} ------- DeptName={std.Department.Name}");
            //} 


            //Console.WriteLine("==================================");

            var stdsWithDeptsone = db.Students.Where(x => x.DepartmentId == 1);


            var memeoryEnumerable = students.Where(x => x.DepartmentId == 1);

            //foreach (var std in stdsWithDeptsone)
            //{
            //    Console.WriteLine($"{std} ------- DeptName={std.Department.Name}");
            //}



            //Console.WriteLine("==================================");

            //var stdsWithDeptTwo = db.Students.Where(x => x.DepartmentId == 1).OrderBy(x => x.Name);


            //foreach (var std in stdsWithDeptTwo)
            //{
            //    Console.WriteLine($"{std} ------- DeptName={std.Department.Name}");
            //}

            #endregion

            #region part2
            //var stds = from std in db.Students
            //           select new
            //           {
            //               Id = std.Id,
            //               Name = std.Name,

            //           };

            //foreach (var st in stds)
            //{
            //    Console.WriteLine($"Id = {st.Id} , Name = {st.Name}");
            //}

            //Console.WriteLine("=================================================");

            //var stds1 = db.Students.Select(x=> new
            //            {
            //                Id = x.Id,
            //                Name = x.Name,

            //            });


            //foreach (var st in stds1)
            //{
            //    Console.WriteLine($"Id = {st.Id} , Name = {st.Name}");
            //}

            //Console.WriteLine("=================================================");

            //var stds2 = from std in db.Students
            //           where std.Age>30
            //           select new
            //           {
            //               Id = std.Id,
            //               Name = std.Name,

            //           };

            //foreach (var st in stds2)
            //{
            //    Console.WriteLine($"Id = {st.Id} , Name = {st.Name}");
            //}

            //Console.WriteLine("=================================================");
            //var stds3 = db.Students.Where(x=>x.Salary<5000)
            //    .Select(x => new
            //    {
            //        Id = x.Id,
            //        Name = x.Name,

            //    });


            //foreach (var st in stds3)
            //{
            //    Console.WriteLine($"Id = {st.Id} , Name = {st.Name}");
            //}

            //Console.WriteLine("=================================================");

            //var stds5 = from std in db.Students
            //            where std.DepartmentId==1 &&  std.Salary>4000
            //            orderby std.Name descending
            //            select new
            //            {
            //                Id = std.Id,
            //                Name = std.Name,

            //            };

            //foreach (var st in stds5)
            //{
            //    Console.WriteLine($"Id = {st.Id} , Name = {st.Name}");
            //}

            //Console.WriteLine("=================================================");

            //var stds7 = db.Students
            //            .Where(x => x.DepartmentId == 1 && x.Name.Contains("m"))
            //            .OrderBy(x => x.Salary);

            //foreach (var st in stds7)
            //{
            //    Console.WriteLine($"Id = {st.Id} , Name = {st.Name}");
            //}

            //Console.WriteLine("=================================================");

            //var std8 = db.Students.First(x => x.Salary > 5000);

            //Console.WriteLine(std8);


            //var std9= db.Students.FirstOrDefault(x => x.Salary > 5000);
            //Console.WriteLine(std9);

            Console.WriteLine("=================================================");

            //var stds10 = db.Students
            //            .Last(x => x.DepartmentId == 10);

            //Console.WriteLine(stds10);

            var stds11 = db.Students
                        .LastOrDefault(x => x.DepartmentId == 10);

            //var stds22 = db.Students
            //   .Where(x => x.DepartmentId == 10)
            //   .OrderBy(x => x.Id)
            //   .LastOrDefault();

            var stds23 = db.Students
                     .OrderBy(x => x.Id)
                     .LastOrDefault(x => x.DepartmentId == 10);


            Console.WriteLine(stds11);

            Console.WriteLine("=================================================");


            //var stds12 = db.Students
            //            .Single(x => x.Age == 25);

            //Console.WriteLine(stds12);

            //var stds13 = db.Students
            //            .SingleOrDefault(x => x.Age == 25);



            //Console.WriteLine(stds13);

            Console.WriteLine("=================================================");


            //var stds14 = db.Students
            //     .Single(x => x.DepartmentId == 8);

            //Console.WriteLine(stds14);

            var stds15 = db.Students
                        .SingleOrDefault(x => x.DepartmentId == 8);

            Console.WriteLine(stds15);

            Console.WriteLine("=================================================");
            #endregion




        }
    }
}
