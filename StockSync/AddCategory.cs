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
    public partial class AddCategory : Form
    {
        // Database connection string (update this if needed)
        private string connectionString = "Server=LAPTOP-ESH3CLDI;Database=POS_Inventory;Integrated Security=True;TrustServerCertificate=True;";

        // Event to notify other forms (like Inventory) when a category is added
        public event Action CategoryAdded = delegate { };

        public AddCategory()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Center the form when opened
        }

        // Closes the form when "Back" button is clicked
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for "Add Category" button click
        private void addCat_Click(object sender, EventArgs e)
        {
            // Validate input: Check if the category name is empty or just whitespace
            if (string.IsNullOrWhiteSpace(Category.Text))
            {
                MessageBox.Show("Category name cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show a confirmation dialog before adding the category
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to add this product?",
                "Confirm Addition",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Proceed only if the user clicks "Yes"
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Check if the category already exists
                        string checkQuery = "SELECT COUNT(*) FROM Categories WHERE CategoryName = @CategoryName";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@CategoryName", Category.Text);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Category already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Insert new category into the database
                        string insertQuery = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", Category.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    // Fire the event to update the Inventory form
                    CategoryAdded?.Invoke();
                    // Close the form after successful addition
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Display an error message if something goes wrong
                    MessageBox.Show("Error adding category: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
