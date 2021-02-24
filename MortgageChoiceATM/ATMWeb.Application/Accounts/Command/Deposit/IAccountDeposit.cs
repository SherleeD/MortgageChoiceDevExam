using System.Threading.Tasks;

namespace ATMWeb.Application.Accounts.Command.Deposit
{
    public interface IAccountDeposit
    {
        Task Execute(AccountDepositModel model);
    }
}
