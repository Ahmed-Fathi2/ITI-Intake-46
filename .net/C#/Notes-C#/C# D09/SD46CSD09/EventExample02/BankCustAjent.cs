using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample02
{
    //subscriber
    public class BankCustAjent
    {
        public int AjentId { get; set; }
        public string AjentName { get; set; }

        public BankCustAjent()
        {
            AjentId = 10;
            AjentName = "Yossef";
        }

        //callback method
        public void WarnBankAccount(object sender, UnderBalancedEventArgs e)
        {
            if (sender is BankAccount left&& e.Difference>1000)
            {
                Console.WriteLine($"{AjentName} ajent warns {left.AccountName}  with -{e.Difference}!!!");
            }

        }
    }
}
