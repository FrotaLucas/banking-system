using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankingSystem.Winforms.Forms
{
    partial class AccountCreateForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCustomerId;
        private TextBox txtAccountNumber;
        private TextBox txtBalance;
        private Button btnSave;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // 
            // txtCustomerId
            // 
            txtCustomerId = new TextBox();
            txtCustomerId.PlaceholderText = "Customer ID";
            txtCustomerId.Dock = DockStyle.Top;
            txtCustomerId.Margin = new Padding(5);

            // 
            // txtAccountNumber
            // 
            txtAccountNumber = new TextBox();
            txtAccountNumber.PlaceholderText = "Account Number";
            txtAccountNumber.Dock = DockStyle.Top;
            txtAccountNumber.Margin = new Padding(5);

            // 
            // txtBalance
            // 
            txtBalance = new TextBox();
            txtBalance.PlaceholderText = "Initial Balance";
            txtBalance.Dock = DockStyle.Top;
            txtBalance.Margin = new Padding(5);

            // 
            // btnSave
            // 
            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Height = 40;
            btnSave.Click += btnSave_Click;

            // 
            // lblTitle
            // 
            lblTitle = new Label();
            lblTitle.Text = "Create Account";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // AccountCreateForm
            // 
            ClientSize = new Size(400, 250);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Account";

            Controls.AddRange(new Control[]
            {
                txtBalance,
                txtAccountNumber,
                txtCustomerId,
                lblTitle,
                btnSave
            });
        }
    }
}
