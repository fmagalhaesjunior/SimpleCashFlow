using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : AbstractController<TransactionsController>
    {
        private readonly IMediator _mediator;
        public TransactionsController(ILogger<TransactionsController> logger, IMediator mediator) 
            : base(logger)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionCommand request) =>
            Execute(() => _mediator.Send(request));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid idTransaction) =>
            Execute(() => _mediator.Send(new GetTransactionByIdQuery(idTransaction)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) =>
            Execute(() => _mediator.Send(new DeleteTransactionCommand(id)));
    }
}
