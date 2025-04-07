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

        private int currentUserID;
        public Sales(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUserID = userID;
        }

        private void LoadProducts(string searchQuery = "")
        {
            try
            {
                conn.Open();
                string query = @"SELECT 
                        i.InventoryID,
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
                    GROUP BY i.InventoryID, p.ProductID, p.ProductName, c.CategoryName, i.SellingPrice";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + searchQuery + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProducts.DataSource = dt;

                dgvProducts.Columns["InventoryID"].Visible = false;
                dgvProducts.Columns["ProductID"].Visible = false;
                dgvProducts.Columns["Stock"].Visible = false;
                dgvProducts.Columns["SellingPrice"].Visible = false;

                // Auto-size columns for better visibility
                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set column headers
                dgvProducts.Columns["ProductName"].HeaderText = "Product Name";
                dgvProducts.Columns["CategoryName"].HeaderText = "Category";
                dgvProducts.Columns["ExpirationDate"].HeaderText = "Expiration Date";

                // Format expiration date
                dgvProducts.Columns["ExpirationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                // Adjust column sizes
                dgvProducts.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProducts.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvProducts.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Make columns read-only and disable user editing
                dgvProducts.ReadOnly = true;
                dgvProducts.AllowUserToAddRows = false;
                dgvProducts.AllowUserToDeleteRows = false;
                dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProducts.MultiSelect = false;
                dgvProducts.DefaultCellStyle.SelectionBackColor = dgvProducts.DefaultCellStyle.BackColor;
                dgvProducts.DefaultCellStyle.SelectionForeColor = dgvProducts.DefaultCellStyle.ForeColor;


                // Make columns read-only
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    col.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading products: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard(currentUserID);
            adminDashboard.Show();
        }

        private void Sales_Load_1(object sender, EventArgs e)
        {
            LoadProducts();
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            SetupCartGrid();
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
        private void SetupCartGrid()
        {
            dgvCart.Columns.Clear();

            // Add the InventoryID column (hidden)
            DataGridViewTextBoxColumn colInventoryID = new DataGridViewTextBoxColumn();
            colInventoryID.Name = "InventoryID"; // Use this name in your logic
            colInventoryID.HeaderText = "Inventory ID";
            colInventoryID.Visible = false;
            dgvCart.Columns.Add(colInventoryID);

            // Add the ProductID column (hidden)
            DataGridViewTextBoxColumn colProductID = new DataGridViewTextBoxColumn();
            colProductID.Name = "ProductID"; // This must match the name in the Sales_Insert query
            colProductID.HeaderText = "Product ID";
            colProductID.Visible = false;
            dgvCart.Columns.Add(colProductID);

            // Add other visible columns
            dgvCart.Columns.Add("ProductName", "Product Name");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("SellingPrice", "Selling Price");
            dgvCart.Columns.Add("Subtotal", "Subtotal");

            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.MultiSelect = false;
            dgvCart.DefaultCellStyle.SelectionBackColor = dgvCart.DefaultCellStyle.BackColor;
            dgvCart.DefaultCellStyle.SelectionForeColor = dgvCart.DefaultCellStyle.ForeColor;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgvCart.Columns)
            {
                col.ReadOnly = true;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                string inventoryId = dgvProducts.CurrentRow.Cells["InventoryID"]?.Value?.ToString() ?? string.Empty; // Get InventoryID from dgvProducts
                string productId = dgvProducts.CurrentRow.Cells["ProductID"]?.Value?.ToString() ?? string.Empty; // Get ProductID from dgvProducts
                string productName = dgvProducts.CurrentRow.Cells["ProductName"]?.Value?.ToString() ?? string.Empty; // Get ProductName from dgvProducts

                decimal price = Convert.ToDecimal(dgvProducts.CurrentRow.Cells["SellingPrice"].Value);
                int quantity = (int)numQuantity.Value;
                int stock = Convert.ToInt32(lblStockAvailable.Text);

                if (quantity <= 0 || quantity > stock)
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                // Check if InventoryID already exists in the cart
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells["InventoryID"]?.Value?.ToString() == inventoryId)
                    {
                        MessageBox.Show("Product (same expiration batch) already in cart.");
                        return;
                    }
                }

                decimal subtotal = price * quantity;

                // Add row with InventoryID first (must match the column order!)
                dgvCart.Rows.Add(inventoryId, productId, productName, quantity, price, subtotal);

                UpdateTotalAmount();
            }
        }
        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }
            lblTotalAmount.Text = total.ToString("0.00");
        }

        private void btnConfirmSale_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to confirm this sale?",
                                                  "Confirm Sale",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    // 1. Insert into Sales table
                    string insertSale = "INSERT INTO Sales (UserID, TotalAmount, SaleDate) VALUES (@UserID, @TotalAmount, GETDATE()); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdSale = new SqlCommand(insertSale, conn, transaction);
                    cmdSale.Parameters.AddWithValue("@UserID", currentUserID); // Assume may current user ID
                    cmdSale.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(lblTotalAmount.Text));

                    int saleID = Convert.ToInt32(cmdSale.ExecuteScalar());

                    // 2. Loop through cart to insert into Sales_Items and update Inventory
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        int inventoryID = Convert.ToInt32(row.Cells["InventoryID"].Value);
                        int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["SellingPrice"].Value);

                        // Update Inventory first: deduct the stock
                        string updateInventory = "UPDATE Inventory SET Stock = Stock - @Quantity WHERE InventoryID = @InventoryID";
                        SqlCommand cmdUpdate = new SqlCommand(updateInventory, conn, transaction);
                        cmdUpdate.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                        cmdUpdate.Parameters.Add("@InventoryID", SqlDbType.Int).Value = inventoryID;
                        cmdUpdate.ExecuteNonQuery();

                        // Insert into Sales_Items
                        string insertItem = @"INSERT INTO Sales_Items (SaleID, ProductID, Quantity, Price, InventoryID)
                      VALUES (@SaleID, @ProductID, @Quantity, @Price, @InventoryID)";
                        SqlCommand cmdItem = new SqlCommand(insertItem, conn, transaction);
                        cmdItem.Parameters.Add("@SaleID", SqlDbType.Int).Value = saleID;
                        cmdItem.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                        cmdItem.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                        cmdItem.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                        cmdItem.Parameters.Add("@InventoryID", SqlDbType.Int).Value = inventoryID;
                        cmdItem.ExecuteNonQuery();

                        if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.Cells["ProductID"].Value.ToString() == productID.ToString())
                        {
                            int updatedStock = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Stock"].Value) - quantity;
                            lblStockAvailable.Text = updatedStock.ToString();
                        }
                    }

                    // Commit the transaction after all the data is inserted/updated
                    transaction.Commit();
                    MessageBox.Show("Sale confirmed successfully.");

                    // Clear cart and reset total amount
                    dgvCart.Rows.Clear();
                    lblTotalAmount.Text = "0.00";
                    LoadProducts(); // Reload inventory list
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error confirming sale: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                // If the user cancels the confirmation, just do nothing
                return;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null)
            {
                dgvCart.Rows.Remove(dgvCart.CurrentRow);
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to cancel this transaction?", "Cancel Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvCart.Rows.Clear();
                    lblTotalAmount.Text = "0.00";
                }
            }
        }
    }
}