using System;
using System.Data;
using System.Windows.Forms;
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

            // Carrega os dados na inicialização
            LoadCustomers();
        }

        /// <summary>
        /// Carrega os dados de clientes no DataGridView.
        /// </summary>
        private void LoadCustomers()
        {
            try
            {
                DataTable customers = _customerRepo.GetAll();
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento do botão Reload.
        /// </summary>
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

    }
}
