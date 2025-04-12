using System.Data;
using Microsoft.Data.SqlClient;

namespace StockSync
{
    public partial class Inventory : Form
    {
        private int currentUserID;
        public Inventory(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUserID = userID;

        }

        // Load inventory items into the DataGridView
        private void LoadInventory()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                    i.InventoryID,
                    p.ProductID,
                    p.ProductName,
                    COALESCE(c.CategoryName, 'No Category') AS CategoryName,
                    COALESCE(i.Stock, 0) AS Stock,
                    i.SellingPrice,
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
                        dgvInventory.Columns["CategoryName"].HeaderText = "Category";
                        dgvInventory.Columns["Stock"].HeaderText = "Quantity";
                        dgvInventory.Columns["SellingPrice"].HeaderText = "Price";
                        dgvInventory.Columns["ExpirationDate"].HeaderText = "Expiry Date";

                        // Adjust column sizes
                        dgvInventory.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvInventory.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvInventory.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvInventory.Columns["SellingPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvInventory.Columns["ExpirationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        // Format price and expiration date columns
                        dgvInventory.Columns["SellingPrice"].DefaultCellStyle.Format = "C2";
                        dgvInventory.Columns["ExpirationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                        // Prevent editing
                        dgvInventory.ReadOnly = true;
                        dgvInventory.AllowUserToAddRows = false;
                        dgvInventory.AllowUserToDeleteRows = false;
                        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvInventory.MultiSelect = false;
                        dgvInventory.DefaultCellStyle.SelectionBackColor = dgvInventory.DefaultCellStyle.BackColor;
                        dgvInventory.DefaultCellStyle.SelectionForeColor = dgvInventory.DefaultCellStyle.ForeColor;

                        dgvInventory.Sorted -= dgvInventory_Sorted; // remove if already attached
                        dgvInventory.Sorted += dgvInventory_Sorted;

                        // **Baguhin ang kulay ng mga product na may 0 stock**
                        ColorRows();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (Convert.ToInt32(row.Cells["Stock"].Value) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
            foreach (DataGridViewRow row in dgvInventory.Rows)
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
        private void dgvInventory_Sorted(object sender, EventArgs e)
        {
            ColorRows(); // re-apply row colors after sorting
        }

        private void LoadProductNames()
        {
            cmbProductName.Items.Clear();

            string query = "SELECT DISTINCT ProductName FROM Products";
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbProductName.Items.Add(reader["ProductName"].ToString());
                }
            }

            // Allow manual input
            cmbProductName.DropDownStyle = ComboBoxStyle.DropDown;
            cmbProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // Load categories into the category combo box
        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT CategoryName FROM Categories";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbCategory.Items.Clear();
                            while (reader.Read())
                            {
                                string? categoryName = reader["CategoryName"] as string; // Safely cast as string

                                if (!string.IsNullOrEmpty(categoryName)) // Ensure it's not null or empty
                                {
                                    cmbCategory.Items.Add(categoryName);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
            LoadCategories();
            LoadProductNames();
            UpdateTotalValues();

            // Refresh Product Names after adding a product
            cmbProductName.Leave += (s, ev) => LoadProductNames();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard(currentUserID); // Pass the userID here
            adminDashboard.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddCategory categoryForm = new AddCategory();
            categoryForm.CategoryAdded += LoadCategories;
            categoryForm.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to add this product stock?", "Confirm Addition", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbProductName.Text))
                {
                    MessageBox.Show("Please enter or select a product name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedProductName = cmbProductName.Text.Trim();
                int categoryID = 0;

                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    conn.Open();

                    // 1. Check if category exists, otherwise insert new category
                    if (!string.IsNullOrWhiteSpace(cmbCategory.Text))
                    {
                        string checkCategoryQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName";
                        using (SqlCommand cmd = new SqlCommand(checkCategoryQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", cmbCategory.Text);
                            var result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                categoryID = Convert.ToInt32(result);
                            }
                            else
                            {
                                string insertCategoryQuery = "INSERT INTO Categories (CategoryName) OUTPUT INSERTED.CategoryID VALUES (@CategoryName)";
                                using (SqlCommand insertCmd = new SqlCommand(insertCategoryQuery, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@CategoryName", cmbCategory.Text);
                                    categoryID = (int)insertCmd.ExecuteScalar();
                                }
                            }
                        }
                    }

                    int productId;
                    decimal sellingPrice = Convert.ToDecimal(txtSellingPrice.Text);

                    // 2. Check if product already exists
                    string checkProductQuery = "SELECT ProductID FROM Products WHERE ProductName = @ProductName";
                    using (SqlCommand cmd = new SqlCommand(checkProductQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", selectedProductName);
                        var existingProductId = cmd.ExecuteScalar();

                        if (existingProductId != null)
                        {
                            productId = Convert.ToInt32(existingProductId);
                        }
                        else
                        {
                            // Insert new product if it does not exist
                            string insertProductQuery = "INSERT INTO Products (ProductName, CategoryID) OUTPUT INSERTED.ProductID VALUES (@ProductName, @CategoryID)";
                            using (SqlCommand insertCmd = new SqlCommand(insertProductQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@ProductName", selectedProductName);
                                insertCmd.Parameters.AddWithValue("@CategoryID", categoryID == 0 ? (object)DBNull.Value : categoryID);
                                productId = (int)insertCmd.ExecuteScalar();
                            }
                        }
                    }

                    // 3. Insert new inventory entry (always new since expiration date differs)
                    string insertInventoryQuery = "INSERT INTO Inventory (ProductID, Stock, ExpirationDate, SellingPrice) VALUES (@ProductID, @Stock, @ExpirationDate, @SellingPrice)";
                    using (SqlCommand cmdInsert = new SqlCommand(insertInventoryQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@ProductID", productId);
                        cmdInsert.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStockQuantity.Text));
                        cmdInsert.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmdInsert.Parameters.AddWithValue("@ExpirationDate", NoExp.Checked ? (object)DBNull.Value : dtpExpirationDate.Value);
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInventory();
                LoadProductNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateTotalValues();
        }

        // Disable expiration date picker if "No Exp" is checked
        private void NoExp_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpirationDate.Enabled = !NoExp.Checked;
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0) // Ensure a row is selected
            {
                // Get selected product details
                DataGridViewRow row = dgvInventory.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["ProductID"].Value);
                string name = row.Cells["ProductName"].Value?.ToString() ?? "Unknown";
                string category = row.Cells["CategoryName"]?.Value.ToString() ?? "Unknown";

                // Open UpdateProductForm and pass the product details
                UpdateProductForm updateForm = new UpdateProductForm(id, name, category);
                updateForm.FormClosed += (s, args) => LoadInventory();
                updateForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UpdateTotalValues();
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnArchiveProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                DialogResult confirmArchive = MessageBox.Show("Do you want to archive this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmArchive == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dgvInventory.SelectedRows[0];
                    int inventoryId = Convert.ToInt32(selectedRow.Cells["InventoryID"].Value);

                    using (SqlConnection conn = DatabaseConnect.GetConnection())
                    {
                        conn.Open();
                        string archiveQuery = "UPDATE Inventory SET IsArchived = 1 WHERE InventoryID = @InventoryID";
                        using (SqlCommand cmd = new SqlCommand(archiveQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Product has been archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInventory(); // Refresh inventory list to hide archived products
                }
            }
            else
            {
                MessageBox.Show("Please select a product to archive.", "Archive Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateTotalValues()
        {
            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                connection.Open();
                string query = @" SELECT 
                            SUM(i.Stock) AS TotalStocks, 
                            SUM(i.Stock * i.SellingPrice) AS TotalPrices
                          FROM Inventory i";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int totalStocks = reader["TotalStocks"] != DBNull.Value ? Convert.ToInt32(reader["TotalStocks"]) : 0;
                        decimal totalPrices = reader["TotalPrices"] != DBNull.Value ? Convert.ToDecimal(reader["TotalPrices"]) : 0;

                        TotalStocks.Text = totalStocks.ToString();
                        TotalPrices.Text = totalPrices.ToString("C"); // Currency format
                    }
                }
            }
        }


        private void TotalStocks_Click(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Archive_Click(object sender, EventArgs e)
        {
            Archive archives = new Archive();
            archives.ShowDialog();
        }
    }
}