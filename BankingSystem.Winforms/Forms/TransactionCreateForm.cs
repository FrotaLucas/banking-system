using BankingSystem.Domain.IRepositories;

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
