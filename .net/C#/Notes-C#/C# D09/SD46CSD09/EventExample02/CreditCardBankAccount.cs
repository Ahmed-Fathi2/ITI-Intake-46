using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample02
{
    public class CreditCardBankAccount:BankAccount
    {
        public decimal  Limit { get; set; }


        protected override void OnUnderBalanced(UnderBalancedEventArgs args)
        {
            if (Limit < args.Difference)
            //keep old behavior
            { base.OnUnderBalanced(args); }
        }
    }
}
