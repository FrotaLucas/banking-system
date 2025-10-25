namespace BankingSystem.Domain.Entities
{
    public class Transaction
    {
        int Id { get; set; }    

        public int AccountId {  get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public string TransactionType { get; set; } = default!;

        public decimal Amount { get; set; } = default!;

        public string Purpose { get; set; } = default!;

        public string IBAN { get; set; } = default!;

        public string TransactionNumber { get; set; }  = default!;

    }
}
