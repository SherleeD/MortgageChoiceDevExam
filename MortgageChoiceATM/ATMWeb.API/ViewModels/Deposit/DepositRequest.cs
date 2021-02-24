
namespace ATMWeb.API.ViewModels.Deposit
{
    public class DepositRequest
    {
        public int AcctId { get; set; }
        public int TransactionType { get; set; }
        public double AmountDeposit { get; set; }

        public DepositRequest()
        { 
        }

        protected DepositRequest(int acctId, int transactionType, double amountDeposit) : this()
        {
            AcctId = acctId;
            TransactionType = transactionType;
            AmountDeposit = amountDeposit;
        }

    }
}
