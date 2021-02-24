using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using MediatR;
using Microsoft.Extensions.Logging;

using ATMWeb.Domain.Shared;
using ATMWeb.API.Interfaces;
using ATMWeb.Application.Accounts.Queries.BalanceInquiry;

namespace ATMWeb.API.Queries.BalanceInquiry
{
    public class BalanceInquiryQueryHandler : IRequestHandler<BalanceInquiryQuery, BalanceInquiryResult>
    {
        private readonly ILogger<BalanceInquiryQueryHandler> _logger;
        private readonly IAccountService _accountService;

        public BalanceInquiryQueryHandler(
            ILogger<BalanceInquiryQueryHandler> logger,
            IAccountService accountService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public async Task<BalanceInquiryResult> Handle(BalanceInquiryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                BalanceInquiryModel acctBalance = new BalanceInquiryModel();
                acctBalance = await _accountService.BalanceInquiry(query.AcctId);

                if (acctBalance != null)
                {
                    return new BalanceInquiryResult 
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        MessageDetails = ManageAccountStatus.BalanceInquirySuccess,
                        AcctId = acctBalance.AcctId,
                        FirstName = acctBalance.FirstName,
                        MiddleName = acctBalance.MiddleName,
                        LastName = acctBalance.LastName,
                        AccountNumber = acctBalance.AccountNumber,                        
                        AccountType = acctBalance.AccountType,                        
                        InitialAmountDeposit = acctBalance.InitialAmountDeposit,                      
                        AvailableBalance = acctBalance.AvailableBalance
                    };
                }
                else
                {
                    return new BalanceInquiryResult
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        MessageDetails = ManageAccountStatus.InvalidAccountNumber
                    };

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving account details : {ExceptionMessage}", ex.ToString());

                return new BalanceInquiryResult
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Message = Convert.ToString(HttpStatusCode.InternalServerError),
                    MessageDetails = ManageAccountStatus.BalanceInquiryFailed
                };
            }
        }
    }
}
