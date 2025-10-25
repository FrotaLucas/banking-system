using System.Data;
using BankingSystem.Domain.Contracts.Interfaces.IRepositories;
using BankingSystem.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly SqlConnection _connection;

        private readonly SqlDataAdapter _adapter;

        private readonly BankDataSet _dataSet;

        private readonly ICustomerRepository _customerRepository;


        public AccountRepository(SqlConnection connection, BankDataSet dataSet, ICustomerRepository customerRepository)
        {
            _connection = connection;
            _dataSet = dataSet;
            _adapter = new SqlDataAdapter("SELECT * FROM Accounts", _connection);

            var builder = new SqlCommandBuilder(_adapter);
            _customerRepository = customerRepository;
        }

        public DataTable GetTableAccount() => _dataSet.Accounts;

        private string CreateAccountNumber()
        {
           
            var random = new Random();

            Func<int, string> GenerateRandomDigits = (length) =>
            {
                var result = new char[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = (char)('0' + random.Next(10));
                }
                return new string(result);
            };

            string countryCode = "DE";

            string checkDigits = GenerateRandomDigits(2);

            string bankCode = GenerateRandomDigits(8);

            string accountNumber = GenerateRandomDigits(10);

            string ibanNoSpaces = $"{countryCode}{checkDigits}{bankCode}{accountNumber}";

            string ibanFormatted =
                $"{ibanNoSpaces.Substring(0, 4)} " +
                $"{ibanNoSpaces.Substring(4, 4)} " +
                $"{ibanNoSpaces.Substring(8, 4)} "; //+
                //$"{ibanNoSpaces.Substring(12, 4)} " +
                //$"{ibanNoSpaces.Substring(16, 4)} " +
                //$"{ibanNoSpaces.Substring(20)}";

            return ibanFormatted;

        }

        public void AddNewAccount(Customer customer, decimal balance)
        {
            var dbCustomer = _dataSet.Customers.Rows
                .Cast<DataRow>()
                .FirstOrDefault(r =>
                    r["Email"].ToString() == customer.Email &&
                    r["Street"].ToString() == customer.Street &&
                    r["HouseNumber"].ToString() == customer.HouseNumber &&
                    r["ZipCode"].ToString() == customer.ZipCode &&
                    r["City"].ToString() == customer.City
                );

            int customerId;

            if (dbCustomer == null)
                customerId = _customerRepository.AddNewCustomer(customer);

            else
                customerId = Convert.ToInt32(dbCustomer["Id"]);

            var accountRow = _dataSet.Accounts.NewRow();
            accountRow["CustomerId"] = customerId;
            accountRow["CustomerName"] = $"{customer.FirstName} {customer.LastName}";
            accountRow["AccountNumber"] = CreateAccountNumber();
            accountRow["Balance"] = balance;

            _dataSet.Accounts.Rows.Add(accountRow);
            _adapter.Update(_dataSet, "Accounts");
        }


        public bool DeleteAccount(int accountId)
        {
            if (accountId <= 0)
                return false;

            const string sql = "DELETE FROM Accounts WHERE Id = @Id";
            using var cmd = new SqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@Id", accountId);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            int affected = cmd.ExecuteNonQuery();

            if (affected > 0)
            {
                var row = _dataSet.Accounts.Rows
                    .Cast<DataRow>()
                    .FirstOrDefault(r => (int)r["Id"] == accountId);

                if (row != null)
                    row.Delete();
            }

            return affected > 0;
        }


        //METODO MAIS VERBOSO PARA IR ATE O BANCO DE DADOS, POREM MAIS CORRETO!!
        public List<Account> GetAccountsByCustomerId(int customerId)
        {
            if (customerId <= 0)
                throw new ArgumentException("Invalid customer ID.", nameof(customerId));

            var accounts = new List<Account>();

            using (var connection = new SqlConnection(_adapter.SelectCommand.Connection.ConnectionString))
            {
                const string query = @"
            SELECT 
                Id,
                CustomerId,
                AccountNumber,
                Balance
            FROM Accounts
            WHERE CustomerId = @customerId;
        ";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var account = new Account
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                AccountNumber = reader.GetString(reader.GetOrdinal("AccountNumber")),
                                Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                            };

                            accounts.Add(account);
                        }
                    }
                }
            }

            return accounts;
        }

    }
}
