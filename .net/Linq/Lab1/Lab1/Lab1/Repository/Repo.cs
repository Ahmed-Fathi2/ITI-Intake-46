using Lab1.Entity;
using System.Diagnostics;

namespace Lab1.Repository;
public  class Repo
{

    public static List<Student> GetAllStudents()
    {
        return new List<Student>
        {
            new Student { Id = 1, FName = "Ahmed",  LName= "Ali", Age = 44, Salary = 7000, trackId = 1 },
            new Student { Id = 2, FName = "Sara",   LName= "Hassan", Age = 21, Salary = 5200, trackId = 1},
            new Student { Id = 3, FName = "Ahmed",  LName= "Khaled", Age = 23, Salary = 3000, trackId = 1 },
            new Student { Id = 4, FName = "Mona",   LName= "Samir", Age = 24, Salary = 2800, trackId = 4 },
            new Student { Id = 5, FName = "Ali",LName= "Adel", Age = 22, Salary = 3100, trackId = 5 },
            new Student { Id = 6, FName = "Nour",   LName= "Ibrahim", Age = 20, Salary = 2900, trackId = 1 },
            new Student { Id = 7, FName = "Karim",  LName= "Mahmoud", Age = 55, Salary = 3600, trackId = 2 },
            new Student { Id = 8, FName = "Salma",  LName= "Tarek", Age = 23, Salary = 3300, trackId = 3 },
            new Student { Id = 9, FName = "Hany",   LName= "Fathy", Age = 26, Salary = 5500, trackId = 4 },
            new Student { Id = 10,FName = "Laila",  LName= "Mostafa", Age = 21, Salary = 3000, trackId = 5 }
        };                                         
        
     }


    public static List<Track> GetAllTrasks()
    {
        return new List<Track>
        {
            new Track { Id = 1, Name = "Web Development" },
            new Track { Id = 2, Name = "AI" },
            new Track { Id = 3, Name = "Mobile Apps" },
            new Track { Id = 4, Name = "Cyber Security" },
            new Track { Id = 5, Name = "Data Science" }
        };

    }

}
