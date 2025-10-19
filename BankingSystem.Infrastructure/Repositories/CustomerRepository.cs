using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Infrastructure.Repositories
{
    public class CustomerRepository : IRepositoryAccount
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
