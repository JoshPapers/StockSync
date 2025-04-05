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
    public partial class Archive : Form
    {
        public Archive()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            LoadArchive();
        }
        private void LoadArchive()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                                    i.InventoryID, 
                                    p.ProductName, 
                                    i.Stock, 
                                    i.SellingPrice, 
                                    i.ExpirationDate 
                                FROM Inventory i
                                JOIN Products p ON i.ProductID = p.ProductID
                                WHERE i.IsArchived = 1;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvArchive.DataSource = dt;
                        dgvArchive.Columns["InventoryID"].Visible = false;
                        dgvArchive.Columns["Stock"].HeaderText = "Quantity";
                        dgvArchive.Columns["SellingPrice"].HeaderText = "Price";
                        dgvArchive.Columns["ExpirationDate"].HeaderText = "Expiry Date";

                        // Adjust column sizes
                        dgvArchive.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvArchive.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvArchive.Columns["SellingPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvArchive.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        // Format price and expiration date columns
                        dgvArchive.Columns["SellingPrice"].DefaultCellStyle.Format = "C2";
                        dgvArchive.Columns["ExpirationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                        // Prevent editing
                        dgvArchive.ReadOnly = true;
                        dgvArchive.AllowUserToAddRows = false;
                        dgvArchive.AllowUserToDeleteRows = false;
                        dgvArchive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvArchive.MultiSelect = false;
                        dgvArchive.DefaultCellStyle.SelectionBackColor = dgvArchive.DefaultCellStyle.BackColor;
                        dgvArchive.DefaultCellStyle.SelectionForeColor = dgvArchive.DefaultCellStyle.ForeColor;

                        foreach (DataGridViewRow row in dgvArchive.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["Stock"].Value) == 0)
                            {
                                row.DefaultCellStyle.BackColor = Color.DarkRed;
                                row.DefaultCellStyle.ForeColor = Color.White;
                            }
                        }
                        foreach (DataGridViewRow row in dgvArchive.Rows)
                        {
                            int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                            object expirationObj = row.Cells["ExpirationDate"].Value;

                            // Check if the expiration date is not null and already expired
                            bool isExpired = expirationObj != DBNull.Value && Convert.ToDateTime(expirationObj) < DateTime.Now;

                            if (stock == 0 || isExpired)
                            {
                                row.DefaultCellStyle.BackColor = Color.DarkRed;
                                row.DefaultCellStyle.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading archive: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
