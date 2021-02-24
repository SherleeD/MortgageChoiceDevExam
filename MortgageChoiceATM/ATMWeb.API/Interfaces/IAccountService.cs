using System.Threading.Tasks;

using ATMWeb.Application.Accounts.Queries.GetAccountDetail;
using ATMWeb.Application.Accounts.Queries.BalanceInquiry;

using ATMWeb.Application.Accounts.Command.Deposit;
using ATMWeb.Application.Accounts.Command.Withdrawal;

namespace ATMWeb.API.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDetailModel> GetAccountDetail(string acctNumber, string acctPIN);

        Task<int> AccountDeposit(AccountDepositModel accountDepositModel);

        Task<int> AccountWithdrawal(AccountWithdrawalModel accountWithdrawalModel);

        Task<BalanceInquiryModel> BalanceInquiry(int AcctId);

    }
}
