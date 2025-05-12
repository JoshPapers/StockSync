using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                    i.InventoryID,
                    p.ProductName,
                    COALESCE(i.Stock, 0) AS Stock,
                    i.ExpirationDate
                FROM Products p
                LEFT JOIN Inventory i ON p.ProductID = i.ProductID
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE (i.IsArchived = 0 OR i.IsArchived IS NULL)
                AND COALESCE(i.Stock, 0) >= 0;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInventory.DataSource = dt;

                        dgvInventory.Columns["InventoryID"].Visible = false;
                        // Set column headers
                        dgvInventory.Columns["Stock"].HeaderText = "Quantity";

                        // Adjust column sizes
                        dgvInventory.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvInventory.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvInventory.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        // Format price and expiration date columns
                        dgvInventory.Columns["ExpirationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                        // Prevent editing
                        dgvInventory.ReadOnly = true;
                        dgvInventory.AllowUserToAddRows = false;
                        dgvInventory.AllowUserToDeleteRows = false;
                        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvInventory.MultiSelect = false;
                        dgvInventory.DefaultCellStyle.SelectionBackColor = dgvInventory.DefaultCellStyle.BackColor;
                        dgvInventory.DefaultCellStyle.SelectionForeColor = dgvInventory.DefaultCellStyle.ForeColor;
                        // **Baguhin ang kulay ng mga product na may 0 stock**

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inventoryForm = new Inventory(currentUserID);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(500);
            InventoryReportForm reportForm = new InventoryReportForm(currentUserID);
            reportForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(500);
            SalesReport salesReportForm = new SalesReport(currentUserID);
            salesReportForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(500);
            AddSupply supply = new AddSupply(currentUserID);
            supply.ShowDialog();
        }
    } 
}
