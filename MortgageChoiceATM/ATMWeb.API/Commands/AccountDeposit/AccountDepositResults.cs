
namespace ATMWeb.API.Commands.AccountDeposit
{
    public class AccountDepositResults
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageDetails { get; set; }
        public int TranId { get; set; }
    }
}
