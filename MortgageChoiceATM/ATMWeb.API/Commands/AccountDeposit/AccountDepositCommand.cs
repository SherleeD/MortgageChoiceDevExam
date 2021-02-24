using MediatR;

namespace ATMWeb.API.Commands.AccountDeposit
{
    public class AccountDepositCommand : IRequest<AccountDepositResults>
    {
        public int AcctId { get; set; }
        public int TransactionType { get; set; }
        public double TransactionAmount { get; set; }

        protected AccountDepositCommand()
        { 
        }

        public AccountDepositCommand(int acctId, int transactionType, double transactionAmount) : this()
        {
            AcctId = acctId;
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
        }

    }
}
