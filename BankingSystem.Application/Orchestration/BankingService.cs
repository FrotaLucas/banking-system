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


        public int AddNewCustomer(Customer customer)
        {
            var intCustomer = _customerRepository.AddNewCustomer(customer);

            return intCustomer;
        }

        public DataTable GetTableCustomer()
        {
            var tableCustomers = _customerRepository.GetTableCustomer();

            return tableCustomers;
        }

        //verificar se frontend mostra msg quando nao deleta nada !!!
        public bool DeleteCustomer(int customerId)
        {
            if (customerId <= 0)
                return false;

            List<Account> accountsOfCustomer = _accountRepository.GetAccountsByCustomerId(customerId);

            if (accountsOfCustomer.Count == 0 || accountsOfCustomer == null)
                return _customerRepository.DeleteCustomer(customerId);

            var totalBalance = accountsOfCustomer.Sum(account =>  account.Balance);

            if (totalBalance != 0)
                return false;

            return _accountRepository.DeleteAccount(customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
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
