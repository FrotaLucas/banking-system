using System.Data;
using BankingSystem.Application.Orchestration.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.IRepositories;

namespace BankingSystem.Application.Orchestration
{
    public class BankingService : IBankingService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IAccountRepository _accountRepository;

        private readonly ITransactionRepository _transactionRepository;

        public BankingService(ICustomerRepository customerRepository, IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }


        public public int AddNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTableCustomer()
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTableAccount()
        {
            throw new NotImplementedException();
        }

        public void AddNewAccount(Account account, decimal balance)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(int accountId)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccountsByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
