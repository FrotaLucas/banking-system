using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();    
    }
}
