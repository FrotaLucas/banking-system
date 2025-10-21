using System.Data;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IAccountRepository _accountRepo;

        public MainForm(ICustomerRepository customerRepo, IAccountRepository accountRepo)
        {
            InitializeComponent();
            _customerRepo = customerRepo;
            _accountRepo = accountRepo;
           
        }

        private void btnTestGetCustomers_Click(object sender, EventArgs e)
        {
            DataTable dt = _customerRepo.GetAll();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            //new CustomerForm(_customerRepo).ShowDialog();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            //new AccountForm(_accountRepo).ShowDialog();
        }
    }
}
