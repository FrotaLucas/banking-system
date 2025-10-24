using System.Data;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class AccountForm : Form
    {
        private readonly IAccountRepository _accountRepo;

        public AccountForm(IAccountRepository accountRepo)
        {
            InitializeComponent();
            _accountRepo = accountRepo;

            LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                DataTable accounts = _accountRepo.GetTableAccount();
                dgvAccounts.DataSource = accounts;

                if (dgvAccounts.Columns["colDelete"] == null)
                    dgvAccounts.Columns.Add(colDelete);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using var form = new AccountCreateForm(_accountRepo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAccounts();
            }
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAccounts.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var accountId = (int)dgvAccounts.Rows[e.RowIndex].Cells["Id"].Value;
                var confirm = MessageBox.Show("Are you sure you want to delete this account?",
                                              "Confirm Delete",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _accountRepo.DeleteAccount(accountId);
                    MessageBox.Show("Account deleted successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                }
            }
        }

        private void btnDeleteAccount_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

             if (dgvAccounts.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var accountId = (int)dgvAccounts.Rows[e.RowIndex].Cells["Id"].Value;
                _accountRepo.DeleteAccount(accountId);

                MessageBox.Show($"Account deleted successfully");

                //LoadCustomers();
            }
        }
    }
}
