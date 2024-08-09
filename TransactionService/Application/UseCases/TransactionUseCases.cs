using Application.Requests;
using Application.Responses;
using Application.Validators;
using Core.Entities;
using Core.Enumerators;
using Core.Interfaces;

namespace Application.UseCases
{
    public class TransactionUseCases : ITransactionUseCases
    {
        private readonly IService<Transaction> _service;
        public TransactionUseCases(IService<Transaction> service)
        {
            _service = service;
        }

        public Task CreateTransaction(CreateTransactionRequest request)
        {
            _service.Add<CreateTransactionRequest, TransactionValidator>(request);
            return Task.CompletedTask;
        }

        public Task DeleteTransaction(Guid idTransaction)
        {
            var transactionDb = _service.GetById<Transaction>(idTransaction);
            if (transactionDb == null)
                throw new ArgumentNullException("Transação não encontrada.");

            _service.Remove(transactionDb);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<GetTransactionResponse>> GetAllCreditTransactions()
        {
            var creditTransactions = _service.Select<GetTransactionResponse>(x => x.Type == TransactionTypeEnum.Credit);
            return Task.FromResult(creditTransactions);
        }

        public Task<IEnumerable<GetTransactionResponse>> GetAllDebitTransactions()
        {
            var creditTransactions = _service.Select<GetTransactionResponse>(x => x.Type == TransactionTypeEnum.Debit);
            return Task.FromResult(creditTransactions);
        }

        public Task<GetTransactionResponse> GetTransactionByDescription(string description)
        {
            var transactionDb = _service.Select<GetTransactionResponse>(x => x.Description == description).FirstOrDefault();
            if (transactionDb == null)
                throw new ArgumentNullException("Nenhuma transação encontrada.");
            return Task.FromResult(transactionDb);
        }

        public Task<GetTransactionResponse> GetTransactionById(Guid idTransaction)
        {
            var transactionDb = _service.GetById<GetTransactionResponse>(idTransaction);
            if (transactionDb == null)
                throw new ArgumentNullException("Nenhuma transação encontrada.");
            return Task.FromResult(transactionDb);
        }
    }
}
