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
    public partial class LoadingSC : Form
    {
        public LoadingSC()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Remove title bar
            this.StartPosition = FormStartPosition.CenterScreen; // Center screen
            this.TopMost = true;
        }
        private async void LoadingSC_Load(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            this.Close(); // Close the splash screen
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
