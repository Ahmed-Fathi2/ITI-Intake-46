using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ExamSystem.Data;

namespace ExamSystem.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            // =========================
            // Roles
            // =========================
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("Student"))
                await roleManager.CreateAsync(new IdentityRole("Student"));

            // =========================
            // Admin User
            // =========================
            var adminEmail = "admin@examsystem.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // =========================
            // Student Users
            // =========================
            var usersToSeed = new List<(string Email, string Password)>
            {
                ("student@examsystem.com", "Student123!"),
                ("test@test.com", "Ahmed@123")
            };

            foreach (var (email, password) in usersToSeed)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, "Student");
                }
            }

            // =========================
            // Subjects + Exams + Questions + Answers
            // =========================
            if (!await context.Subjects.AnyAsync())
            {
                // SUBJECT 1: Data Structures
                var ds = new Subject { Name = "Data Structures", Description = "Stacks, Queues, Linked Lists, Trees, Graphs, and Algorithm Complexity." };
                context.Subjects.Add(ds);
                await context.SaveChangesAsync();

                // Exam 1
                var dsExam1 = new Exam { Title = "Data Structures - Fundamentals", Description = "Basic data structures concepts and operations.", SubjectId = ds.Id, DurationMinutes = 30 };
                context.Exams.Add(dsExam1);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, dsExam1.Id, 1, "Which data structure follows LIFO order?", new[] { "Queue", "Stack", "Linked List", "Deque" }, 1);
                await AddQuestionWithAnswers(context, dsExam1.Id, 2, "Which data structure follows FIFO order?", new[] { "Stack", "Tree", "Queue", "Graph" }, 2);
                await AddQuestionWithAnswers(context, dsExam1.Id, 3, "Array element access time complexity?", new[] { "O(n)", "O(log n)", "O(1)", "O(n²)" }, 2);

                // SUBJECT 2: Database Systems
                var db = new Subject { Name = "Database Systems", Description = "SQL, Normalization, ERD, and Transactions." };
                context.Subjects.Add(db);
                await context.SaveChangesAsync();

                // Exam 1
                var dbExam1 = new Exam { Title = "Database Systems - SQL Basics", Description = "Core SQL commands and query writing.", SubjectId = db.Id, DurationMinutes = 35 };
                context.Exams.Add(dbExam1);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, dbExam1.Id, 1, "Which SQL command retrieves data?", new[] { "INSERT", "UPDATE", "SELECT", "DELETE" }, 2);
                await AddQuestionWithAnswers(context, dbExam1.Id, 2, "Filter rows clause?", new[] { "ORDER BY", "GROUP BY", "WHERE", "HAVING" }, 2);
                await AddQuestionWithAnswers(context, dbExam1.Id, 3, "What is a Primary Key?", new[] { "A duplication flag", "A unique, non-null identifier", "A foreign link", "An index" }, 1);

                await context.SaveChangesAsync();
            }
        }

        private static async Task AddQuestionWithAnswers(
            ApplicationDbContext context,
            int examId,
            int order,
            string questionText,
            string[] answerTexts,
            int correctAnswerIndex)
        {
            var question = new Question { Text = questionText, ExamId = examId, Order = order };
            context.Questions.Add(question);
            await context.SaveChangesAsync();

            var answers = answerTexts.Select((text, index) => new Answer
            {
                Text = text,
                QuestionId = question.Id,
                IsCorrect = index == correctAnswerIndex
            }).ToList();
            
            context.Answers.AddRange(answers);
            await context.SaveChangesAsync();
        }
    }
}