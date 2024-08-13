using Application.Responses;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.Queries
{
    public record GetTransactionByIdQuery(Guid TransactionId) : IRequest<GetTransactionResponse>;

    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, GetTransactionResponse>
    {
        private readonly IService<Transaction> _service;
        public GetTransactionByIdQueryHandler(IService<Transaction> service)
        {
            _service = service;
        }

        public Task<GetTransactionResponse> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transactionDb = _service.GetById<GetTransactionResponse>(request.TransactionId);
            if (transactionDb == null)
                throw new ArgumentNullException("Nenhuma transação encontrada.");
            return Task.FromResult(transactionDb);
        }
    }
}
