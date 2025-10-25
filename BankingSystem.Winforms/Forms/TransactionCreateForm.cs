using BankingSystem.Domain.Contracts.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class TransactionCreateForm : Form
    {
        private  readonly ITransactionRepository transactionRepository;

        public TransactionCreateForm(ITransactionRepository transactionRepository)
        {
            InitializeComponent();
            this.transactionRepository = transactionRepository;
        }
    }
}
