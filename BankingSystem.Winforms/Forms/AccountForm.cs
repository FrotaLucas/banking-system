using System.Data;
using BankingSystem.Application.Orchestration.Interfaces;

namespace BankingSystem.Winforms.Forms
{
    public partial class AccountForm : Form
    {
        private readonly IBankingService _bankingService;

        public AccountForm(IBankingService bankingService)
        {
            InitializeComponent();
            _bankingService = bankingService;

            LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                DataTable accounts = _bankingService.GetTableAccount();
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
            using var form = new AccountCreateForm(_bankingService);
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
                    _bankingService.DeleteAccount(accountId);
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
                _bankingService.DeleteAccount(accountId);

                MessageBox.Show($"Account deleted successfully");

                //LoadCustomers();
            }
        }
    }
}
