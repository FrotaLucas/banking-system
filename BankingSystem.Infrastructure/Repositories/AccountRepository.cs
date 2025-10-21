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

        public List<Account> GetAccounts()
        {
            return new List<Account>();
        }

        public void AddAccount(Account account)
        {
            //using (SqlConnection conn = new SqlConnection(_connectionString))
            //{
            //    conn.Open();
            //    string sql = @"INSERT INTO Accounts (AccountNumber, CustomerId, OpeningBalance)
            //               VALUES (@AccountNumber, @CustomerId, @OpeningBalance)";

            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
            //        cmd.Parameters.AddWithValue("@CustomerId", account.CustomerId);
            //        cmd.Parameters.AddWithValue("@OpeningBalance", account.Balance);
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

    }
}
