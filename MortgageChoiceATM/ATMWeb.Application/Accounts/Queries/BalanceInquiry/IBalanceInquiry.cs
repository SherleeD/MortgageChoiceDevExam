using System.Threading.Tasks;


namespace ATMWeb.Application.Accounts.Queries.BalanceInquiry
{
    public interface IBalanceInquiry
    {
        Task<BalanceInquiryModel> Execute(int AcctId);
    }
}
