using System;
using System.Collections.Generic;

namespace EventsTask
{
    public class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }
        public List<Employee> Members { get; set; } = new List<Employee>();

        public void AddMember(Employee E)
        {
            if (E != null)
            {
                Members.Add(E);
                E.EmployeeLayOff += RemoveMember;
            }
        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp)
            {
               
                if (emp is BoardMember)
                {
                    Console.WriteLine($"[Club] Board Member {emp.EmployeeID} stays in Club {ClubName} forever.");
                    return;
                }

            
                if (e.Cause == LayOffCause.VacationStockNegative)
                {
                    if (Members.Remove(emp))
                    {
                        Console.WriteLine($"[Club] Employee {emp.EmployeeID} removed from Club {ClubName} because of {e.Cause}.");
                    }
                }
                else
                {
                    Console.WriteLine($"[Club] Employee {emp.EmployeeID} stays in Club {ClubName} despite layoff cause: {e.Cause}.");
                }
            }
        }
    }
}
