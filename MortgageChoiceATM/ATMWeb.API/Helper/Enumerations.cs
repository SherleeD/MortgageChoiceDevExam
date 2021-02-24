using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMWeb.API.Helper
{
    public enum AccountTypes
    {        
        Savings,
        Current
    }

    public enum TransactionTypes
    {
        Inquiry,
        Withdrawal,
        Deposit
    }

}
