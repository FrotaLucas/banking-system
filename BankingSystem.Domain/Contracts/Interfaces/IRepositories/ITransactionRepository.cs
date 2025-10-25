using System.Data;
using System.Transactions;

namespace BankingSystem.Domain.Contracts.Interfaces.IRepositories
{
    public interface ITransactionRepository
    {
        void AddNewTransaction(Transaction transaction);

        DataTable GetTableTransactions();
    }
}
