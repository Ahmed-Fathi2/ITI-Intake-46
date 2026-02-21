using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample02
{
    public class EnterpriseBankAccount:BankAccount
    {
        public EnterpriseBankAccount()
        {
            AccountNo = 4567;
            AccountName = "AhmedCo";
            Balance = 15_000;
        }
        public bool Transfer(BankAccount _to,decimal _salary)
        {
            if (_salary>0 && this.Balance>_salary) 
            {
                _to.Balance += _salary;
                this.Balance-=_salary;
                return true;
            }
            else
            {
                var delta = _salary - this.Balance;
                //fire event
                //underBalanced.Invoke();
                this.OnUnderBalanced(new UnderBalancedEventArgs { Difference = delta });
                return false;

            }
        }
    }
}
