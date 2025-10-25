using System.Data;
using BankingSystem.Application.Orchestration.Interfaces;

namespace BankingSystem.Winforms.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly IBankingService _bankingService;

        public CustomerForm(IBankingService bankingService)
        {
            InitializeComponent();
            _bankingService = bankingService;

            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                DataTable customers = _bankingService.GetTableCustomer();
                dgvCustomers.DataSource = customers;

                if (dgvCustomers.Columns["colEdit"] == null)
                    dgvCustomers.Columns.Add(colEdit);
                if (dgvCustomers.Columns["colDelete"] == null)
                    dgvCustomers.Columns.Add(colDelete);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using var form = new CustomerEditForm(_bankingService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers(); 
            }
        }

        private void btnCustomerUpdate_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var dataRowView = (DataRowView)dgvCustomers.Rows[e.RowIndex].DataBoundItem;
            DataRow customerDataRow = dataRowView.Row;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                using (var form = new CustomerEditForm(_bankingService, customerDataRow))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            else if (dgvCustomers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var customerId = (int)dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value;
                _bankingService.DeleteCustomer(customerId);
                
                MessageBox.Show($"Customer deleted successfully");

                //LoadCustomers();
            }
        }

    }
}