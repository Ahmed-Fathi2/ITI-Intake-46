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
                // -------------------------------------------------------
                // SUBJECT 1: Data Structures
                // -------------------------------------------------------
                var ds = new Subject
                {
                    Name = "Data Structures",
                    Description = "Stacks, Queues, Linked Lists, Trees, Graphs, and Algorithm Complexity."
                };
                context.Subjects.Add(ds);
                await context.SaveChangesAsync();

                // Exam 1 - Fundamentals
                var dsExam1 = new Exam
                {
                    Title = "Data Structures - Fundamentals",
                    Description = "Basic data structures concepts and operations.",
                    SubjectId = ds.Id,
                    DurationMinutes = 30
                };
                context.Exams.Add(dsExam1);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, dsExam1.Id, 1,
                    "Which data structure follows LIFO (Last In First Out) order?",
                    new[] { "Queue", "Stack", "Linked List", "Deque" }, 1);

                await AddQuestionWithAnswers(context, dsExam1.Id, 2,
                    "Which data structure follows FIFO (First In First Out) order?",
                    new[] { "Stack", "Tree", "Queue", "Graph" }, 2);

                await AddQuestionWithAnswers(context, dsExam1.Id, 3,
                    "What is the time complexity of accessing an element in an array by index?",
                    new[] { "O(n)", "O(log n)", "O(1)", "O(n²)" }, 2);

                await AddQuestionWithAnswers(context, dsExam1.Id, 4,
                    "In a singly linked list, each node contains:",
                    new[] { "Only data", "Data and two pointers", "Data and one pointer to the next node", "Only a pointer" }, 2);

                await AddQuestionWithAnswers(context, dsExam1.Id, 5,
                    "Which data structure is used internally when implementing recursion?",
                    new[] { "Queue", "Stack", "Heap", "Graph" }, 1);

                // Exam 2 - Trees & Sorting
                var dsExam2 = new Exam
                {
                    Title = "Data Structures - Trees & Sorting",
                    Description = "Binary trees, BST, and sorting algorithms.",
                    SubjectId = ds.Id,
                    DurationMinutes = 40
                };
                context.Exams.Add(dsExam2);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, dsExam2.Id, 1,
                    "What is the time complexity of binary search on a sorted array?",
                    new[] { "O(n)", "O(log n)", "O(1)", "O(n²)" }, 1);

                await AddQuestionWithAnswers(context, dsExam2.Id, 2,
                    "In a Binary Search Tree (BST), where is the smallest element located?",
                    new[] { "Root", "Rightmost node", "Leftmost node", "Any leaf node" }, 2);

                await AddQuestionWithAnswers(context, dsExam2.Id, 3,
                    "What is the worst-case time complexity of Quick Sort?",
                    new[] { "O(n log n)", "O(n)", "O(n²)", "O(log n)" }, 2);

                await AddQuestionWithAnswers(context, dsExam2.Id, 4,
                    "Which traversal visits nodes in Left → Root → Right order?",
                    new[] { "Pre-order", "Post-order", "In-order", "Level-order" }, 2);

                await AddQuestionWithAnswers(context, dsExam2.Id, 5,
                    "A complete binary tree with 7 nodes has how many levels?",
                    new[] { "2", "3", "4", "5" }, 1);

                // -------------------------------------------------------
                // SUBJECT 2: Database Systems
                // -------------------------------------------------------
                var db = new Subject
                {
                    Name = "Database Systems",
                    Description = "SQL, Normalization, ERD, Transactions, and Indexing."
                };
                context.Subjects.Add(db);
                await context.SaveChangesAsync();

                // Exam 1 - SQL Basics
                var dbExam1 = new Exam
                {
                    Title = "Database Systems - SQL Basics",
                    Description = "Core SQL commands and query writing.",
                    SubjectId = db.Id,
                    DurationMinutes = 35
                };
                context.Exams.Add(dbExam1);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, dbExam1.Id, 1,
                    "Which SQL command is used to retrieve data from a table?",
                    new[] { "INSERT", "UPDATE", "SELECT", "DELETE" }, 2);

                await AddQuestionWithAnswers(context, dbExam1.Id, 2,
                    "Which clause is used to filter rows in a SELECT statement?",
                    new[] { "ORDER BY", "GROUP BY", "WHERE", "HAVING" }, 2);

                await AddQuestionWithAnswers(context, dbExam1.Id, 3,
                    "What does the PRIMARY KEY constraint ensure?",
                    new[] { "Allows duplicate values", "Unique, non-null identifier for each row", "Links two tables", "Speeds up queries" }, 1);

                await AddQuestionWithAnswers(context, dbExam1.Id, 4,
                    "Which SQL JOIN returns only matching rows from both tables?",
                    new[] { "LEFT JOIN", "RIGHT JOIN", "INNER JOIN", "FULL OUTER JOIN" }, 2);

                await AddQuestionWithAnswers(context, dbExam1.Id, 5,
                    "What is the purpose of the GROUP BY clause?",
                    new[] { "Sort results", "Filter rows", "Aggregate rows sharing a common value", "Join tables" }, 2);

                // Exam 2 - Design & Normalization
                var dbExam2 = new Exam
                {
                    Title = "Database Systems - Design & Normalization",
                    Description = "ERD and database design principles.",
                    SubjectId = db.Id,
                    DurationMinutes = 40
                };
                context.Exams.Add(dbExam2);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, dbExam2.Id, 1,
                    "First Normal Form (1NF) requires that:",
                    new[] { "No partial dependencies exist", "No transitive dependencies exist", "All attributes are atomic (no repeating groups)", "All tables have a primary key" }, 2);

                await AddQuestionWithAnswers(context, dbExam2.Id, 2,
                    "Which normal form eliminates transitive dependencies?",
                    new[] { "1NF", "2NF", "3NF", "BCNF" }, 2);

                await AddQuestionWithAnswers(context, dbExam2.Id, 3,
                    "In an ERD, a diamond shape represents:",
                    new[] { "An entity", "An attribute", "A relationship", "A primary key" }, 2);

                await AddQuestionWithAnswers(context, dbExam2.Id, 4,
                    "A FOREIGN KEY constraint is used to:",
                    new[] { "Uniquely identify a row", "Enforce referential integrity between tables", "Speed up queries", "Prevent null values" }, 1);

                await AddQuestionWithAnswers(context, dbExam2.Id, 5,
                    "Which ACID property ensures a transaction is fully completed or fully rolled back?",
                    new[] { "Consistency", "Isolation", "Atomicity", "Durability" }, 2);

                // -------------------------------------------------------
                // SUBJECT 3: Operating Systems
                // -------------------------------------------------------
                var os = new Subject
                {
                    Name = "Operating Systems",
                    Description = "Processes, Threads, Memory Management, Scheduling, and File Systems."
                };
                context.Subjects.Add(os);
                await context.SaveChangesAsync();

                // Exam 1 - Processes & Scheduling
                var osExam1 = new Exam
                {
                    Title = "Operating Systems - Processes & Scheduling",
                    Description = "Process states, PCB, and CPU scheduling algorithms.",
                    SubjectId = os.Id,
                    DurationMinutes = 35
                };
                context.Exams.Add(osExam1);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, osExam1.Id, 1,
                    "Which CPU scheduling algorithm may cause starvation for low-priority processes?",
                    new[] { "Round Robin", "FCFS", "Priority Scheduling", "SJF" }, 2);

                await AddQuestionWithAnswers(context, osExam1.Id, 2,
                    "The Process Control Block (PCB) stores:",
                    new[] { "User files only", "Process state, program counter, and CPU registers", "Only the process ID", "Memory pages" }, 1);

                await AddQuestionWithAnswers(context, osExam1.Id, 3,
                    "Round Robin scheduling uses a concept called:",
                    new[] { "Priority queue", "Multilevel feedback", "Time quantum", "Burst time" }, 2);

                await AddQuestionWithAnswers(context, osExam1.Id, 4,
                    "A process moves from Running to Waiting state when it:",
                    new[] { "Is preempted by the scheduler", "Requests I/O or waits for an event", "Completes execution", "Is created" }, 1);

                await AddQuestionWithAnswers(context, osExam1.Id, 5,
                    "What is a deadlock?",
                    new[] { "A CPU scheduling conflict", "A situation where processes wait indefinitely for resources held by each other", "An out-of-memory error", "A type of page fault" }, 1);

                // Exam 2 - Memory Management
                var osExam2 = new Exam
                {
                    Title = "Operating Systems - Memory Management",
                    Description = "Paging, segmentation, virtual memory, and page replacement.",
                    SubjectId = os.Id,
                    DurationMinutes = 40
                };
                context.Exams.Add(osExam2);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, osExam2.Id, 1,
                    "Paging divides memory into fixed-size units called:",
                    new[] { "Segments", "Frames", "Blocks", "Sectors" }, 1);

                await AddQuestionWithAnswers(context, osExam2.Id, 2,
                    "Which page replacement algorithm replaces the page that will not be used for the longest time in the future?",
                    new[] { "LRU", "FIFO", "Optimal (OPT)", "Clock" }, 2);

                await AddQuestionWithAnswers(context, osExam2.Id, 3,
                    "Virtual memory allows a process to use more memory than physically available by using:",
                    new[] { "Additional RAM", "Cache memory", "Disk space as an extension of RAM", "CPU registers" }, 2);

                await AddQuestionWithAnswers(context, osExam2.Id, 4,
                    "A page fault occurs when:",
                    new[] { "A page is found in physical memory", "The CPU is idle", "A referenced page is not in physical memory", "The TLB hits successfully" }, 2);

                await AddQuestionWithAnswers(context, osExam2.Id, 5,
                    "Internal fragmentation is a problem associated with:",
                    new[] { "Segmentation", "Dynamic partitioning", "Paging with fixed-size frames", "Linked allocation" }, 2);

                // -------------------------------------------------------
                // SUBJECT 4: Computer Networks
                // -------------------------------------------------------
                var cn = new Subject
                {
                    Name = "Computer Networks",
                    Description = "OSI Model, TCP/IP, Routing, Protocols, and Network Security."
                };
                context.Subjects.Add(cn);
                await context.SaveChangesAsync();

                // Exam 1 - OSI & Protocols
                var cnExam1 = new Exam
                {
                    Title = "Computer Networks - OSI & Protocols",
                    Description = "OSI layers, TCP/IP, and common network protocols.",
                    SubjectId = cn.Id,
                    DurationMinutes = 35
                };
                context.Exams.Add(cnExam1);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, cnExam1.Id, 1,
                    "How many layers does the OSI model have?",
                    new[] { "4", "5", "6", "7" }, 3);

                await AddQuestionWithAnswers(context, cnExam1.Id, 2,
                    "Which OSI layer is responsible for end-to-end communication and error recovery?",
                    new[] { "Network", "Session", "Transport", "Data Link" }, 2);

                await AddQuestionWithAnswers(context, cnExam1.Id, 3,
                    "HTTP operates at which layer of the OSI model?",
                    new[] { "Transport", "Session", "Presentation", "Application" }, 3);

                await AddQuestionWithAnswers(context, cnExam1.Id, 4,
                    "Which protocol is used to assign IP addresses automatically to devices?",
                    new[] { "DNS", "FTP", "DHCP", "SMTP" }, 2);

                await AddQuestionWithAnswers(context, cnExam1.Id, 5,
                    "TCP differs from UDP primarily because TCP:",
                    new[] { "Is faster", "Is connectionless", "Provides reliable, ordered delivery", "Uses less bandwidth" }, 2);

                // Exam 2 - IP & Routing
                var cnExam2 = new Exam
                {
                    Title = "Computer Networks - IP & Routing",
                    Description = "IP addressing, subnetting, and routing protocols.",
                    SubjectId = cn.Id,
                    DurationMinutes = 40
                };
                context.Exams.Add(cnExam2);
                await context.SaveChangesAsync();

                await AddQuestionWithAnswers(context, cnExam2.Id, 1,
                    "An IPv4 address is how many bits long?",
                    new[] { "16", "32", "64", "128" }, 1);

                await AddQuestionWithAnswers(context, cnExam2.Id, 2,
                    "What is the subnet mask for a /24 network?",
                    new[] { "255.0.0.0", "255.255.0.0", "255.255.255.0", "255.255.255.128" }, 2);

                await AddQuestionWithAnswers(context, cnExam2.Id, 3,
                    "Which device operates at the Network layer and forwards packets based on IP addresses?",
                    new[] { "Switch", "Hub", "Router", "Bridge" }, 2);

                await AddQuestionWithAnswers(context, cnExam2.Id, 4,
                    "OSPF is classified as which type of routing protocol?",
                    new[] { "Distance Vector", "Path Vector", "Link State", "Hybrid" }, 2);

                await AddQuestionWithAnswers(context, cnExam2.Id, 5,
                    "Which IP address range is reserved for private networks (Class C)?",
                    new[] { "10.0.0.0 – 10.255.255.255", "172.16.0.0 – 172.31.255.255", "192.168.0.0 – 192.168.255.255", "169.254.0.0 – 169.254.255.255" }, 2);

                // -------------------------------------------------------
                // SUBJECT 5: Software Engineering
                // -------------------------------------------------------
                var se = new Subject
                {
                    Name = "Software Engineering",
                    Description = "SDLC, Agile, Design Patterns, UML, and Software Architecture."
                };
                context.Subjects.Add(se);
                await context.SaveChangesAsync();

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