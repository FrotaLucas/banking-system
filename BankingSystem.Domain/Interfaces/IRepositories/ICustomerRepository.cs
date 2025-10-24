using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        DataTable GetTableCustomer();

        void AddNewCustomer(Customer customer);

        void DeleteCustomer(int customerId);

        void UpdateCustomer(Customer customer); 
    }
}
