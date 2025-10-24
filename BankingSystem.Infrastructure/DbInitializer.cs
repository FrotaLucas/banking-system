using System.Data;
using BankingSystem.Infrastructure;
using Microsoft.Data.SqlClient; // para BankDataSet

public class DbInitializer
{
    private readonly string _connectionString;


    public DbInitializer(string connectionString)
    {
        _connectionString = connectionString;

    }

    public void InitializeDatabase()
    {

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            // Cria tabela Customers se não existir
            string createCustomers = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers' and xtype='U')
                CREATE TABLE Customers (
                    Id INT IDENTITY PRIMARY KEY,
                    FirstName NVARCHAR(50),
                    LastName NVARCHAR(50),
                    Street NVARCHAR(50),
                    HouseNumber NVARCHAR(50),
                    ZipCode NVARCHAR(50),
                    City NVARCHAR(50),
                    Phone NVARCHAR(50),
                    Email NVARCHAR(100)
                );";
            new SqlCommand(createCustomers, connection).ExecuteNonQuery();

            // Accounts  ATENCAO                     AccountNumber deve ser 30 para receber o tamanho da string NVARCHAR(30) 
            string createAccounts = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Accounts' and xtype='U')
                CREATE TABLE Accounts (
                    Id INT IDENTITY PRIMARY KEY,
                    CustomerId INT,
                    AccountNumber NVARCHAR(20),
                    Balance DECIMAL(18,2),
                    FOREIGN KEY(CustomerId) REFERENCES Customers(Id)
                );";
            new SqlCommand(createAccounts, connection).ExecuteNonQuery();

            // Transactions
            //string createTransactions = @"
            //    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Transactions' and xtype='U')
            //    CREATE TABLE Transactions (
            //        TransactionId INT IDENTITY PRIMARY KEY,
            //        AccountId INT,
            //        Date DATETIME,
            //        Amount DECIMAL(18,2),
            //        Purpose NVARCHAR(100),
            //        Type NVARCHAR(20),
            //        FOREIGN KEY(AccountId) REFERENCES Accounts(AccountId)
            //    );";
            //new SqlCommand(createTransactions, connection).ExecuteNonQuery();
        }
    }

    public BankDataSet LoadInitialData()
    {
        var ds = new BankDataSet();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var customerAdapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
            customerAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            customerAdapter.Fill(ds, "Customers");

            var accountAdapter = new SqlDataAdapter("SELECT * FROM Accounts", connection);
            accountAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            accountAdapter.Fill(ds, "Accounts");
        }

        if (ds.Customers.Columns.Contains("Id"))
            ds.Customers.PrimaryKey = new DataColumn[] { ds.Customers.Columns["Id"] };

        if (ds.Accounts.Columns.Contains("Id"))
            ds.Accounts.PrimaryKey = new DataColumn[] { ds.Accounts.Columns["Id"] };

        return ds;
    }
}
