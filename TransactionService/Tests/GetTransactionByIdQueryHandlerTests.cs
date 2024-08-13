using Application.Queries;
using Application.Responses;
using Core.Entities;
using Core.Interfaces;
using Moq;

namespace Tests
{
    public class GetTransactionByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTransactionResponse_WhenTransactionExists()
        {
            // Arrange
            var transactionId = Guid.NewGuid();
            var transaction = new GetTransactionResponse()
            {
                Id = transactionId,
                Amount = 100.0m,
                Description = "Test transaction",
                Type = "Credit"
            };
            var mockService = new Mock<IService<Transaction>>();
            mockService.Setup(s => s.GetById<GetTransactionResponse>(transactionId)).Returns(transaction);
            var handler = new GetTransactionByIdQueryHandler(mockService.Object);
            var query = new GetTransactionByIdQuery(transactionId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(transactionId, result.Id);
            Assert.Equal(transaction.Amount, result.Amount);
            Assert.Equal(transaction.Description, result.Description);
            Assert.Equal(transaction.Type, result.Type);
        }
    }
}
