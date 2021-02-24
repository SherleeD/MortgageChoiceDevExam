using System;
using System.Threading.Tasks;

using ATMWeb.Domain;
using ATMWeb.Persistence;

namespace ATMWeb.Application.Accounts.Command.Withdrawal
{
    public class AccountWithdrawal : IAccountWithdrawal
    {
        public readonly ATMWebContext _context;

        public AccountWithdrawal(ATMWebContext context)
        {
            _context = context;
        }
        public async Task Execute(AccountWithdrawalModel model)
        {
            var entity = new AccountTransaction
            {
                AcctId = model.AcctId,
                TransactionType = model.TransactionType,
                TransactionAmount = model.TransactionAmount,
                DateCreated = DateTime.UtcNow
            };

            _context.AccountTransactions.Add(entity);

            await _context.SaveChangesAsync();

            //return auto-generated transaction id
            model.TranId = entity.TranId;
        }

    }
}
