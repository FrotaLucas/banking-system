using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        DataTable GetTableAccount();    
        
        List<Account> GetAccountsByCustomerId(int customerId);    

        bool DeleteAccount(int id);    

        void AddNewAccount(Customer customer, decimal balance);
    }
}
