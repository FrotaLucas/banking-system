using System.Data;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class TransactionForm : Form
    {
        private readonly ITransactionRepository _transactionRepository;


        public TransactionForm(ITransactionRepository transactionRepository)
        {
            InitializeComponent();

            _transactionRepository = transactionRepository;

            LoadTransactions();
        }

        /// <summary>
        /// Carrega as transações da conta e atualiza a interface.
        /// </summary>
        private void LoadTransactions()
        {
            try
            {
                //DataTable transactions = _transactionRepository.GetTransactionsByAccountId();


                dgvTransactions.Columns.Clear();
                dgvTransactions.DataSource = null;
                dgvTransactions.AutoGenerateColumns = false;

                // Define as colunas de exibição
                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    ReadOnly = true
                });

                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Date",
                    HeaderText = "Date",
                    ReadOnly = true
                });

                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Description",
                    HeaderText = "Description",
                    ReadOnly = true
                });

                dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Amount",
                    HeaderText = "Amount (€)",
                    ReadOnly = true
                });

                dgvTransactions.Columns.Add(colDelete);

                //dgvTransactions.DataSource = transactions;

                UpdateTotalBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Atualiza o saldo total exibido na label.
        /// </summary>
        private void UpdateTotalBalance()
        {
            //decimal total = Transaction.Sum(t => t.Amount);
            //lblTotalBalance.Text = $"Total Balance: € {total:N2}";
        }

        /// <summary>
        /// Evento do botão Reload.
        /// </summary>
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        /// <summary>
        /// Evento do botão New Transaction.
        /// </summary>
        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            using var newTransactionForm = new TransactionCreateForm(_transactionRepository);
            var result = newTransactionForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadTransactions();
                MessageBox.Show("Transaction successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Clique em botões dentro do DataGridView (ex: Delete).
        /// </summary>
        private void btnDeleteTransaction_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvTransactions.Columns[e.ColumnIndex].Name == "colDelete")
            {
                //var transaction = (Transaction)dgvTransactions.Rows[e.RowIndex].DataBoundItem;

                //var confirm = MessageBox.Show($"Are you sure you want to delete transaction #{transaction.Id}?",
                //                              "Confirm Delete",
                //                              MessageBoxButtons.YesNo,
                //                              MessageBoxIcon.Warning);

                //if (confirm == DialogResult.Yes)
                //{
                //    try
                //    {
                //        _transactionRepository.DeleteTransaction(transaction.Id);
                //        LoadTransactions();
                //        MessageBox.Show("Transaction deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"Failed to delete transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
            }
        }
    }
}
