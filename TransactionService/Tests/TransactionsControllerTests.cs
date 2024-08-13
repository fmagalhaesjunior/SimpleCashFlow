using Application.Commands;
using Application.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Tests
{
    public class TransactionsControllerTests : IClassFixture<WebApplicationFactory<API.Startup>>
    {
        private readonly HttpClient _client;
        public TransactionsControllerTests(WebApplicationFactory<API.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateTransaction_ShouldReturnOk()
        {
            var command = new CreateTransactionCommand
            {
                TransactionDate = DateTime.UtcNow,
                Amount = 100.0m,
                Description = "Test transaction",
                Type = "Credit"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/transactions", command);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        [Fact]
        public async Task GetTransactionById_ShouldReturnOk_WithTransactionData()
        {
            // Arrange
            var transactionId = Guid.NewGuid(); // Você pode precisar adicionar uma transação antes para garantir que existe
                                                // Act
            var response = await _client.GetAsync($"/api/transactions/{transactionId}");

            // Assert
            response.EnsureSuccessStatusCode();
            var transaction = await response.Content.ReadFromJsonAsync<GetTransactionResponse>();
            Assert.NotNull(transaction);
            Assert.Equal(transactionId, transaction.Id);
        }

    }
}
