using System.Data;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerForm(ICustomerRepository customerRepo)
        {
            InitializeComponent();
            _customerRepo = customerRepo;

            LoadCustomers();
        }

   
        private void LoadCustomers()
        {
            try
            {
                DataTable customers = _customerRepo.GetAll();
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
            using var form = new CustomerEditForm(_customerRepo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers(); 
            }
        }

        private void btnCustomerUpdate_Click(object sender, DataGridViewCellEventArgs e)
        {
            // Ignora cliques no header
            if (e.RowIndex < 0)
                return;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var customerId = (int)dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value;
                MessageBox.Show($"Editar cliente ID {customerId}");
            }
            else if (dgvCustomers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var customerId = (int)dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value;
                _customerRepo.Delete(customerId);

                MessageBox.Show($"Customer deleted successfully");
            }
        }

    }
}