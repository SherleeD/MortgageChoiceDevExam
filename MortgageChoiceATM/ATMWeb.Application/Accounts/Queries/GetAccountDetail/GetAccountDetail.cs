using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ATMWeb.Persistence;

namespace ATMWeb.Application.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetail : IGetAccountDetail
    {
        private readonly ATMWebContext _context;

        public GetAccountDetail(ATMWebContext context)
        {
            _context = context;
        }

        public async Task<AccountDetailModel> Execute(string acctNumber, string acctPIN) 
        {
            var entity = await _context.Accounts
                .Where(x => x.AccountStatus == 1 && x.AccountNumber == acctNumber)
                .FirstOrDefaultAsync();

            if (entity == null)
                return null;            

            return new AccountDetailModel
            {
                AcctId =  entity.AcctId,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,                
                AccountNumber = entity.AccountNumber,
                AccountPIN = entity.AccountPIN,
                InitialAmountDeposit = entity.InitialAmountDeposit,
                AccountType = entity.AccountType,
                AccountStatus = entity.AccountStatus,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
            };
        }
    }
}
