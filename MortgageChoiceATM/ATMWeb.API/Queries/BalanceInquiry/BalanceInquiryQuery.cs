using MediatR;

namespace ATMWeb.API.Queries.BalanceInquiry
{
    public class BalanceInquiryQuery : IRequest<BalanceInquiryResult>
    {
        public int AcctId { get; set; }

        protected BalanceInquiryQuery()
        { 
        }

        public BalanceInquiryQuery(int acctId) : this()
        {
            AcctId = acctId;
        }

    }
}
