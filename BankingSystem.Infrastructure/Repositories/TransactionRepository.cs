using System.Data;
using System.Transactions;
using BankingSystem.Domain.Contracts.Interfaces.IRepositories;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {


        private readonly SqlDataAdapter _adapter;

        private readonly BankDataSet _dataSet;

        private readonly IAccountRepository accountRepository;

        public TransactionRepository(SqlConnection connection, BankDataSet dataSet, IAccountRepository accountRepository)
        {
            _dataSet = dataSet;
            _adapter = new SqlDataAdapter("SELECT * FROM Transactions", connection);

            var builder = new SqlCommandBuilder(_adapter);
            accountRepository = accountRepository;
        }


        public void AddNewTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTableTransactions() => _dataSet.Transactions;
      
    }
}
