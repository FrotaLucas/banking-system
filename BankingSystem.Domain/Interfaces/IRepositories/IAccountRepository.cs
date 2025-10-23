using System.Data;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        DataTable GetAll();    

        void Delete(int id);    
    }
}
