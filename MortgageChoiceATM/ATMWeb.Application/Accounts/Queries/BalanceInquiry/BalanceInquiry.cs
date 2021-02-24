using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ATMWeb.Persistence;

namespace ATMWeb.Application.Accounts.Queries.BalanceInquiry
{
    public class BalanceInquiry : IBalanceInquiry
    {
        private readonly ATMWebContext _context;

        public BalanceInquiry(ATMWebContext context)
        {
            _context = context;
        }

        public async Task<BalanceInquiryModel> Execute(int AcctId)
        {
            var entity = await _context.Accounts
                .Where(x => x.AccountStatus == 1 && x.AcctId == AcctId)
                .FirstOrDefaultAsync();

            if (entity == null)
                return null;

            double initialDeposit = entity.InitialAmountDeposit;                        
            double availableBalance = 0;

            var totalDepositTransaction = _context.AccountTransactions
                .Where(x => x.AcctId == AcctId && x.TransactionType == 3)
                .Sum(x => x.TransactionAmount);

            var totalWithdrawalTransaction = _context.AccountTransactions
                .Where(x => x.AcctId == AcctId && x.TransactionType == 2)
                .Sum(x => x.TransactionAmount);

            availableBalance = (initialDeposit + totalDepositTransaction) - totalWithdrawalTransaction;

            return new BalanceInquiryModel
            {
                AcctId = entity.AcctId,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                AccountNumber = entity.AccountNumber,                
                InitialAmountDeposit = entity.InitialAmountDeposit,
                AccountType = entity.AccountType,                
                AvailableBalance = availableBalance
            };
        }

    }
}
