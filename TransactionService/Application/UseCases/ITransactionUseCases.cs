using Application.Requests;
using Application.Responses;

namespace Application.UseCases
{
    public interface ITransactionUseCases
    {
        Task CreateTransaction(CreateTransactionRequest request);
        Task DeleteTransaction(Guid idTransaction);
        Task<GetTransactionResponse> GetTransactionById(Guid idTransaction);
        Task<GetTransactionResponse> GetTransactionByDescription(string description);
        Task<IEnumerable<GetTransactionResponse>> GetAllDebitTransactions();
        Task<IEnumerable<GetTransactionResponse>> GetAllCreditTransactions();
    }
}
