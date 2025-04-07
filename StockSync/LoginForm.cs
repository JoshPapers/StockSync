using Microsoft.Data.SqlClient;
using System.Threading;

namespace StockSync
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please enter both username and password";
                lblMessage.Visible = true;
                return;
            }

            using (SqlConnection conn = DatabaseConnect.GetConnection())
            {
                conn.Open();
                string query = "SELECT UserID, Role FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // If user exists
                    {
                        int userID = Convert.ToInt32(reader["UserID"]);
                        string role = reader["Role"].ToString();

                        if (role == "Admin")
                        {
                            Thread.Sleep(500);
                            AdminDashboard adminDashboard = new AdminDashboard(userID); // Pass userID to AdminDashboard
                            adminDashboard.Show();
                            this.Hide();
                        }
                        else if (role == "Cashier")
                        {
                            Thread.Sleep(500);
                            CashierDashboard cashierDashboard = new CashierDashboard(userID); // Pass userID to CashierDashboard
                            cashierDashboard.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide password
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}