using System.Data;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class CustomerEditForm : Form
    {
        private readonly ICustomerRepository _repo;
        private readonly DataRow? _dataRow;

        public CustomerEditForm(ICustomerRepository repo)
        {
            InitializeComponent();
            _repo = repo;

            lblTitle.Text = "Add new customer";
            this.Text = "Add Customer";
        }

        public CustomerEditForm(ICustomerRepository repo, DataRow dataRow) : this(repo)
        {
            _dataRow = dataRow;
            lblTitle.Text = "Edit customer";
            this.Text = "Edit Customer";
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            if (_dataRow == null) return;

            txtFirstName.Text = _dataRow["FirstName"]?.ToString();
            txtLastName.Text = _dataRow["LastName"]?.ToString();
            txtStreet.Text = _dataRow["Street"]?.ToString();
            txtHouseNumber.Text = _dataRow["HouseNumber"]?.ToString();
            txtZipCode.Text = _dataRow["ZipCode"]?.ToString();
            txtCity.Text = _dataRow["City"]?.ToString();
            txtPhone.Text = _dataRow["Phone"]?.ToString();
            txtEmail.Text = _dataRow["Email"]?.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new Customer
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Street = txtStreet.Text.Trim(),
                    HouseNumber = txtHouseNumber.Text.Trim(),
                    ZipCode = txtZipCode.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                };

                if (_dataRow != null)
                {
                    customer.Id = Convert.ToInt32(_dataRow["Id"]);
                    _repo.Update(customer);
                }
                else
                {
                    _repo.Add(customer);
                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
