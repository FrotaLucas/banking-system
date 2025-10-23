namespace BankingSystem.Winforms.Forms
{
    partial class CustomerEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtStreet;
        private TextBox txtHouseNumber;
        private TextBox txtZipCode;
        private TextBox txtCity;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private Button btnSave;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtFirstName = new TextBox() { PlaceholderText = "First Name", Dock = DockStyle.Top, Margin = new Padding(5) };
            this.txtLastName = new TextBox() { PlaceholderText = "Last Name", Dock = DockStyle.Top };
            this.txtStreet = new TextBox() { PlaceholderText = "Street", Dock = DockStyle.Top };
            this.txtHouseNumber = new TextBox() { PlaceholderText = "N.", Dock = DockStyle.Top };
            this.txtZipCode = new TextBox() { PlaceholderText = "Zip", Dock = DockStyle.Top };
            this.txtCity = new TextBox() { PlaceholderText = "City", Dock = DockStyle.Top };
            this.txtPhone = new TextBox() { PlaceholderText = "Phone", Dock = DockStyle.Top };
            this.txtEmail = new TextBox() { PlaceholderText = "Email", Dock = DockStyle.Top };
            this.btnSave = new Button() { Text = "Save", Dock = DockStyle.Bottom, Height = 40 };
            this.lblTitle = new Label() {Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold), Dock = DockStyle.Top, Height = 50};

            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.Controls.AddRange(new Control[] {
                txtPhone, txtEmail, txtCity, txtStreet, txtHouseNumber, txtZipCode, txtLastName, txtFirstName, lblTitle, btnSave
            });

            this.ClientSize = new System.Drawing.Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
