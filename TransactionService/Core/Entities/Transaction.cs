using Core.Enumerators;

namespace Core.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionTypeEnum Type { get; private set; }
        public string Description { get; private set; }

        public Transaction(DateTime transactionDate, decimal amount, TransactionTypeEnum type, string description)
        {
            ValidateTransaction(transactionDate, amount);
            Id = Guid.NewGuid();
            TransactionDate = transactionDate;
            Amount = amount;
            Type = type;
            Description = description;
        }

        public void UpdateTransaction(DateTime transactionDate, decimal amount, string description)
        {
            ValidateTransaction(transactionDate, amount);
            TransactionDate = transactionDate;
            Amount = amount;
            Description = description;
        }

        public void ValidateTransaction(DateTime transactionDate, decimal amount)
        {
            if (transactionDate > DateTime.Now)
                throw new ArgumentException("A data da transação não pode ser uma data futura.");

            if (amount <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");
        }
    }
}
