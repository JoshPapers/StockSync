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
    public partial class AdminDashboard : Form
    {
        int currentUserID;
        public AdminDashboard(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUserID = userID;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inventoryForm = new Inventory();
            inventoryForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(500);
            Sales salesForm = new Sales(currentUserID);
            salesForm.Show();
        }
    }
}
