using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

using MediatR;
using Microsoft.Extensions.Logging;

using ATMWeb.API.ViewModels.Account;
using ATMWeb.API.Queries.Account;

using ATMWeb.API.ViewModels.BalanceInquiry;
using ATMWeb.API.Queries.BalanceInquiry;

using ATMWeb.API.ViewModels.Deposit;
using ATMWeb.API.Commands.AccountDeposit;

using ATMWeb.API.ViewModels.Withdrawal;
using ATMWeb.API.Commands.AccountWithdrawal;


namespace ATMWeb.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(
            ILogger<AccountController> logger,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //Get: api/Account
        [HttpPost]
        public async Task<IActionResult> GetAccountDetail([FromBody] GetAccountRequest request)
        {
            try
            {
                _logger.LogInformation("Get account number(Account Number: {AccountNumber}) with account type {AccountType}.", request.AccountNumber, request.AccountPIN);

                //validate parameters
                if (request.AccountNumber.Length == 0)
                {
                    _logger.LogInformation("No account number found from request.");

                    return new JsonResult(new GetAccountResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new GetAccountResponsePayload()
                        {
                            MessageDetail = "No account number found."
                        }
                    });
                }


                if (request.AccountPIN.Length == 0)
                {
                    _logger.LogInformation("No account PIN found from request.");

                    return new JsonResult(new GetAccountResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new GetAccountResponsePayload()
                        {
                            MessageDetail = "No account PIN found."
                        }
                    });
                }


                //call query handler 
                var query = new GetAccountQuery(request.AccountNumber, request.AccountPIN);
                var queryResult = await _mediator.Send(query);

                return new JsonResult(new GetAccountResponse()
                {
                    StatusCode = queryResult.StatusCode,
                    Message = queryResult.Message,
                    MessageDetail = queryResult.MessageDetails,
                    Payload = new GetAccountResponsePayload()
                    {
                        AcctId = queryResult.AcctId,
                        FirstName = queryResult.FirstName,
                        MiddleName = queryResult.MiddleName,
                        LastName = queryResult.LastName,
                        AccountNumber = queryResult.AccountNumber,
                        AccountPIN = queryResult.AccountPIN,
                        AccountType = queryResult.AccountType,
                        AccountStatus = queryResult.AccountStatus,
                        InitialAmountDeposit = queryResult.InitialAmountDeposit,
                        DateCreated = queryResult.DateCreated,
                        DateUpdated = queryResult.DateUpdated,
                        MessageDetail = queryResult.MessageDetails
                    }
                });

            }
            catch (Exception ex)
            {
                _logger.LogError("Get account number request failed. Exception error message: {exceptionMessage}", ex.ToString());

                return new JsonResult(new GetAccountResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = Convert.ToString(HttpStatusCode.BadRequest),
                    MessageDetail = "Get contact group list request failed. Exception error message: " + ex.ToString()
                });
            }
        }

        // Get: api/account/acctId
        [HttpGet("{acctId}")]
        public async Task<IActionResult> BalanceInquiry(int acctId)
        {
            try
            {
                //validate parameters                
                if (acctId == 0)
                {
                    _logger.LogInformation("Invalid account.");

                    return new JsonResult(new BalanceInquiryResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new BalanceInquiryResponsePayload()
                        {
                            MessageDetail = "Invalid account."
                        }
                    });
                }

                //call query handler                 
                var query = new BalanceInquiryQuery(acctId);
                var queryResult = await _mediator.Send(query);

                return new JsonResult(new BalanceInquiryResponse()
                {
                    StatusCode = queryResult.StatusCode,
                    Message = queryResult.Message,
                    MessageDetail = queryResult.MessageDetails,
                    Payload = new BalanceInquiryResponsePayload()
                    {
                        AcctId = queryResult.AcctId,
                        FirstName = queryResult.FirstName,
                        MiddleName = queryResult.MiddleName,
                        LastName = queryResult.LastName,
                        AccountNumber = queryResult.AccountNumber,
                        AccountType = queryResult.AccountType,
                        InitialAmountDeposit = queryResult.InitialAmountDeposit,
                        AvailableBalance = queryResult.AvailableBalance,
                        MessageDetail = queryResult.MessageDetails
                    }
                });

            }
            catch (Exception ex)
            {
                _logger.LogError("Balance inquiry request failed. Exception error message: {exceptionMessage}", ex.ToString());

                return new JsonResult(new BalanceInquiryResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = Convert.ToString(HttpStatusCode.BadRequest),
                    MessageDetail = "Balance inquiryrequest failed. Exception error message: " + ex.ToString()
                });
            }
        }

        // Post: api/account/AccountDeposit
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AccountDeposit([FromBody] DepositRequest request)
        {
            try
            {
                _logger.LogInformation("Received account deposit request.");

                //validate parameters
                if (request.AcctId == 0)
                {
                    _logger.LogInformation("Invalid account.");

                    return new JsonResult(new DepositResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new DepositResponsePayload()
                        {
                            MessageDetail = "Invalid account."
                        }
                    });
                }

                if (request.TransactionType != 3)
                {
                    _logger.LogInformation("Invalid transaction type.");

                    return new JsonResult(new DepositResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new DepositResponsePayload()
                        {
                            MessageDetail = "Invalid transaction type."
                        }
                    });
                }

                if (request.AmountDeposit == 0)
                {
                    _logger.LogInformation("No amount found to deposit.");

                    return new JsonResult(new DepositResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new DepositResponsePayload()
                        {
                            MessageDetail = "No amount found to deposit."
                        }
                    });
                }



                //call command handler 
                var command = new AccountDepositCommand(request.AcctId, request.TransactionType, request.AmountDeposit);
                var commandResult = await _mediator.Send(command);

                return new JsonResult(new DepositResponse()
                {
                    StatusCode = commandResult.StatusCode,
                    Message = commandResult.Message,
                    Payload = new DepositResponsePayload()
                    {
                        MessageDetail = commandResult.MessageDetails,
                        TranId = commandResult.TranId
                    }

                });

            }
            catch (Exception ex)
            {
                _logger.LogError("Account deposit request failed. Exception error message: {exceptionMessage}", ex.ToString());

                return new JsonResult(new DepositResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = Convert.ToString(HttpStatusCode.BadRequest),
                    Payload = new DepositResponsePayload()
                    {
                        MessageDetail = "Account Deposit request failed. Exception Error: " + ex.ToString()
                    }
                });
            }
        }

        // Post: api/account/AccountWithdrawal
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AccountWithdrawal([FromBody] WithdrawalRequest request)
        {
            try
            {
                _logger.LogInformation("Received account withdrawal request.");

                //validate parameters
                if (request.AcctId == 0)
                {
                    _logger.LogInformation("Invalid account.");

                    return new JsonResult(new WithdrawalResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new WithdrawalResponsePayload()
                        {
                            MessageDetail = "Invalid account."
                        }
                    });
                }

                if (request.TransactionType != 2)
                {
                    _logger.LogInformation("Invalid transaction type.");

                    return new JsonResult(new WithdrawalResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new WithdrawalResponsePayload()
                        {
                            MessageDetail = "Invalid transaction type."
                        }
                    });
                }

                if (request.AmountWithdraw == 0)
                {
                    _logger.LogInformation("No amount found to withdraw.");

                    return new JsonResult(new WithdrawalResponse()
                    {
                        StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                        Message = Convert.ToString(HttpStatusCode.OK),
                        Payload = new WithdrawalResponsePayload()
                        {
                            MessageDetail = "No amount found to withdraw."
                        }
                    });
                }

                //call balance inquiry here before calling withdrawal function

                //call command handler 
                var command = new AccountWithdrawalCommand(request.AcctId, request.TransactionType, request.AmountWithdraw);
                var commandResult = await _mediator.Send(command);

                return new JsonResult(new WithdrawalResponse()
                {
                    StatusCode = commandResult.StatusCode,
                    Message = commandResult.Message,
                    Payload = new WithdrawalResponsePayload()
                    {
                        MessageDetail = commandResult.MessageDetails,
                        TranId = commandResult.TranId
                    }

                });

            }
            catch (Exception ex)
            {
                _logger.LogError("Account withdrawal request failed. Exception error message: {exceptionMessage}", ex.ToString());

                return new JsonResult(new WithdrawalResponse()
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = Convert.ToString(HttpStatusCode.BadRequest),
                    Payload = new WithdrawalResponsePayload()
                    {
                        MessageDetail = "Account withdrawal request failed. Exception Error: " + ex.ToString()
                    }
                });
            }

        }
        
    }
}
