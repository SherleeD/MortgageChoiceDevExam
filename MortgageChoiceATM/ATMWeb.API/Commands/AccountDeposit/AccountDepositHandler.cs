using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using MediatR;
using Microsoft.Extensions.Logging;

using ATMWeb.Domain.Shared;
using ATMWeb.API.Interfaces;
using ATMWeb.Application.Accounts.Command.Deposit;
using ATMWeb.Application.Accounts.Queries.BalanceInquiry;


namespace ATMWeb.API.Commands.AccountDeposit
{
    public class AccountDepositHandler : IRequestHandler<AccountDepositCommand, AccountDepositResults>
    {
        private readonly ILogger<AccountDepositHandler> _logger;
        private readonly IAccountService _accountService;

        public AccountDepositHandler(
            ILogger<AccountDepositHandler> logger,
            IAccountService accountService
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public async Task<AccountDepositResults> Handle(AccountDepositCommand command, CancellationToken cancellationToken)
        {
            try 
            {
                _logger.LogInformation("Deposit transaction process started.");

                //check account
                BalanceInquiryModel acctBalance = new BalanceInquiryModel();
                acctBalance = await _accountService.BalanceInquiry(command.AcctId);

                if (acctBalance == null)
                {
                    return new AccountDepositResults
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        MessageDetails = ManageAccountStatus.InvalidAccountNumber                        
                    };
                }

                AccountDepositModel acctDeposit = new AccountDepositModel();

                acctDeposit.AcctId = command.AcctId;
                acctDeposit.TransactionType = command.TransactionType;
                acctDeposit.TransactionAmount = command.TransactionAmount;

                await _accountService.AccountDeposit(acctDeposit);

                return new AccountDepositResults
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Message = Convert.ToString(HttpStatusCode.OK),
                    MessageDetails = ManageAccountStatus.DepositSuccess,
                    TranId = acctDeposit.TranId
                };

            }
            catch (Exception ex)
            {
                _logger.LogError("Error saving deposit transaction : {ExceptionMessage}", ex.ToString());

                return new AccountDepositResults
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Message = Convert.ToString(HttpStatusCode.InternalServerError),
                    MessageDetails = ManageAccountStatus.DepositFailed
                };
            }
        }

    }
}
