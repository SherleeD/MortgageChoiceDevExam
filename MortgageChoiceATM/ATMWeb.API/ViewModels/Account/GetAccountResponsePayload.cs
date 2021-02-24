using System;

namespace ATMWeb.API.ViewModels.Account
{
    public class GetAccountResponsePayload
    {
        public string MessageDetail { get; set; }
        public int AcctId { get; set; }        
        public string FirstName { get; set; }       
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }        
        public string AccountPIN { get; set; }
        public int AccountType { get; set; }
        public int AccountStatus { get; set; }
        public double InitialAmountDeposit { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
