using Core.Enumerators;
using Shared.Extensions;

namespace Core.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionTypeEnum Type { get; private set; }
        public string Description { get; private set; }

        public Transaction(DateTime transactionDate, decimal amount, string type, string description)
        {
            if (transactionDate > DateTime.Now)
                throw new ArgumentException("A data da transação não pode ser uma data futura.");

            if (amount <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");

            Id = Guid.NewGuid();
            TransactionDate = transactionDate;
            Amount = amount;
            Type = type.ToEnum<TransactionTypeEnum>();
            Description = description;
        }
    }
}
