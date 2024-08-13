using Core.Interfaces;
using MediatR;
using System.Transactions;

namespace Application.Commands
{
    public record DeleteTransactionCommand(Guid id) : IRequest;

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly IService<Transaction> _service;
        public DeleteTransactionCommandHandler(IService<Transaction> service)
        {
            _service = service;
        }
        public Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionDb = _service.GetById<Transaction>(request.id);
            if (transactionDb == null)
                throw new ArgumentNullException("Transação não encontrada.");

            _service.Remove(transactionDb);
            return Task.CompletedTask;
        }
    }
}
