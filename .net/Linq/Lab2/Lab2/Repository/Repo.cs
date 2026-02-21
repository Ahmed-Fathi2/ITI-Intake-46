using Lab2.Entity;

namespace Lab2.Repository
{
    class Repo
    {

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee { Id = 1, Name = "Ahmed", Age = 26 , Salary = 1234, DeptId = 1 },
                new Employee { Id = 2, Name = "Mohamed", Age = 36 , Salary = 2234, DeptId = 2 },
                new Employee { Id = 3, Name = "Sara", Age = 46 , Salary = 4234, DeptId = 3 },
                new Employee { Id = 4, Name = "Omar", Age = 25 , Salary = 5234, DeptId = 4 },
                new Employee { Id = 5, Name = "Ali", Age = 23 , Salary = 6234, DeptId = 1 },
                new Employee { Id = 6, Name = "Mai", Age = 36 , Salary = 7234, DeptId = 2 },
                new Employee { Id = 7, Name = "Ramy", Age = 49 , Salary = 8234, DeptId = 3 },
                new Employee { Id = 8, Name = "Hamada", Age = 18 , Salary = 9234, DeptId = 4 },
                new Employee { Id = 9, Name = "Hatem", Age = 26 , Salary = 10234, DeptId = 1 }, // 8
                new Employee { Id = 10, Name = "Osama", Age = 25 , Salary = 17234, DeptId = 2 },
            };
        }
     
        public static List<Department> GetDepartments()
        {
            return new List<Department>()
            {
                new Department {  DeptId = 1 , DeptName = "SD" },
                new Department {  DeptId = 2 , DeptName = "UI" },
                new Department {  DeptId = 3 , DeptName = "Mob" },
                new Department {  DeptId = 4 , DeptName = "Network" },
            };
        }

        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Ali",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 101, Name = "Math"},
                        new Subject{ Code = 102, Name = "Physics"}
                    }
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Sara",
                    LastName = "Hassan",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 103, Name = "Chemistry"},
                        new Subject{ Code = 104, Name = "Biology"},
                        new Subject{ Code = 105, Name = "Os"}
                    }
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Khaled",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 101, Name = "Math"},
                        new Subject{ Code = 105, Name = "History"}
                    }
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Mona",
                    LastName = "Adel",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 102, Name = "Physics"},
                        new Subject{ Code = 106, Name = "Geography"}
                    }
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Ahmed",
                    LastName = "Samir",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 107, Name = "Programming"},
                        new Subject{ Code = 101, Name = "Math"}
                    }
                },
                new Student
                {
                    Id = 6,
                    FirstName = "Nour",
                    LastName = "Ibrahim",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 104, Name = "Biology"},
                        new Subject{ Code = 103, Name = "Chemistry"}
                    }
                },
                new Student
                {
                    Id = 7,
                    FirstName = "Karim",
                    LastName = "Mahmoud",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 108, Name = "Art"},
                        new Subject{ Code = 105, Name = "History"}
                    }
                },
                new Student
                {
                    Id = 8,
                    FirstName = "Huda",
                    LastName = "Tarek",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 109, Name = "Music"},
                        new Subject{ Code = 106, Name = "Geography"}
                    }
                },
                new Student
                {
                    Id = 9,
                    FirstName = "Mostafa",
                    LastName = "Fathy",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 107, Name = "Programming"},
                        new Subject{ Code = 102, Name = "Physics"}
                    }
                },
                new Student
                {
                    Id = 10,
                    FirstName = "Laila",
                    LastName = "Saeed",
                    subjects = new List<Subject>
                    {
                        new Subject{ Code = 103, Name = "Chemistry"},
                        new Subject{ Code = 101, Name = "Math"}
                    }
                }
            };

        }
    }
}
