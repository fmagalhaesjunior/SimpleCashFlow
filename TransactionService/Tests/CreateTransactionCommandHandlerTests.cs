using Application.Commands;
using Application.Validators;
using Core.Entities;
using Core.Interfaces;
using Moq;

namespace Tests
{
    public class CreateTransactionCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCallAddMethodOfService()
        {
            var mockService = new Mock<IService<Transaction>>();
            var handler = new CreateTransactionCommandHandler(mockService.Object);
            var command = new CreateTransactionCommand
            {
                TransactionDate = DateTime.UtcNow,
                Amount = 100.0m,
                Description = "Test transaction",
                Type = "Credit"
            };

            await handler.Handle(command, CancellationToken.None);
            mockService.Verify(s => s.Add<CreateTransactionCommand, TransactionValidator>(command), Times.Once);
        }
    }
}
