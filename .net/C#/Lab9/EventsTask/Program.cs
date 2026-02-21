namespace EventsTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Setup Department and Club
            Department hrDept = new Department { DeptID = 1, DeptName = "HR" };
            Club socialClub = new Club { ClubID = 1, ClubName = "Socialites" };

            // 2. Create Employees
            Employee emp1 = new Employee { EmployeeID = 101, BirthDate = new DateTime(1960, 1, 1), VacationStock = 10 };
            SalesPerson sales1 = new SalesPerson { EmployeeID = 201, BirthDate = new DateTime(1985, 5, 10), AchievedTarget = 50 };
            BoardMember board1 = new BoardMember { EmployeeID = 301, BirthDate = new DateTime(1950, 10, 15) };

            // 3. Register to Dept and Club
            hrDept.AddStaff(emp1);
            hrDept.AddStaff(sales1);
            hrDept.AddStaff(board1);

            socialClub.AddMember(emp1);
            socialClub.AddMember(sales1);
            socialClub.AddMember(board1);

            Console.WriteLine("--- Testing Retirement (Age > 60) for emp1 ---");
            emp1.EndOfYearOperation(); // 1960 target age > 60 in 2026

            Console.WriteLine("\n--- Testing Vacation Stock < 0 for sales1 (Should NOT fire) ---");
            sales1.RequestVacation(DateTime.Now, DateTime.Now.AddDays(5));

            Console.WriteLine("\n--- Testing Target Failure for sales1 ---");
            sales1.CheckTarget(100); // 50 < 100

            Console.WriteLine("\n--- Testing Negative Vacation for emp1 (already fired but let's see) ---");
            emp1.RequestVacation(DateTime.Now, DateTime.Now.AddDays(20)); // Stock 10 - 20 = -10

            Console.WriteLine("\n--- Testing Board Member Retirement (Should NOT fire) ---");
            board1.EndOfYearOperation(); // 1950 age > 60 but board member

            Console.WriteLine("\n--- Testing Board Member Resignation ---");
            board1.Resign();

            Console.WriteLine("\n--- Final Counts ---");
            Console.WriteLine($"HR Staff Count: {hrDept.Staff.Count}");
            Console.WriteLine($"Social Club Member Count: {socialClub.Members.Count}");
        }
    }
}
