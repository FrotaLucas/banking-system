using System.Data;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        DataTable GetAll();    

        void Delete(int id);    

        void Add(Customer customer, decimal balance);
    }
}
