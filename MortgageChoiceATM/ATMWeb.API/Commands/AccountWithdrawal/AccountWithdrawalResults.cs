
namespace ATMWeb.API.Commands.AccountWithdrawal
{
    public class AccountWithdrawalResults
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetails { get; set; }
        public int TranId { get; set; }
    }
}
