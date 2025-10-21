using System.Diagnostics.Metrics;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAccount(Account account)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Accounts (AccountNumber, CustomerId, OpeningBalance)
                           VALUES (@AccountNumber, @CustomerId, @OpeningBalance)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                    cmd.Parameters.AddWithValue("@CustomerId", account.CustomerId);
                    cmd.Parameters.AddWithValue("@OpeningBalance", account.Balance);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Account> GetAccounts()
        {
            return new List<Account>();
        }
    }
}
