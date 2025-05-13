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
    public partial class SupplyArchives : Form
    {
        public SupplyArchives()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void SupplyArchives_Load(object sender, EventArgs e)
        {
            LoadArchive();
        }
        private void LoadArchive()
        {
            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                string query = @"
                SELECT 
                    ProductID,
                    ProductName,
                    QuantityPurchased AS Quantity,
                    RawPrice AS RawCost,
                    Source AS Supplier,
                    DatePurchased,
                    (QuantityPurchased * RawPrice) AS TotalCost
                FROM Products
                WHERE IsReturned = 1;";


                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvSupplyArchives.DataSource = dt;

                foreach (DataGridViewRow row in dgvSupplyArchives.Rows)
                {
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (quantity == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }

                // Optional: Set nicer column headers
                dgvSupplyArchives.Columns["ProductID"].Visible = false;
                dgvSupplyArchives.Columns["ProductName"].HeaderText = "Product";
                dgvSupplyArchives.Columns["Quantity"].HeaderText = "Quantity";
                dgvSupplyArchives.Columns["RawCost"].HeaderText = "Raw Cost";
                dgvSupplyArchives.Columns["Supplier"].HeaderText = "Supplier";
                dgvSupplyArchives.Columns["DatePurchased"].HeaderText = "Date Purchased";
                dgvSupplyArchives.Columns["TotalCost"].HeaderText = "Total Cost";

                // Make sure all columns fit well
                dgvSupplyArchives.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSupplyArchives.ReadOnly = true;
                dgvSupplyArchives.AllowUserToAddRows = false;
                dgvSupplyArchives.AllowUserToDeleteRows = false;
                dgvSupplyArchives.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSupplyArchives.MultiSelect = false;
                dgvSupplyArchives.ClearSelection();
                dgvSupplyArchives.DefaultCellStyle.SelectionBackColor = dgvSupplyArchives.DefaultCellStyle.BackColor;
                dgvSupplyArchives.DefaultCellStyle.SelectionForeColor = dgvSupplyArchives.DefaultCellStyle.ForeColor;
                dgvSupplyArchives.Sorted -= dgvSupplyArchives_Sorted; // remove if already attached
                dgvSupplyArchives.Sorted += dgvSupplyArchives_Sorted;

            }
        }
        private void dgvSupplyArchives_Sorted(object sender, EventArgs e)
        {
            ColorRows(); // re-apply row colors after sorting
        }
        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvSupplyArchives.Rows)
            {
                if (Convert.ToInt32(row.Cells["Quantity"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void Back_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
