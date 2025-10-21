using BankingSystem.Infrastructure;
using BankingSystem.Winforms.Forms;

namespace BankingSystem.Winforms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connString = "Data Source=.;Initial Catalog=BankDB;Integrated Security=True";
            string connStringV2 = "Server=FROTAPC; database=bank_system-db; Trusted_connection=true; Trustservercertificate=true";
            var db = new DbInitializer(connString);
            db.InitializeDatabase();

            BankDataSet dataSet = db.LoadInitialData();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            Application.Run(new CustomerForm());
        }
    }
}