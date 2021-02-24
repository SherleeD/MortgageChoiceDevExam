using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using MediatR;
using Microsoft.Extensions.Logging;

using ATMWeb.Domain.Shared;
using ATMWeb.API.Interfaces;
using ATMWeb.Application.Accounts.Command.Withdrawal;
using ATMWeb.Application.Accounts.Queries.BalanceInquiry;

namespace ATMWeb.API.Commands.AccountWithdrawal
{
    public class AccountWithdrawalHandler : IRequestHandler<AccountWithdrawalCommand, AccountWithdrawalResults>
    {
        private readonly ILogger<AccountWithdrawalHandler> _logger;
        private readonly IAccountService _accountService;

        public AccountWithdrawalHandler(
            ILogger<AccountWithdrawalHandler> logger,
            IAccountService accountService
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public async Task<AccountWithdrawalResults> Handle(AccountWithdrawalCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Deposit transaction process started.");

                //check account
                BalanceInquiryModel acctBalance = new BalanceInquiryModel();
                acctBalance = await _accountService.BalanceInquiry(command.AcctId);

                if (acctBalance == null)
                {
                    return new AccountWithdrawalResults
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        MessageDetails = ManageAccountStatus.InvalidAccountNumber
                    };
                }

                if (command.TransactionAmount > acctBalance.AvailableBalance)
                {
                    return new AccountWithdrawalResults
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        MessageDetails = ManageAccountStatus.InsufficientFunds
                    };
                }

                AccountWithdrawalModel acctWithdrawal = new AccountWithdrawalModel();

                acctWithdrawal.AcctId = command.AcctId;
                acctWithdrawal.TransactionType = command.TransactionType;
                acctWithdrawal.TransactionAmount = command.TransactionAmount;

                await _accountService.AccountWithdrawal(acctWithdrawal);

                return new AccountWithdrawalResults
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Message = Convert.ToString(HttpStatusCode.OK),
                    MessageDetails = ManageAccountStatus.WithdrawalSuccess,
                    TranId = acctWithdrawal.TranId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error saving withdrawal transaction : {ExceptionMessage}", ex.ToString());

                return new AccountWithdrawalResults
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Message = Convert.ToString(HttpStatusCode.InternalServerError),
                    MessageDetails = ManageAccountStatus.WithdrawalFailed
                };
            }
        }

    }
}
