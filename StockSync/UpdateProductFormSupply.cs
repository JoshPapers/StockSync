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
    public partial class UpdateProductFormSupply : Form
    {
        private int productId;

        public UpdateProductFormSupply(int id, string name)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            productId = id;

            ProductNm.Text = name;
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT Source FROM Products WHERE ProductID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Source.Text = reader.GetString(0);
                        }
                    }
                }
            }
        }

        private void UpdateProductInDatabase(int id, string name, string source)
        {
            string query = "UPDATE Products SET ProductName = @name, Source = @source WHERE ProductID = @id";

            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@source", source ?? string.Empty);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void Save_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNm.Text))
            {
                MessageBox.Show("Product name cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updatedName = ProductNm.Text;
            string source = Source.Text;

            UpdateProductInDatabase(productId, updatedName, source);

            MessageBox.Show("Product details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

