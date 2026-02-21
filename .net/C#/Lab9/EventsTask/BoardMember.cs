using System;

namespace EventsTask
{
    public class BoardMember : Employee
    {
        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Resigned });
        }

     
        public override void EndOfYearOperation()
        {
           
        }

        public override bool RequestVacation(DateTime From, DateTime To)
        {
            return false;
        }
    }
}
