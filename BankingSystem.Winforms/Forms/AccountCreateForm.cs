using BankingSystem.Domain.Interfaces.IRepositories;

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

        private void btnSave_Click(object sender, EventArgs e) { }
    }
}
