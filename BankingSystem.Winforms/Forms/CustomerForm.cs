using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.Domain.Interfaces.IRepositories;

namespace BankingSystem.Winforms.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerForm(ICustomerRepository customerRepo)
        {
            InitializeComponent();
            _customerRepo = customerRepo;
        }
    }
}
