using System.Diagnostics.Metrics;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IRepositoryAccount
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAccount(Account account)
        {
           
        }

        public List<Account> GetAccounts()
        {
            throw NotImplementedException();
        }
    }
}
