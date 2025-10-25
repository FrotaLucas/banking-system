using System.Data;
using BankingSystem.Domain.Contracts.Interfaces.IRepositories;
using BankingSystem.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDataAdapter _adapter;

        private readonly BankDataSet _dataSet;

        private readonly SqlConnection _connection;

        //private readonly IAccountRepository _accountRepository;

        public CustomerRepository(SqlConnection connection, BankDataSet dataSet)
        {
            _connection = connection;
            _dataSet = dataSet;
            _adapter = new SqlDataAdapter("SELECT * FROM Customers", _connection);
            new SqlCommandBuilder(_adapter);
            //_accountRepository = accountRepository;
        }

        public DataTable GetTableCustomer() => _dataSet.Customers;

        public int AddNewCustomer(Customer customer)
        {
            var row = _dataSet.Customers.NewRow();
            row["FirstName"] = customer.FirstName;
            row["LastName"] = customer.LastName;
            row["Street"] = customer.Street;
            row["HouseNumber"] = customer.HouseNumber;
            row["ZipCode"] = customer.ZipCode;
            row["City"] = customer.City;
            row["Phone"] = customer.Phone;
            row["Email"] = customer.Email;

            _dataSet.Customers.Rows.Add(row);
            _adapter.Update(_dataSet, "Customers");

            int Id = Convert.ToInt32(row["Id"]);

            return Id;
        }

        public bool DeleteCustomer(int customerId)
        {
            if (customerId <= 0)
                return false;

            const string sql = "DELETE FROM Customers WHERE Id = @Id";
            using var cmd = new SqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@Id", customerId);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            int affected = cmd.ExecuteNonQuery();

            // Atualiza DataSet apenas se o banco foi alterado
            if (affected > 0)
            {
                var row = _dataSet.Customers.Rows
                    .Cast<DataRow>()
                    .FirstOrDefault(r => (int)r["Id"] == customerId);

                if (row != null)
                    row.Delete();
            }

            return affected > 0;
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null || customer.Id <= 0)
                throw new ArgumentException("Invalid customer");

            const string sql = @"
                UPDATE Customers
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Street = @Street,
                    HouseNumber = @HouseNumber,
                    ZipCode = @ZipCode,
                    City = @City,
                    Phone = @Phone,
                    Email = @Email
                WHERE Id = @Id";

            using var cmd = new SqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@Id", customer.Id);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Street", customer.Street ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HouseNumber", customer.HouseNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ZipCode", customer.ZipCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@City", customer.City ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", customer.Email ?? (object)DBNull.Value);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            int affected = cmd.ExecuteNonQuery();

            // Sincroniza DataSet local (opcional)
            if (affected > 0)
            {
                var row = _dataSet.Customers.Rows
                    .Cast<DataRow>()
                    .FirstOrDefault(r => (int)r["Id"] == customer.Id);

                if (row != null)
                {
                    row["FirstName"] = customer.FirstName;
                    row["LastName"] = customer.LastName;
                    row["Street"] = customer.Street;
                    row["HouseNumber"] = customer.HouseNumber;
                    row["ZipCode"] = customer.ZipCode;
                    row["City"] = customer.City;
                    row["Phone"] = customer.Phone;
                    row["Email"] = customer.Email;
                }
            }
            else
            {
                throw new InvalidOperationException($"Customer with Id {customer.Id} not found or not updated.");
            }
        }
    }
}
