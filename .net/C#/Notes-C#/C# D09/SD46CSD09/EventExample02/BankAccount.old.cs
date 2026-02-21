using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample02
{
    ////publisher
    //public class BankAccount
    //{
    //    public int AccountNo { get; set; }
    //    public string AccountName { get; set; }
    //    public decimal Balance { get; set; }
    //    public BankAccount()
    //    {
    //        AccountNo = 12345;
    //        AccountName = "Hanaaa";
    //        Balance = 1000;
    //    }
    //    public BankAccount(int _accountNo,string _accountName,decimal _balance)
    //    {
    //        AccountNo = _accountNo;
    //        AccountName = _accountName;
    //        Balance = _balance;
    //    }

    //    public bool Debit(decimal _amount)
    //    {
    //        if (_amount > 0) 
    //        {
    //            this.Balance += _amount;
    //            return true;
    //        }
    //        return false;
    //    }

    //    public bool Credit(decimal _amount) 
    //    {
    //        if (_amount > 0 && Balance>_amount) 
    //        {
    //            Balance-= _amount;
    //            return true;
    //        }
    //        else
    //        {
    //            Balance -= _amount;
    //            ///Firing Event
    //            OnUnderBalanced();
    //            return false;
    //        }
    //    }
    //    #region Event Framework
    //    public event EventHandler underBalanced;

    //    protected virtual void OnUnderBalanced()
    //    {
    //        underBalanced?.Invoke(this,EventArgs.Empty);
    //    }
    //    #endregion
}