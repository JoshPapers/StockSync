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
    public partial class AddSupply : Form
    {
        private int currentUserID;
        public AddSupply(int userID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            currentUserID = userID;

            // Attach events for live total cost update
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            txtRawCost.TextChanged += txtRawCost_TextChanged;
            cboProductName.DropDownHeight = 150;
        }

        // Populate Product ComboBox
        private void PopulateProductComboBox()
        {
            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                string query = "SELECT ProductID, ProductName FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboProductName.DisplayMember = "ProductName";
                cboProductName.ValueMember = "ProductID";
                cboProductName.DataSource = dt;
                cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        private void AddSupply_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                HandleSupply();
            }
        }

        private bool ValidateInput()
        {
            if (cboProductName.SelectedItem == null && string.IsNullOrEmpty(cboProductName.Text))
            {
                MessageBox.Show("Please select or enter a product.");
                return false;
            }

            if (string.IsNullOrEmpty(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid, non-negative quantity.");
                return false;
            }

            if (string.IsNullOrEmpty(txtRawCost.Text) || !decimal.TryParse(txtRawCost.Text, out decimal rawCost) || rawCost < 0)
            {
                MessageBox.Show("Please enter a valid, non-negative raw cost.");
                return false;
            }

            if (string.IsNullOrEmpty(txtSupplier.Text))
            {
                MessageBox.Show("Please enter the supplier.");
                return false;
            }

            if (dtpPurchaseDate.Value == null)
            {
                MessageBox.Show("Please select a purchase date.");
                return false;
            }

            return true;
        }


        // Handle supply updates and new product addition
        private void HandleSupply()
        {
            string productName = cboProductName.Text.Trim();  // Get product name from ComboBox (typed or selected)
            string supplier = txtSupplier.Text.Trim();
            decimal rawCost = decimal.Parse(txtRawCost.Text);
            int quantity = int.Parse(txtQuantity.Text);
            DateTime purchaseDate = dtpPurchaseDate.Value.Date;

            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                connection.Open();

                // Check if the product already exists with the same name, supplier, and raw cost
                string checkQuery = @"
                SELECT ProductID FROM Products 
                WHERE ProductName = @ProductName 
                AND Source = @Supplier 
                AND RawPrice = @RawCost
                AND DatePurchased = @PurchaseDate"; // Bagong line na ito!

                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@ProductName", productName);
                checkCmd.Parameters.AddWithValue("@Supplier", supplier);
                checkCmd.Parameters.AddWithValue("@RawCost", rawCost);
                checkCmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate); // Ibind ang bagong parameter

                object result = checkCmd.ExecuteScalar();
                int productID;

                if (result != null)
                {
                    // Product exists, update the quantity and purchase date
                    productID = Convert.ToInt32(result);
                    string updateQuery = @"
                        UPDATE Products 
                        SET QuantityPurchased = QuantityPurchased + @Quantity, DatePurchased = @PurchaseDate
                        WHERE ProductID = @ProductID";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                    updateCmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                    updateCmd.Parameters.AddWithValue("@ProductID", productID);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Existing supply updated successfully!");
                    LoadSupplyRecords();
                }
                else
                {
                    // Insert as a new product (this case covers different price or supplier)
                    string insertProductQuery = @"
                        INSERT INTO Products (ProductName, CategoryID, QuantityPurchased, RawPrice, Source, DatePurchased)
                        VALUES (@ProductName, NULL, @Quantity, @RawCost, @Supplier, @PurchaseDate); 
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand insertProductCmd = new SqlCommand(insertProductQuery, connection);
                    insertProductCmd.Parameters.AddWithValue("@ProductName", productName);
                    insertProductCmd.Parameters.AddWithValue("@Quantity", quantity);
                    insertProductCmd.Parameters.AddWithValue("@RawCost", rawCost);
                    insertProductCmd.Parameters.AddWithValue("@Supplier", supplier);
                    insertProductCmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);

                    productID = Convert.ToInt32(insertProductCmd.ExecuteScalar());
                    MessageBox.Show("New product added to the system!");
                    LoadSupplyRecords();
                }

                // Refresh ComboBox to reflect the newly added product
                PopulateProductComboBox();
            }

            ClearFields();
        }

        // Clear all fields after operation
        private void ClearFields()
        {
            cboProductName.SelectedIndex = -1;
            txtQuantity.Clear();
            txtRawCost.Clear();
            txtSupplier.Clear();
            dtpPurchaseDate.Value = DateTime.Now;
            lblTotalCost.Text = "0";
        }

        // Back to Admin Dashboard
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard(currentUserID);
            adminDashboard.Show();
        }

        // Handle adding to supplies
        private void btnAddToSupplies_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                HandleSupply();
            }
        }

        // Handle ComboBox selection change (populate text boxes with existing product info)
        private void cboProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductName.SelectedIndex != -1)
            {
                int productID = Convert.ToInt32(cboProductName.SelectedValue);
                using (SqlConnection connection = DatabaseConnect.GetConnection())
                {
                    string query = @"
                        SELECT TOP 1 QuantityPurchased, RawPrice, Source
                        FROM Products
                        WHERE ProductID = @ProductID";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ProductID", productID);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtQuantity.Text = reader["QuantityPurchased"].ToString();
                        txtRawCost.Text = reader["RawPrice"].ToString();
                        txtSupplier.Text = reader["Source"].ToString();
                    }
                    reader.Close();
                }

                UpdateTotalCost(); // Update total when a product is selected
            }
        }

        // Initialize form and populate ComboBox
        private void AddSupply_Load_1(object sender, EventArgs e)
        {
            PopulateProductComboBox();
            LoadSupplyRecords();
        }
        private void LoadSupplyRecords()
        {
            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                string query = @"
                SELECT 
                    ProductName,
                    QuantityPurchased AS Quantity,
                    RawPrice AS RawCost,
                    Source AS Supplier,
                    DatePurchased,
                    (QuantityPurchased * RawPrice) AS TotalCost
                FROM Products
                WHERE ISNULL(IsReturned, 0) = 0
                ORDER BY DatePurchased DESC";


                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dtgvSupplyRecords.DataSource = dt;

                foreach (DataGridViewRow row in dtgvSupplyRecords.Rows)
                {
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    if (quantity == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }

                // Optional: Set nicer column headers
                dtgvSupplyRecords.Columns["ProductName"].HeaderText = "Product";
                dtgvSupplyRecords.Columns["Quantity"].HeaderText = "Quantity";
                dtgvSupplyRecords.Columns["RawCost"].HeaderText = "Raw Cost";
                dtgvSupplyRecords.Columns["Supplier"].HeaderText = "Supplier";
                dtgvSupplyRecords.Columns["DatePurchased"].HeaderText = "Date Purchased";
                dtgvSupplyRecords.Columns["TotalCost"].HeaderText = "Total Cost";

                // Make sure all columns fit well
                dtgvSupplyRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvSupplyRecords.ReadOnly = true;
                dtgvSupplyRecords.AllowUserToAddRows = false;
                dtgvSupplyRecords.AllowUserToDeleteRows = false;
                dtgvSupplyRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtgvSupplyRecords.MultiSelect = false;
                dtgvSupplyRecords.ClearSelection();
                dtgvSupplyRecords.DefaultCellStyle.SelectionBackColor = dtgvSupplyRecords.DefaultCellStyle.BackColor;
                dtgvSupplyRecords.DefaultCellStyle.SelectionForeColor = dtgvSupplyRecords.DefaultCellStyle.ForeColor;

            }
        }


        // NEW: TextChanged Events to update total cost
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void txtRawCost_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        // NEW: Method to compute total cost
        private void UpdateTotalCost()
        {
            if (int.TryParse(txtQuantity.Text, out int quantity) &&
                decimal.TryParse(txtRawCost.Text, out decimal rawCost))
            {
                decimal totalCost = quantity * rawCost;
                lblTotalCost.Text = totalCost.ToString("0.00");
            }
            else
            {
                lblTotalCost.Text = "0";
            }
        }

        private void btnMarkReturned_Click(object sender, EventArgs e)
        {
            if (dtgvSupplyRecords.SelectedRows.Count > 0)
            {
                string productName = dtgvSupplyRecords.SelectedRows[0].Cells["ProductName"].Value.ToString();
                string supplier = dtgvSupplyRecords.SelectedRows[0].Cells["Supplier"].Value.ToString();
                decimal rawCost = Convert.ToDecimal(dtgvSupplyRecords.SelectedRows[0].Cells["RawCost"].Value);

                using (SqlConnection connection = DatabaseConnect.GetConnection())
                {
                    connection.Open();

                    string query = @"
                UPDATE Products 
                SET IsReturned = 1
                WHERE ProductName = @ProductName 
                AND Source = @Supplier 
                AND RawPrice = @RawCost";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Supplier", supplier);
                    cmd.Parameters.AddWithValue("@RawCost", rawCost);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product marked as returned.");
                        LoadSupplyRecords(); // Refresh table
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark as returned.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product row to mark as returned.");
            }
        }
    }
}
