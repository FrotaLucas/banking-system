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

        //Deveria retornar Customer
        public void Add(Customer customer)
        {
            var row = _dataSet.Customers.NewRow();
            row["FirstName"] = customer.FirstName;
            row["LastName"] = customer.LastName;
            row["Street"] = customer.LastName;
            row["HouseNumber"] = customer.LastName;
            row["ZipCode"] = customer.LastName;
            row["City"] = customer.LastName;
            row["Phone"] = customer.LastName;
            row["Email"] = customer.Email;
            _dataSet.Customers.Rows.Add(row);
            _adapter.Update(_dataSet, "Customers");
        }

    }

}
