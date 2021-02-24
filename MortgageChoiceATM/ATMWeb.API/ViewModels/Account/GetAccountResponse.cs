
namespace ATMWeb.API.ViewModels.Account
{
    public class GetAccountResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string MessageDetail { get; set; }

        public GetAccountResponsePayload Payload { get; set; }
    }
}
