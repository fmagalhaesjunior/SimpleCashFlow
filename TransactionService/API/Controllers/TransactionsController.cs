using Application.Requests;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : AbstractController<TransactionsController>
    {
        private readonly ITransactionUseCases _transactionUseCases;
        public TransactionsController(ILogger<TransactionsController> logger, ITransactionUseCases transactionUseCases) 
            : base(logger)
        {
            _transactionUseCases = transactionUseCases;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionRequest request) =>
            Execute(() => _transactionUseCases.CreateTransaction(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) =>
            Execute(() => _transactionUseCases.DeleteTransaction(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(Guid idTransaction) =>
            Execute(() => _transactionUseCases.GetTransactionById(idTransaction));

        [HttpGet("[action]/{description}")]
        public async Task<IActionResult> GetByDescription(string description) =>
            Execute(() => _transactionUseCases.GetTransactionByDescription(description));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDebit() =>
            Execute(() => _transactionUseCases.GetAllDebitTransactions());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCredit() =>
            Execute(() => _transactionUseCases.GetAllCreditTransactions());
    }
}
