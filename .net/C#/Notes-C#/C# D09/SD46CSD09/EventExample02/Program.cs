namespace EventExample02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount a1=new BankAccount();


            BankCustAjent ajent=new BankCustAjent();
            //link subscribers to publisher

            a1.underBalanced += ajent.WarnBankAccount;
            a1.underBalanced += BlackListAccounts.AddToBlackList;


            //a1.Credit(3200);


            EnterpriseBankAccount enterprise=new EnterpriseBankAccount();

            //link subscribers to publisher
            enterprise.underBalanced += ajent.WarnBankAccount;
            enterprise.underBalanced += BlackListAccounts.AddToBlackList;


            enterprise.Transfer(a1, 50_000);



            CreditCardBankAccount creditCard1 = new CreditCardBankAccount()
            {
                AccountNo = 7654,
                AccountName = "Omar",
                Balance=0,
                Limit=15_000
            };

            creditCard1.underBalanced += ajent.WarnBankAccount;
            creditCard1.underBalanced += BlackListAccounts.AddToBlackList;

            creditCard1.Credit(50_000);

        }
    }
}
