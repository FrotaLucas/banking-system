using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface IRepositoryAccount
    {
        List<Account> GetAccounts();    
    }
}
