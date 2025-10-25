using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Orchestration.Interfaces
{
    public interface IBankingService 
    {
        public int AddNewCustomer(Customer customer);

        public DataTable GetTableCustomer();

        public int DeleteCustomer(int customerId);

        public void UpdateCustomer(Customer customer);

        public DataTable GetTableAccount();

        public void AddNewAccount(Account account, decimal balance);

        public bool DeleteAccount(int accountId);

        public List<Account> GetAccountsByCustomerId(int customerId);
    }
}
