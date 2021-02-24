using System.Threading.Tasks;

namespace ATMWeb.Application.Accounts.Queries.GetAccountDetail
{
    public interface IGetAccountDetail
    {
        Task<AccountDetailModel> Execute(string acctNumber, string acctPIN);
    }
}
