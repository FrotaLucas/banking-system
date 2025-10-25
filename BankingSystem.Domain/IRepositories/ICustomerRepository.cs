using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        DataTable GetTableCustomer();

        int AddNewCustomer(Customer customer);

        bool DeleteCustomer(int customerId);

        void UpdateCustomer(Customer customer); 
    }
}
