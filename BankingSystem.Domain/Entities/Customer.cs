using System.Net;

namespace BankingSystem.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = default!;
        
        public string LastName { get; set; } = default!;
        
        public string Street { get; set; } = default!;

        public string HouseNumber { get; set; } = default!;
        
        public string ZipCode { get; set; } = default!;
        
        public string City { get; set; } = default!;

        public string Phone { get; set; } = default!;
        
        public string Email { get; set; } = default!;
    }

}
