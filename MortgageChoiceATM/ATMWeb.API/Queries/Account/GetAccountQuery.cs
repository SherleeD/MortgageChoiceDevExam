using MediatR;

namespace ATMWeb.API.Queries.Account
{
    public class GetAccountQuery : IRequest<GetAccountResult>
    {
        public string AccountNumber { get; set; }                
        public string AccountPIN { get; set; }

        protected GetAccountQuery()
        { 
        }

        public GetAccountQuery(string accountNumber, string accountPIN) : this()
        {
            AccountNumber = accountNumber;            
            AccountPIN = accountPIN;
        }

    }
}
