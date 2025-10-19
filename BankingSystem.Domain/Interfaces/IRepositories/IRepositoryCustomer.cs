using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface IRepositoryCustomer
    {
        List<Customer> getCustomers();
    }
}
