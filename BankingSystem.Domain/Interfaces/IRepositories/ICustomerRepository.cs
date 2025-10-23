using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface ICustomerRepository
    {
        DataTable GetAll();

        void Add(Customer customer);

        void Delete(int customerId);

        void Update(Customer customer); 
    }
}
