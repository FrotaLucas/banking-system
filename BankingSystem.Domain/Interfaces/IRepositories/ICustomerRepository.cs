using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        List<Customer> getCustomers();

        DataTable GetAll();
    }
}
