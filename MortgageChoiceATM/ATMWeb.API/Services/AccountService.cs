using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using ATMWeb.API.Interfaces;
using ATMWeb.Application.Accounts.Queries.GetAccountDetail;
using ATMWeb.Application.Accounts.Queries.BalanceInquiry;

using ATMWeb.Application.Accounts.Command.Deposit;
using ATMWeb.Application.Accounts.Command.Withdrawal;


namespace ATMWeb.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IGetAccountDetail _getAccountDetail;
        private readonly IAccountDeposit _accountDeposit;
        private readonly IAccountWithdrawal _accountWithdrawal;
        private readonly IBalanceInquiry _balanceInquiry;


        public AccountService(
            ILogger<AccountService> logger,
            IGetAccountDetail getAccountDetail,
            IAccountDeposit accountDeposit,
            IAccountWithdrawal accountWithdrawal,
            IBalanceInquiry balanceInquiry
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _getAccountDetail = getAccountDetail;
            _accountDeposit = accountDeposit;
            _accountWithdrawal = accountWithdrawal;
            _balanceInquiry = balanceInquiry;
        }                

        public async Task<AccountDetailModel> GetAccountDetail(string acctNumber, string acctPIN)
        {
            return await _getAccountDetail.Execute(acctNumber, acctPIN);        
        }

        public async Task<int> AccountDeposit(AccountDepositModel accountDepositModel)
        {
            //call application command to create the deposit transaction and return the tranid generated
            await _accountDeposit.Execute(accountDepositModel);

            return accountDepositModel.TranId;
        }

        public async Task<int> AccountWithdrawal(AccountWithdrawalModel accountWithdrawalModel)
        {
            //call application command to create the deposit transaction and return the tranid generated
            await _accountWithdrawal.Execute(accountWithdrawalModel);

            return accountWithdrawalModel.TranId;
        }

        public async Task<BalanceInquiryModel> BalanceInquiry(int AcctId)
        {
            return await _balanceInquiry.Execute(AcctId);
        }


    }
}
