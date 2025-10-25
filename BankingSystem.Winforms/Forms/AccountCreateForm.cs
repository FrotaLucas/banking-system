using BankingSystem.Domain.Contracts.Interfaces.IRepositories;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Winforms.Forms
{
    public partial class AccountCreateForm : Form
    {

        private readonly IAccountRepository _repo;

        public AccountCreateForm(IAccountRepository repo)
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
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                };

                decimal balance = (string.IsNullOrWhiteSpace(txtBalance.Text)) ? 0.00m : Decimal.Parse(txtBalance.Text);   

                _repo.AddNewAccount(customer, balance);

                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error trying to create an account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
