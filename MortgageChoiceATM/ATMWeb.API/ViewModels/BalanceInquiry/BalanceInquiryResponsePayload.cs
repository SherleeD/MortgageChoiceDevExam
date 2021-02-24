using System;

namespace ATMWeb.API.ViewModels.BalanceInquiry
{
    public class BalanceInquiryResponsePayload
    {
        public string MessageDetail { get; set; }
        public int AcctId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }        
        public int AccountType { get; set; }        
        public double InitialAmountDeposit { get; set; }
        public double AvailableBalance { get; set; }
    }
}
