using Application.Validators;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using Newtonsoft.Json;
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
        private readonly IMessageQueueService _messageQueueService;
        public CreateTransactionCommandHandler(IService<Transaction> service, IMessageQueueService messageQueueService)
        {
            _service = service;
            _messageQueueService = messageQueueService;
        }

        public CreateTransactionCommandHandler(IService<Transaction> service)
        {
            _service = service;
        }

        public Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            _service.Add<CreateTransactionCommand, TransactionValidator>(request);
            var dailySummary = new
            {
                date = request.TransactionDate,
                Type = request.Type,
                Amount = request.Amount
            };
            var message = JsonConvert.SerializeObject(dailySummary);
            _messageQueueService.SendMessage("create_summary", message);
            return Task.CompletedTask;
        }
    }
}
