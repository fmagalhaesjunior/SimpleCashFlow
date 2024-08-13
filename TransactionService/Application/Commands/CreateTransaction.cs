using Application.Validators;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands
{
    public record CreateTransactionCommand : IRequest
    {
        public DateTime TransactionDate { get; init; }
        public decimal Amount { get; init; }
        public string Description { get; init; }

        [AllowedValues("Credit", "Debit")]
        public required string Type { get; init; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly IService<Transaction> _service;
        public CreateTransactionCommandHandler(IService<Transaction> service)
        {
            _service = service;
        }

        public Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            _service.Add<CreateTransactionCommand, TransactionValidator>(request);
            return Task.CompletedTask;
        }
    }
}
