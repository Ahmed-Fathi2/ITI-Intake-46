using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Entities;

namespace WebApplication2.Data
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
            var connectionString = "Server=.;Database=MVCLab2;Trusted_Connection=true;TrustServerCertificate=true";

            optionsBuilder.UseSqlServer(connectionString);  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
