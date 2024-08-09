using System.ComponentModel.DataAnnotations;

namespace Application.Requests
{
    public class CreateTransactionRequest
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        [AllowedValues("Credit", "Debit")]
        public required string Type { get; set; }
    }
}
