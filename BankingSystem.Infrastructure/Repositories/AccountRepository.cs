using System.Diagnostics.Metrics;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IRepositoryAccount
    {
        private readonly string connectionString;

        public AccountRepository(string connectionString)
        {
            connectionString = connectionString;
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
