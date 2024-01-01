using BankingBackend.Application.Features.TransactionCategoryFeatures.Queries.GetTransactionCategories;
using BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingBackend.API.Controllers
{
    [ApiController]
    [Route("api/transactioncategories")]
    public class TransactionCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetTransactionsQueryResponse>> GetAll([FromQuery] GetTransactionCategoriesQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
    }
}
