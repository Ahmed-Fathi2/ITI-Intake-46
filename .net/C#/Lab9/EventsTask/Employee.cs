using System;

namespace EventsTask
{
    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int VacationStock { get; set; }

        public virtual bool RequestVacation(DateTime From, DateTime To)
        {
            int requestedDays = (To - From).Days;
            if (VacationStock >= requestedDays)
            {
                VacationStock -= requestedDays;
                return true;
            }
            
            VacationStock -= requestedDays;
            if (VacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.VacationStockNegative });
            }
            return false;
        }

        public virtual void EndOfYearOperation()
        {
        
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate > DateTime.Now.AddYears(-age)) age--;

            if (age > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeOver60 });
            }
        }
        
        public override string ToString()
        {
            return $"ID: {EmployeeID}, VacationStock: {VacationStock}";
        }
    }
}
