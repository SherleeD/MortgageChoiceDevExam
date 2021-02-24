using System.Threading.Tasks;

namespace ATMWeb.Application.Accounts.Command.Withdrawal
{
    public interface IAccountWithdrawal
    {
        Task Execute(AccountWithdrawalModel model);
    }
}
