using Lab1.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data
{
    public class AppDbContext :DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server = .; Database = ITI ; Trusted_connection=true; TrustServerCertificate = True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(x => x.Name)
                .HasMaxLength(20);


            modelBuilder.Entity<Department>().Property(x => x.Name)
           .HasMaxLength(20);
        }
    }
}
