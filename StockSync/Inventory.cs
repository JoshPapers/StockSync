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
                    string query = @"
                    SELECT 
                        i.InventoryID,
                        p.ProductID,
                        p.ProductName,
                        COALESCE(c.CategoryName, 'No Category') AS CategoryName,
                        i.Stock,
                        i.SellingPrice,
                        i.ExpirationDate
                    FROM Inventory i
                    INNER JOIN Products p ON i.ProductID = p.ProductID
                    LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                    WHERE (i.IsArchived = 0 OR i.IsArchived IS NULL)
                    AND i.Stock >= 0";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInventory.DataSource = dt;

                        dgvInventory.Columns["ProductID"].HeaderText = "Product ID";
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
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                string query = "SELECT ProductID, ProductName FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbProductName.DisplayMember = "ProductName"; // what shows in dropdown
                cmbProductName.ValueMember = "ProductID";     // what you use internally
                cmbProductName.DataSource = dt;
            }
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


            LoadProductNames();
            cmbProductName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductName.DropDownHeight = 150;
            int maxWidth = 0;
            using (Graphics g = cmbProductName.CreateGraphics())
            {
                foreach (var item in cmbProductName.Items)
                {
                    if (item is DataRowView drv)
                    {
                        // Get the ProductName text (DisplayMember)
                        string productName = drv[cmbProductName.DisplayMember]?.ToString() ?? string.Empty;
                        // Measure the width of the product name
                        int width = (int)g.MeasureString(productName, cmbProductName.Font).Width;
                        if (width > maxWidth)
                        {
                            maxWidth = width;
                        }
                    }
                }
            }
            // Set the dropdown width to the width of the widest product name plus some padding
            cmbProductName.DropDownWidth = maxWidth + 20;
            txtRawCost.ReadOnly = true;
            txtRawCost.TabStop = false;
            txtSupplyQuantity.ReadOnly = true;
            txtSupplyQuantity.TabStop = false;

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
                if (!decimal.TryParse(txtSellingPrice.Text, out decimal sellingPrice) || sellingPrice < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative selling price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtStockQuantity.Text, out int stock) || stock < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative stock quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int productId = Convert.ToInt32(cmbProductName.SelectedValue);
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
                    // 1. Kunin ang current QuantityPurchased (supply stock)
                    string checkSupplyQuery = "SELECT QuantityPurchased FROM Products WHERE ProductID = @ProductID";
                    using (SqlCommand checkCmd = new SqlCommand(checkSupplyQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ProductID", productId);
                        object result = checkCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int currentSupply = Convert.ToInt32(result);
                            int quantityToAdd = Convert.ToInt32(txtStockQuantity.Text);

                            if (quantityToAdd > currentSupply)
                            {
                                MessageBox.Show("Not enough supply stock! You only have " + currentSupply + " in supplies.", "Insufficient Supply", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // stop execution
                            }

                            // Proceed with updating QuantityPurchased
                            string updateProductQuery = "UPDATE Products SET QuantityPurchased = QuantityPurchased - @QuantityAdded WHERE ProductID = @ProductID";
                            using (SqlCommand updateCmd = new SqlCommand(updateProductQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@QuantityAdded", quantityToAdd);
                                updateCmd.Parameters.AddWithValue("@ProductID", productId);
                                updateCmd.ExecuteNonQuery();
                                //UpdateSupplyQuantityLabel(selectedProductName);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Supply data not found for the selected product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }

                MessageBox.Show("Product stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInventory();
                LoadProductNames();
                //UpdateSupplyQuantityLabel(selectedProductName);

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
                DialogResult confirmArchive = MessageBox.Show("Do you want to archive this product?", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmArchive == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dgvInventory.SelectedRows[0];
                    int inventoryId = Convert.ToInt32(selectedRow.Cells["InventoryID"].Value);
                    int stock = Convert.ToInt32(selectedRow.Cells["Stock"].Value);
                    DateTime? expirationDate = selectedRow.Cells["ExpirationDate"].Value as DateTime?;
                    int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);

                    // Check if the product is expired or has no stock
                    if (stock == 0)
                    {
                        ArchiveProduct(inventoryId); // Proceed with archiving the product
                        return;
                    }
                    else if (expirationDate.HasValue && expirationDate.Value < DateTime.Now)
                    {
                        ArchiveProduct(inventoryId); // Proceed with archiving the expired product
                        return;
                    }
                    else
                    {
                        // Ask the user if they want to return stock to the supply
                        DialogResult confirmReturnStock = MessageBox.Show("Do you want to return the stock to the supply?", "Return Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmReturnStock == DialogResult.Yes)
                        {
                            // Code to return stock to supply
                            ReturnStockToSupply(inventoryId, stock, productId);
                            ArchiveProduct(inventoryId); // Archive the product after return
                        }
                        else
                        {
                            MessageBox.Show("Product archived without returning stock.", "Action Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ArchiveProduct(inventoryId); // Just archive the product
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to archive.", "Archive Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ArchiveProduct(int inventoryId)
        {
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

        private void ReturnStockToSupply(int inventoryId, int stock, int productId)
        {
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                // Update the Inventory stock to 0 as it is returned
                string updateInventoryQuery = "UPDATE Inventory SET Stock = 0 WHERE InventoryID = @InventoryID";
                using (SqlCommand cmd = new SqlCommand(updateInventoryQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                    cmd.ExecuteNonQuery();
                }

                // Assuming there's a column for supply stock in your database
                string updateSupplyQuery = "UPDATE Products SET QuantityPurchased = QuantityPurchased + @Stock WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(updateSupplyQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Stock has been returned to the supply.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void UpdateTotalValues()
        {
            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                connection.Open();
                string query = @" SELECT 
                            SUM(i.Stock) AS TotalStocks, 
                            SUM(i.Stock * i.SellingPrice) AS TotalPrices
                          FROM Inventory i
                            WHERE (i.IsArchived = 0 OR i.IsArchived IS NULL)
                            AND COALESCE(i.Stock, 0) >= 0;";

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

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.SelectedValue != null && int.TryParse(cmbProductName.SelectedValue.ToString(), out int productId))
            {
                UpdateSupplyQuantityLabel(productId);
                DisplayRawCostAndSellingPrice(productId);
            }
        }
        private void UpdateSupplyQuantityLabel(int productId)
        {
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT QuantityPurchased FROM Products WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        txtSupplyQuantity.Text = result.ToString();
                    }
                    else
                    {
                        txtSupplyQuantity.Text = "0";
                    }
                }
            }
        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void DisplayRawCostAndSellingPrice(int productId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnect.GetConnection())
                {
                    string query = "SELECT RawPrice FROM Products WHERE ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        conn.Open();

                        // Fetch the raw cost
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            decimal rawCost = Convert.ToDecimal(result);
                            txtRawCost.Text = rawCost.ToString("C");  // Format as currency
                        }
                        else
                        {
                            txtRawCost.Text = "0.00";  // In case there's no raw cost
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching raw cost: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}