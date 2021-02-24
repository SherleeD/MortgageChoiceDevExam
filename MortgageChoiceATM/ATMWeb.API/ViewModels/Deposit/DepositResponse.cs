
namespace ATMWeb.API.ViewModels.Deposit
{
    public class DepositResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public DepositResponsePayload Payload { get; set; }
    }
}
