using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample02
{
    //subscriber
    public static class BlackListAccounts
    {
        public static List<BankAccount> BlackListPeople { get; set; } = new List<BankAccount>();


        //callback method
        public static void AddToBlackList(object sender, UnderBalancedEventArgs e)
        {
            var right = sender as BankAccount;
            if (e.Difference > 1000)
            {
                Console.WriteLine($"Proceed to add {right.AccountName} to black list so that he/she has -{e.Difference}");
                BlackListPeople.Add(right);
            }
        }

        public static string DisplayBlackList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in BlackListPeople)
            {
                sb.Append(item.AccountName);
                sb.AppendLine();
            }
            return sb.ToString();
        }



    }
}
