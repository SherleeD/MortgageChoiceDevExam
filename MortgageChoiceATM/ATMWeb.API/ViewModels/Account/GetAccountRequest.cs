
namespace ATMWeb.API.ViewModels.Account
{
    public class GetAccountRequest
    {
        public string AccountNumber { get; set; }
        public int AccountType { get; set; }
        public string AccountPIN { get; set; }


        protected GetAccountRequest()
        { }

        public GetAccountRequest(string accountNumber, int accountType, string accountPIN) : this()
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountPIN = accountPIN;
        }
    }
}
