using BankingSystem.Domain.IRepositories;
using BankingSystem.Infrastructure;
using BankingSystem.Infrastructure.Repositories;
using BankingSystem.Winforms.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Winforms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 🔹 Carrega configurações do appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connString = configuration.GetConnectionString("DefaultConnection");

            // 🔹 Inicializa banco e dados
            var db = new DbInitializer(connString);
            db.InitializeDatabase();
            BankDataSet dataSet = db.LoadInitialData();

            // 🔹 Configura container de DI
            var services = new ServiceCollection();

            //injetar nos construtores de CustomerRepository e AccountRepository
            services.AddSingleton(dataSet);
            services.AddScoped<SqlConnection>(_ => new SqlConnection(connString));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            var serviceProvider = services.BuildServiceProvider();

            // 🔹 Inicializa WinForms
            ApplicationConfiguration.Initialize();

            // 🔹 Resolve dependências do form principal
            var mainForm = ActivatorUtilities.CreateInstance<MainForm>(serviceProvider);

            Application.Run(mainForm);
        }
    }
}
