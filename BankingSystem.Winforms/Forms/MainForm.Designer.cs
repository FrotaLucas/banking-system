namespace BankingSystem.Winforms.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControlMain;
        private TabPage tabPageCustomers;
        private TabPage tabPageAccounts;
        private Panel panelContent;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCustomers = new System.Windows.Forms.TabPage();
            this.tabPageAccounts = new System.Windows.Forms.TabPage();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCustomers);
            this.tabControlMain.Controls.Add(this.tabPageAccounts);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 60);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // tabPageCustomers
            // 
            this.tabPageCustomers.Location = new System.Drawing.Point(4, 24);
            this.tabPageCustomers.Name = "tabPageCustomers";
            this.tabPageCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomers.Size = new System.Drawing.Size(792, 32);
            this.tabPageCustomers.TabIndex = 0;
            this.tabPageCustomers.Text = "Customers";
            this.tabPageCustomers.UseVisualStyleBackColor = true;
            // 
            // tabPageAccounts
            // 
            this.tabPageAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccounts.Name = "tabPageAccounts";
            this.tabPageAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccounts.Size = new System.Drawing.Size(792, 32);
            this.tabPageAccounts.TabIndex = 1;
            this.tabPageAccounts.Text = "Accounts";
            this.tabPageAccounts.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 390);
            this.panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Banking System";
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}