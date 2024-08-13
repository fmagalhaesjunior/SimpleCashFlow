namespace API.Entities
{
    public class DailySummary
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal Balance { get; set; }

    }
}
