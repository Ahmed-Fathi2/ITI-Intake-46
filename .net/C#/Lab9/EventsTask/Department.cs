using System;
using System.Collections.Generic;

namespace EventsTask
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public List<Employee> Staff { get; set; } = new List<Employee>();

        public void AddStaff(Employee E)
        {
            if (E != null)
            {
                Staff.Add(E);
                E.EmployeeLayOff += RemoveStaff;
            }
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp)
            {
                if (Staff.Remove(emp))
                {
                    Console.WriteLine($"[Department] Employee {emp.EmployeeID} removed from Department {DeptName} because of {e.Cause}.");
                }
            }
        }
    }
}
