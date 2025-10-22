using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class CustomerEditForm : Form
    {
        private readonly ICustomerRepository _repo;

        public CustomerEditForm(ICustomerRepository repo)
        {
            InitializeComponent();
            _repo = repo;
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
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                };

                _repo.Add(customer);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
