using System.Data;
using System.Transactions;

namespace BankingSystem.Domain.IRepositories
{
    public interface ITransactionRepository
    {
        void AddNewTransaction(Transaction transaction);

        DataTable GetTableTransactions();
    }
}
