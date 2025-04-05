using System;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace StockSync
{
    public partial class Sales : Form
    {
        SqlConnection conn = DatabaseConnect.GetConnection();

        public Sales()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadProducts(string searchQuery = "")
        {
            try
            {
                conn.Open();
                string query = @"SELECT 
                        p.ProductID,
                        p.ProductName,
                        c.CategoryName,
                        MIN(i.ExpirationDate) AS ExpirationDate,
                        SUM(i.Stock) AS Stock,
                        i.SellingPrice
                    FROM Products p
                    JOIN Inventory i ON p.ProductID = i.ProductID
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    WHERE 
                        (i.IsArchived = 0 OR i.IsArchived IS NULL)
                        AND i.Stock > 0
                        AND (
                            i.ExpirationDate IS NULL
                            OR i.ExpirationDate >= GETDATE()
                        )
                        AND (p.ProductName LIKE @search OR c.CategoryName LIKE @search)
                    GROUP BY p.ProductID, p.ProductName, c.CategoryName, i.SellingPrice";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + searchQuery + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProducts.DataSource = dt;

                dgvProducts.Columns["ProductID"].Visible = false;
                dgvProducts.Columns["Stock"].Visible = false;
                dgvProducts.Columns["SellingPrice"].Visible = false;
                // Auto-size columns
                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set column headers
                dgvProducts.Columns["ProductName"].HeaderText = "Product Name";
                dgvProducts.Columns["CategoryName"].HeaderText = "Category";
                dgvProducts.Columns["ExpirationDate"].HeaderText = "Expiration Date";

                // Make columns read-only
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    col.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }

        private void Sales_Load_1(object sender, EventArgs e)
        {
            LoadProducts();
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearchProduct.Text);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                lblStockAvailable.Text = row.Cells["Stock"].Value.ToString();
                lblSellingPrice.Text = row.Cells["SellingPrice"].Value.ToString();
            }
        }
    }
}