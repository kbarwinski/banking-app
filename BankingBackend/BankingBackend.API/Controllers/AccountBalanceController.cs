using BankingBackend.Application.Features.TransactionFeatures.Models.AccountBalance;
using BankingBackend.Application.Features.TransactionFeatures.Queries.GetAccountBalance;
using BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingBackend.API.Controllers
{
    [ApiController]
    [Route("api/balance")]
    public class AccountBalanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountBalanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<AccountBalanceHistoryModel>> Get(CancellationToken cancellationToken)
        {
            var request = new GetAccountBalanceQuery();

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
