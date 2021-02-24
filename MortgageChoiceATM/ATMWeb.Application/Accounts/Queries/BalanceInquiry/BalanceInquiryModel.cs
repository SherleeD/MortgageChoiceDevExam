using System;

namespace ATMWeb.Application.Accounts.Queries.BalanceInquiry
{
    public class BalanceInquiryModel
    {
        public int AcctId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountPIN { get; set; }
        public int AccountType { get; set; }
        public int AccountStatus { get; set; }
        public double InitialAmountDeposit { get; set; }
        public double AvailableBalance { get; set; }
    }
}
