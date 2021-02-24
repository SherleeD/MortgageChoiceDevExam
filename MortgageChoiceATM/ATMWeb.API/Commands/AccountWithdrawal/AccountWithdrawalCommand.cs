using MediatR;

namespace ATMWeb.API.Commands.AccountWithdrawal
{
    public class AccountWithdrawalCommand :IRequest<AccountWithdrawalResults>
    {
        public int AcctId { get; set; }
        public int TransactionType { get; set; }
        public double TransactionAmount { get; set; }

        protected AccountWithdrawalCommand()
        {         
        }
        public AccountWithdrawalCommand(int acctId, int transactionType, double transactionAmount) : this()
        {
            AcctId = acctId;
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
        }

    }
}
