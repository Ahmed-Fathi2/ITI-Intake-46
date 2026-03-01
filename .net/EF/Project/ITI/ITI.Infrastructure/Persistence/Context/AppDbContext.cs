using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace ITI.Infrastructure.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base()
        {
            
        }
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ItiOrg"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSession> CourseSessions { get; set; }
        public DbSet<CourseSessionAttendance> CourseSessionAttendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
