namespace BankingSystem.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; } = default!;
        public decimal Balance { get; set; }


        //opcional
        //Customer Customer { get; set; } 

        //public decimal CurrentBalance { get; set; } pq ????
    }
}
