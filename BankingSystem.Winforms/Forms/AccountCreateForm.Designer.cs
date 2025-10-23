namespace BankingSystem.Winforms.Forms
{
    partial class AccountCreateForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtHouseNumber;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblCustomer;

        private System.Windows.Forms.TextBox txtBalance;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {


            this.lblCustomer = new Label()
            {
                Text = "Customer:",
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            this.txtFirstName = new TextBox()
            {
                PlaceholderText = "First Name",
                Dock = DockStyle.Top,
                Margin = new Padding(5)
            };

            this.txtLastName = new TextBox()
            {
                PlaceholderText = "Last Name",
                Dock = DockStyle.Top
            };

            this.txtEmail = new TextBox()
            {
                PlaceholderText = "Email",
                Dock = DockStyle.Top
            };

            this.txtPhone = new TextBox()
            {
                PlaceholderText = "Phone",
                Dock = DockStyle.Top
            };

            this.txtStreet = new TextBox() {
                PlaceholderText = "Street", 
                Dock = DockStyle.Top };

            this.txtHouseNumber = new TextBox() { 
                PlaceholderText = "N.", 
                Dock = DockStyle.Top };

            this.txtZipCode = new TextBox() {
                PlaceholderText = "Zip", 
                Dock = DockStyle.Top };

            this.txtCity = new TextBox() {
                PlaceholderText = "City",
                Dock = DockStyle.Top };


            this.lblAccount = new Label()
            {
                Text = "Account:",
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };


            this.txtBalance = new TextBox()
            {
                PlaceholderText = "Initial Balance",
                Dock = DockStyle.Top
            };

            this.btnSave = new Button()
            {
                Text = "Create Account",
                Dock = DockStyle.Bottom,
                Height = 45
            };
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.lblTitle = new Label()
            {
                Text = "Create Account",
                Dock = DockStyle.Top,
                Height = 50,
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            // Adiciona controles na ordem visual do topo para baixo
            this.Controls.AddRange(new Control[]
            {
                txtBalance,
                lblAccount,
                txtCity,
                txtZipCode,
                txtHouseNumber,
                txtStreet,
                txtPhone,
                txtEmail,
                txtLastName,
                txtFirstName,
                lblCustomer,
                lblTitle,
                btnSave
            });

            this.ClientSize = new System.Drawing.Size(400, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Create Account";
        }
    }
}
