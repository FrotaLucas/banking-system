using System.Data;
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
                $"{ibanNoSpaces.Substring(8, 4)} " +
                $"{ibanNoSpaces.Substring(12, 4)} " +
                $"{ibanNoSpaces.Substring(16, 4)} " +
                $"{ibanNoSpaces.Substring(20)}";

            return ibanFormatted;

        }

        public void Add(Customer customer, decimal balance)
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
            {
                var newCustomer = _dataSet.Customers.NewRow();
                newCustomer["FirstName"] = customer.FirstName;
                newCustomer["LastName"] = customer.LastName;
                newCustomer["Street"] = customer.Street;
                newCustomer["HouseNumber"] = customer.HouseNumber;
                newCustomer["ZipCode"] = customer.ZipCode;
                newCustomer["City"] = customer.City;
                newCustomer["Phone"] = customer.Phone;
                newCustomer["Email"] = customer.Email;

                _dataSet.Customers.Rows.Add(newCustomer);

                _adapter.Update(_dataSet, "Customers");

                customerId = Convert.ToInt32(newCustomer["Id"]);
            }
            else
            {
                customerId = Convert.ToInt32(dbCustomer["Id"]);
            }

            var accountRow = _dataSet.Accounts.NewRow();
            accountRow["CustomerId"] = customerId;
            accountRow["AccountNumber"] = CreateAccountNumber();
            accountRow["Balance"] = balance;

            _dataSet.Accounts.Rows.Add(accountRow);
            _adapter.Update(_dataSet, "Accounts");
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
