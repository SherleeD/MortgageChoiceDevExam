
namespace ATMWeb.API.ViewModels.BalanceInquiry
{
    public class BalanceInquiryResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string MessageDetail { get; set; }

        public BalanceInquiryResponsePayload Payload { get; set; }
    }
}
