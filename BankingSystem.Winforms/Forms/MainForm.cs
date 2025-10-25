using BankingSystem.Application.Orchestration.Interfaces;

namespace BankingSystem.Winforms.Forms
{
    public partial class MainForm : Form
    {
        private readonly IBankingService _bankingService;

        private CustomerForm? _customerForm;
        private AccountForm? _accountForm;
        private TransactionForm? _transactionForm;

        public MainForm(IBankingService bankingService)
        {
            InitializeComponent();
            _bankingService = bankingService;

            // Exibe a aba inicial
            ShowCustomerForm();
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageCustomers)
                ShowCustomerForm();
            else if (tabControlMain.SelectedTab == tabPageAccounts)
                ShowAccountForm();
            else if (tabControlMain.SelectedTab == tabPageTransactions)
                ShowTransactionForm();
        }

        private void ShowCustomerForm()
        {
            panelContent.Controls.Clear();

            _customerForm ??= new CustomerForm(_bankingService);
            _customerForm.TopLevel = false;
            _customerForm.FormBorderStyle = FormBorderStyle.None;
            _customerForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_customerForm);
            _customerForm.Show();
        }

        private void ShowAccountForm()
        {
            panelContent.Controls.Clear();

            _accountForm ??= new AccountForm(_bankingService);
            _accountForm.TopLevel = false;
            _accountForm.FormBorderStyle = FormBorderStyle.None;
            _accountForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_accountForm);
            _accountForm.Show();
        }

        private void ShowTransactionForm()
        {
            panelContent.Controls.Clear();

            _transactionForm ??= new TransactionForm(_bankingService);
            _transactionForm.TopLevel = false;
            _transactionForm.FormBorderStyle = FormBorderStyle.None;
            _transactionForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_transactionForm);
            _transactionForm.Show();
        }
    }
}
