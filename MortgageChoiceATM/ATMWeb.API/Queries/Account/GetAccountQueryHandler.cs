using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using MediatR;
using Microsoft.Extensions.Logging;

using ATMWeb.Domain.Shared;
using ATMWeb.API.Interfaces;
using ATMWeb.Application.Accounts.Queries.GetAccountDetail;

using BC = BCrypt.Net.BCrypt;

namespace ATMWeb.API.Queries.Account
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountResult>
    {
        private readonly ILogger<GetAccountQueryHandler> _logger;
        private readonly IAccountService _accountService;

        public GetAccountQueryHandler(
            ILogger<GetAccountQueryHandler> logger,
            IAccountService accountService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public async Task<GetAccountResult> Handle(GetAccountQuery query, CancellationToken cancellationToken)
        {
            
            try
            {
                AccountDetailModel acctDetails = new AccountDetailModel();
                acctDetails = await _accountService.GetAccountDetail(query.AccountNumber, query.AccountPIN);               
                
                if (acctDetails != null)
                {
                    //Validate PIN
                    if (!BC.Verify(query.AccountPIN, acctDetails.AccountPIN))
                    {
                        return new GetAccountResult
                        {
                            StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                            Message = Convert.ToString(HttpStatusCode.OK),
                            MessageDetails = ManageAccountStatus.InvalidAccountPIN,
                            AcctId = acctDetails.AcctId,
                            FirstName = acctDetails.FirstName,
                            MiddleName = acctDetails.MiddleName,
                            LastName = acctDetails.LastName,
                            AccountNumber = acctDetails.AccountNumber
                        };
                    }
                    else
                    {
                        return new GetAccountResult
                        {
                            StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                            Message = Convert.ToString(HttpStatusCode.OK),
                            MessageDetails = ManageAccountStatus.AccountDetailRetrieveSuccessful,
                            AcctId = acctDetails.AcctId,
                            FirstName = acctDetails.FirstName,
                            MiddleName = acctDetails.MiddleName,
                            LastName = acctDetails.LastName,
                            AccountNumber = acctDetails.AccountNumber,
                            AccountPIN = acctDetails.AccountPIN,
                            AccountType = acctDetails.AccountType,
                            AccountStatus = acctDetails.AccountStatus,
                            InitialAmountDeposit = acctDetails.InitialAmountDeposit,
                            DateCreated = acctDetails.DateCreated,
                            DateUpdated = acctDetails.DateUpdated
                        };
                    }
                }
                else
                {
                    return new GetAccountResult
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

                return new GetAccountResult
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                    Message = Convert.ToString(HttpStatusCode.InternalServerError),
                    MessageDetails = ManageAccountStatus.AccountDetailRetrieveFailed
                };            
            }

        }

    }
}
