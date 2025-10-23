using System.Data;
using System.Diagnostics.Metrics;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly SqlDataAdapter _adapter;

        private readonly BankDataSet _dataSet;

        public AccountRepository(SqlConnection connection, BankDataSet dataSet)
        {
           _dataSet = dataSet;
           _adapter = new SqlDataAdapter("SELECT * FROM Accounts", connection);
        }


        public DataTable GetAll() => _dataSet.Accounts;


        public void AddAccount(Account account)
        {
           var row = _dataSet.Accounts.NewRow();

            return;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
