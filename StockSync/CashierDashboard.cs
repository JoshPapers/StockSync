using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockSync
{
    public partial class CashierDashboard : Form
    {
        private int _userID;
        public CashierDashboard(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _userID = userID;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void CashierDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales salesForm = new Sales(_userID);  // Passing the cashier's userID
            salesForm.Show();
        }
    }
}
