using System.Data;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDataAdapter _adapter;
        private readonly BankDataSet _dataSet;

        public CustomerRepository(SqlConnection connection, BankDataSet dataSet)
        {
            _dataSet = dataSet;
            _adapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
            new SqlCommandBuilder(_adapter);
        }

        public DataTable GetAll() => _dataSet.Customers;

        //FAZ SENTIDO RETORNAR LISTA DE CUSTOMER?
        public List<Customer> getCustomers()
        {
            throw new NotImplementedException();
        }

        public void Add(string firstName, string lastName, string email)
        {
            var row = _dataSet.Customers.NewRow();
            row["FirstName"] = firstName;
            row["LastName"] = lastName;
            row["Email"] = email;
            _dataSet.Customers.Rows.Add(row);
            _adapter.Update(_dataSet, "Customers");
        }

    }

}
