using System;

namespace EventsTask
{
    public class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget < Quota)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.FailedTarget });
                return false;
            }
            return true;
        }

       
        public override bool RequestVacation(DateTime From, DateTime To)
        {
            return false; 
        }
        
        // SalesPerson still retires at 60? 
        // "Company will Lay off All Type of Employees in Two Cases: Stock < 0, Age > 60"
        // But SalesPerson specific rule: "Will not be Fired if his/her Vacation Stock < 0"
        // It doesn't say they won't be fired for Age > 60.
    }
}
