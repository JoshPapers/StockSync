using System.Data;
using Microsoft.Data.SqlClient;

namespace StockSync
{
    public partial class InventoryReportForm : Form
    {
        private int currentUserID;
        
        public InventoryReportForm(int userId)
        {
            InitializeComponent();
            currentUserID = userId;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void InventoryReportForm_Load(object sender, EventArgs e)
        {
            // Initialize the combo box with month names
            cmbMonth.Items.Clear();
            cmbMonth.Items.AddRange(new string[]
            {
        "January", "February", "March", "April", "May", "June", "July",
        "August", "September", "October", "November", "December"
            });
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1; // default to current month

            // Load product names into the combo box
            cmbProducts.Items.Clear();
            cmbProducts.Items.Add("All Products");

            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT ProductName FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbProducts.Items.Add(reader["ProductName"].ToString());
                    }
                }
            }
            cmbProducts.SelectedIndex = 0; // Default to "All Products"
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            int month = cmbMonth.SelectedIndex + 1;  // 1 = January, 12 = December
            int year = int.TryParse(txtYear.Text, out year) ? year : DateTime.Now.Year;
            string selectedProduct = cmbProducts.SelectedItem.ToString();

            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                string query;

                if (selectedProduct == "All Products")
                {
                    query = @"
                SELECT P.ProductName, 
                   COALESCE(C.CategoryName, 'N/A') AS CategoryName, 
                   I.Stock, 
                   I.ExpirationDate, 
                   I.DateAdded,
                   I.IsArchived
            FROM Inventory I
            JOIN Products P ON I.ProductID = P.ProductID
            LEFT JOIN Categories C ON P.CategoryID = C.CategoryID
            WHERE MONTH(I.DateAdded) = @Month AND YEAR(I.DateAdded) = @Year
            ";
                }
                else
                {
                    query = @"
                SELECT P.ProductName, 
                   COALESCE(C.CategoryName, 'N/A') AS CategoryName, 
                   I.Stock, 
                   I.ExpirationDate, 
                   I.DateAdded,
                   I.IsArchived
            FROM Inventory I
            JOIN Products P ON I.ProductID = P.ProductID
            LEFT JOIN Categories C ON P.CategoryID = C.CategoryID
            WHERE MONTH(I.DateAdded) = @Month AND YEAR(I.DateAdded) = @Year
            AND P.ProductName = @ProductName
            ";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);

                    if (selectedProduct != "All Products")
                        cmd.Parameters.AddWithValue("@ProductName", selectedProduct);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvInventoryReport.DataSource = dt;
                }
            }

            // Format the grid
            FormatInventoryGrid();
            ColorRows();
        }
        private void dgvInventoryReport_Sorted(object sender, EventArgs e)
        {
            ColorRows(); // re-apply row colors after sorting
        }
        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvInventoryReport.Rows)
            {
                if (row.IsNewRow) continue;

                bool isArchived = row.Cells["IsArchived"].Value != DBNull.Value && (bool)row.Cells["IsArchived"].Value;
                DateTime expirationDate = row.Cells["ExpirationDate"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["ExpirationDate"].Value)
                    : DateTime.MaxValue;
                int stock = row.Cells["Stock"].Value != DBNull.Value
                    ? Convert.ToInt32(row.Cells["Stock"].Value)
                    : 0;

                if (isArchived)
                {
                    // Archived = LemonChiffon
                    row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (stock == 0 )
                {
                    // Out of Stock or Expired (but not archived) = DarkRed
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (expirationDate.Date <= DateTime.Today)
                {
                    // Out of Stock or Expired (but not archived) = DarkRed
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Normal rows = default style
                    row.DefaultCellStyle.BackColor = dgvInventoryReport.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvInventoryReport.DefaultCellStyle.ForeColor;
                }
            }
        }

        private void FormatInventoryGrid()
        {
            dgvInventoryReport.Columns["ProductName"].HeaderText = "Product Name";
            dgvInventoryReport.Columns["CategoryName"].HeaderText = "Category";
            dgvInventoryReport.Columns["Stock"].HeaderText = "Quantity";
            dgvInventoryReport.Columns["ExpirationDate"].HeaderText = "Expiration Date";

            dgvInventoryReport.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInventoryReport.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInventoryReport.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInventoryReport.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInventoryReport.Columns["ExpirationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvInventoryReport.Columns["DateAdded"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvInventoryReport.ReadOnly = true;
            dgvInventoryReport.AllowUserToAddRows = false;
            dgvInventoryReport.AllowUserToDeleteRows = false;
            dgvInventoryReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventoryReport.MultiSelect = false;
            dgvInventoryReport.Columns["IsArchived"].Visible = false;
            dgvInventoryReport.MultiSelect = false;
            dgvInventoryReport.DefaultCellStyle.SelectionBackColor = dgvInventoryReport.DefaultCellStyle.BackColor;
            dgvInventoryReport.DefaultCellStyle.SelectionForeColor = dgvInventoryReport.DefaultCellStyle.ForeColor;

            dgvInventoryReport.Sorted -= dgvInventoryReport_Sorted; // remove if already attached
            dgvInventoryReport.Sorted += dgvInventoryReport_Sorted;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard(currentUserID);
            adminDashboard.Show();
        }
    }
}
