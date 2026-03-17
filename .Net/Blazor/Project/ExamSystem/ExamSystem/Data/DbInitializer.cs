using ExamSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            // Apply migrations if any exist; otherwise ensure database is created.
            // This handles the case when no migrations were added yet (development).
            var pendingMigrations = Enumerable.Empty<string>();
            try
            {
                pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            }
            catch
            {
                // ignore failures when querying migrations
            }

            if (pendingMigrations.Any())
            {
                await _context.Database.MigrateAsync();
            }
            else
            {
                await _context.Database.EnsureCreatedAsync();
            }

            // Seed roles
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("Student"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }

            // Seed default admin
            var adminEmail = "admin@example.com";
            var admin = await _userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = "admin", Email = adminEmail, EmailConfirmed = true };
                await _userManager.CreateAsync(admin, "Admin123!");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            // Seed subjects, exams, questions, answers if empty
            if (!await _context.Subjects.AnyAsync())
            {
                var math = new Subject { Name = "Math" };
                var cs = new Subject { Name = "Computer Science" };

                var exam1 = new Exam { Title = "Math Basics", Subject = math };
                var exam2 = new Exam { Title = "Intro to CS", Subject = cs };

                var q1 = new Question { Text = "2+2= ?", Exam = exam1 };
                var a1 = new Answer { Text = "3", IsCorrect = false, Question = q1 };
                var a2 = new Answer { Text = "4", IsCorrect = true, Question = q1 };

                var q2 = new Question { Text = "What does CPU stand for?", Exam = exam2 };
                var b1 = new Answer { Text = "Central Processing Unit", IsCorrect = true, Question = q2 };
                var b2 = new Answer { Text = "Computer Personal Unit", IsCorrect = false, Question = q2 };

                _context.Subjects.AddRange(math, cs);
                _context.Exams.AddRange(exam1, exam2);
                _context.Questions.AddRange(q1, q2);
                _context.Answers.AddRange(a1, a2, b1, b2);

                await _context.SaveChangesAsync();
            }
        }
    }
}
