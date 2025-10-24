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

        //private readonly IAccountRepository _accountRepository;

        public CustomerRepository(SqlConnection connection, BankDataSet dataSet)
        {
            _dataSet = dataSet;
            _adapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
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
            //GARANTIR ANTES QUE NUNCA VENHA -1 !!
            if (customerId <= 0)
                return false;

            //List<Account> accountsOfCustomer = _accountRepository.GetAccountsByCustomerId(customerId);
            //decimal totalBalance = accountsOfCustomer.Sum(x => x.Balance);
            //if (totalBalance > 0)
            //    return false;


            var row = _dataSet.Customers.Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => (int)r["Id"] == customerId);

            if (row != null)
            {
                //_dataSet.Customers.Rows.Remove( row );
                row.Delete();
                _adapter.Update(_dataSet, "Customers");
            }

            return true;
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null || customer.Id <= 0)
                throw new ArgumentException("Invalid customer");

            var row = _dataSet.Customers.Rows
                .Cast<DataRow>()
                .FirstOrDefault(r => (int)r["Id"] == customer.Id);

            if (row == null)
                throw new InvalidOperationException($"Customer with Id {customer.Id} not found");

            row["FirstName"] = customer.FirstName;
            row["LastName"] = customer.LastName;
            row["Street"] = customer.Street;
            row["HouseNumber"] = customer.HouseNumber;
            row["ZipCode"] = customer.ZipCode;
            row["City"] = customer.City;
            row["Phone"] = customer.Phone;
            row["Email"] = customer.Email;

            _adapter.Update(_dataSet, "Customers");
        }
    }
}
