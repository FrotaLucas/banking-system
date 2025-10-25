using BankingSystem.Application.Orchestration.Interfaces;

namespace BankingSystem.Winforms.Forms
{
    public partial class TransactionCreateForm : Form
    {
        private  readonly IBankingService _bankingService
            ;

        public TransactionCreateForm(IBankingService bankingService)
        {
            InitializeComponent();
            _bankingService = bankingService;
        }
    }
}
