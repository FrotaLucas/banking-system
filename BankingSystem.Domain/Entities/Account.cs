namespace BankingSystem.Domain.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal OpeningBalance { get; set; }
        //public decimal CurrentBalance { get; set; } pq ????
    }
}
