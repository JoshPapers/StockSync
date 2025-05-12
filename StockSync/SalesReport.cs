using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class SalesReport : Form
    {
        private int currentUserID;
        public SalesReport(int userId)
        {
            currentUserID = userId;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard(currentUserID);
            adminDashboard.Show();
        }
    }
}
