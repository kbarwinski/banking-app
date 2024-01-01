using BankingBackend.Application.Features.TransactionFeatures.Commands.CreateTransaction;
using BankingBackend.Application.Features.TransactionFeatures.Commands.DeleteTransaction;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransaction;
using BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingBackend.API.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetTransactionsQueryResponse>> GetAll([FromQuery] GetTransactionsQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TransactionViewModel>> Get(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetTransactionQuery(id);

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionViewModel>> Create([FromBody] TransactionBaseModel model, CancellationToken cancellationToken)
        {
            var request = new CreateTransactionCommand(model);

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteTransactionCommand(id);

            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
    }
}