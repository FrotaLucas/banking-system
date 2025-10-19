using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IRepositoryAccount
    {
        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
