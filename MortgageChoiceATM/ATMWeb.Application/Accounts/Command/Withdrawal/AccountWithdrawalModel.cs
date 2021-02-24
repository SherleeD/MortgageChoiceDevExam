using System;
using System.Collections.Generic;
using System.Text;

namespace ATMWeb.Application.Accounts.Command.Withdrawal
{
    public class AccountWithdrawalModel
    {
        public int TranId { get; set; }
        public int AcctId { get; set; }
        public int TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
