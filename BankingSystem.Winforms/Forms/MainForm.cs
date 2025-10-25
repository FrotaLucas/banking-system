using BankingSystem.Domain.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class MainForm : Form
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IAccountRepository _accountRepository;

        private readonly ITransactionRepository _transactionRepository;

        private CustomerForm? _customerForm;
        private AccountForm? _accountForm;
        private TransactionForm? _transactionForm;

        public MainForm(ICustomerRepository customerRepo, IAccountRepository accountRepo, ITransactionRepository transactionRepository)
        {
            InitializeComponent();
            _customerRepository = customerRepo;
            _accountRepository = accountRepo;
            _transactionRepository = transactionRepository;

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
            else if (tabControlMain.SelectedTab == tabPageTransactions)
            {
                ShowTransactionForm();
            }
        }

        private void ShowCustomerForm()
        {
            panelContent.Controls.Clear();

            _customerForm ??= new CustomerForm(_customerRepository);
            _customerForm.TopLevel = false;
            _customerForm.FormBorderStyle = FormBorderStyle.None;
            _customerForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_customerForm);
            _customerForm.Show();
        }

        private void ShowAccountForm()
        {
            panelContent.Controls.Clear();

            _accountForm ??= new AccountForm(_accountRepository);
            _accountForm.TopLevel = false;
            _accountForm.FormBorderStyle = FormBorderStyle.None;
            _accountForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_accountForm);
            _accountForm.Show();
        }

        private void ShowTransactionForm()
        {
            panelContent.Controls.Clear();

            _transactionForm ??= new TransactionForm(_transactionRepository);
            _transactionForm.TopLevel = false;
            _transactionForm.FormBorderStyle = FormBorderStyle.None;
            _transactionForm.Dock = DockStyle.Fill;

            panelContent.Controls.Add(_transactionForm);
            _transactionForm.Show();

        }
    }
}
