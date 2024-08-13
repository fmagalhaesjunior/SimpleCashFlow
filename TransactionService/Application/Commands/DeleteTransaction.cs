using Core.Interfaces;
using MediatR;
using Core.Entities;
using Newtonsoft.Json;

namespace Application.Commands
{
    public record DeleteTransactionCommand(Guid id) : IRequest;

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly IService<Transaction> _service;
        private readonly IMessageQueueService _messageQueueService;
        public DeleteTransactionCommandHandler(IService<Transaction> service, IMessageQueueService messageQueueService)
        {
            _service = service;
            _messageQueueService = messageQueueService;
        }
        public Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionDb = _service.GetById<Transaction>(request.id);
            if (transactionDb == null)
                throw new ArgumentNullException("Transação não encontrada.");
            
            var deleteDailySummary = new
            {
                Amount = transactionDb.Amount,
                Date = transactionDb.TransactionDate
            };
            _service.Remove(transactionDb);
            var message = JsonConvert.SerializeObject(deleteDailySummary);
            _messageQueueService.SendMessage("delete_summary", message);
            return Task.CompletedTask;
        }
    }
}
