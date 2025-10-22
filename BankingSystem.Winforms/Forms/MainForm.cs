using System.Data;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IAccountRepository _accountRepo;

        private CustomerForm? _customerForm;
        private AccountForm? _accountForm;

        public MainForm(ICustomerRepository customerRepo, IAccountRepository accountRepo)
        {
            InitializeComponent();
            _customerRepo = customerRepo;
            _accountRepo = accountRepo;

            // Mostra a aba inicial (Customers)
            ShowCustomerForm();
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageCustomers)
            {
                ShowCustomerForm();
            }
            else if (tabControlMain.SelectedTab == tabPageAccounts)
            {
                ShowAccountForm();
            }
        }

        private void ShowCustomerForm()
        {
            panelContent.Controls.Clear();

            _customerForm ??= new CustomerForm(_customerRepo);
            _customerForm.TopLevel = false;
            _customerForm.FormBorderStyle = FormBorderStyle.None;
            _customerForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_customerForm);
            _customerForm.Show();
        }

        private void ShowAccountForm()
        {
            panelContent.Controls.Clear();

            _accountForm ??= new AccountForm(_accountRepo);
            _accountForm.TopLevel = false;
            _accountForm.FormBorderStyle = FormBorderStyle.None;
            _accountForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_accountForm);
            _accountForm.Show();
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
