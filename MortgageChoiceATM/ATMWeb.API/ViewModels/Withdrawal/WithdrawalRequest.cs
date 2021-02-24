
namespace ATMWeb.API.ViewModels.Withdrawal
{
    public class WithdrawalRequest
    {
        public int AcctId { get; set; }
        public int TransactionType { get; set; }
        public double AmountWithdraw { get; set; }

        public WithdrawalRequest()
        { 
        }

        protected WithdrawalRequest(int acctId, int transactionType, double amountWithdraw) : this()
        {
            AcctId = acctId;
            TransactionType = transactionType;
            AmountWithdraw = amountWithdraw;
        }

    }
}
