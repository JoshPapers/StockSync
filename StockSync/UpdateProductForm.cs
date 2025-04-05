using Microsoft.Data.SqlClient;

namespace StockSync
{
    public partial class UpdateProductForm : Form
    {
        private int productId; // Store Product ID for updating
        private Dictionary<string, int> categoryDict = new Dictionary<string, int>(); // Store category names and IDs

        public UpdateProductForm(int id, string name, string category)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center screen

            // Assign received values to the form fields
            productId = id;
            ProductNm.Text = name;

            // Populate categories
            LoadCategories();

            if (categoryDict.ContainsKey(category))
            {
                Category.SelectedValue = categoryDict[category]; // Set category ID
            }
            else
            {
                Category.SelectedIndex = -1; // No matching category found
            }


        }

        private void LoadCategories()
        {
            // Populate Category ComboBox with category IDs and names
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        categoryDict.Clear(); // Clear previous data
                        Category.Items.Clear();

                        while (reader.Read())
                        {
                            int categoryId = reader.GetInt32(0);
                            string categoryName = reader.GetString(1);

                            categoryDict[categoryName] = categoryId;
                            Category.Items.Add(categoryName);
                        }
                    }
                }
            }
        }
        private void UpdateProductInDatabase(int id, string name, object category)
        {
            string queryProduct = "UPDATE Products SET ProductName=@name, CategoryID=@category WHERE ProductID=@id";

            using (SqlConnection connection = DatabaseConnect.GetConnection())
            {
                connection.Open();

                // Update Products Table (removes SellingPrice update)
                using (SqlCommand cmd = new SqlCommand(queryProduct, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateProductForm_Load(object sender, EventArgs e)
        {
            // Form Load logic if needed
        }



        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save the changes?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(ProductNm.Text))
                {
                    MessageBox.Show("Product Name cannot be empty!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                object updatedCategory;
                if (RemoveCategory.Checked || string.IsNullOrWhiteSpace(Category.Text))
                {
                    updatedCategory = DBNull.Value; // If category is removed, store as null
                }
                else if (!categoryDict.ContainsKey(Category.Text))
                {
                    MessageBox.Show("The selected category does not exist.", "Invalid Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    updatedCategory = categoryDict[Category.Text]; // Get category ID from dictionary
                }
                string updatedName = ProductNm.Text;
                UpdateProductInDatabase(productId, updatedName, updatedCategory);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form after saving
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}