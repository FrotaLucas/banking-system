using BankingSystem.Domain.Interfaces.IRepositories;
using BankingSystem.Infrastructure;
using BankingSystem.Infrastructure.Repositories;
using BankingSystem.Winforms.Forms;
using Microsoft.Data.SqlClient;

namespace BankingSystem.Winforms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string connString = "Server=FROTAPC; Database=bank_system_db; Trusted_Connection=True; TrustServerCertificate=True";

            var db = new DbInitializer(connString);
            db.InitializeDatabase();
            BankDataSet dataSet = db.LoadInitialData();

            using SqlConnection connection = new SqlConnection(connString);

            // 🔹 Inicializa os repositórios
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ICustomerRepository customerRepo = new CustomerRepository(connection, dataSet);
            IAccountRepository accountRepo = new AccountRepository(connection, dataSet);

            // 🔹 Inicializa WinForms (configurações modernas de DPI, etc.)
            ApplicationConfiguration.Initialize();

            // 🔹 Executa o form principal, injetando dependências
            Application.Run(new MainForm(customerRepo, accountRepo));








        }
    }
}