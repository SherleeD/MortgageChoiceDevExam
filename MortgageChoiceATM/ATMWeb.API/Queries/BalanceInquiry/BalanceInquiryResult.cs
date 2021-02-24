
namespace ATMWeb.API.Queries.BalanceInquiry
{
    public class BalanceInquiryResult
    {
        public string Message { get; set; }
        public string MessageDetails { get; set; }
        public int StatusCode { get; set; }

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
