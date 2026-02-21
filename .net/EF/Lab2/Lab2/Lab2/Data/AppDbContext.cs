using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Lab2.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext():base()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instractor> Instractors { get; set; }
        public DbSet<InstCourse> InstCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudCourse> StudCourses { get; set; }
        public DbSet<Topic> Topics { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server = .; Database = ITIV2 ; Trusted_connection=true; TrustServerCertificate = True";

            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
