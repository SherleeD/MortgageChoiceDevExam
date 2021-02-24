using System;

namespace ATMWeb.Application.Accounts.Command.Deposit
{
    public class AccountDepositModel
    {
        public int TranId { get; set; }
        public int AcctId { get; set; }
        public int TransactionType { get; set; }
        public double TransactionAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
