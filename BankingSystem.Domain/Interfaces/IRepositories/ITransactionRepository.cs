using System.Data;
using System.Transactions;

namespace BankingSystem.Domain.Interfaces.IRepositories
{
    public interface ITransactionRepository
    {
        void AddNewTransaction(Transaction transaction);

        DataTable GetTransactionsByAccountId();
    }
}
