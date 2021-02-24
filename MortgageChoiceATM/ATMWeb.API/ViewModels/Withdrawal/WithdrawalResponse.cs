
namespace ATMWeb.API.ViewModels.Withdrawal
{
    public class WithdrawalResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public WithdrawalResponsePayload Payload { get; set; }
    }
}
