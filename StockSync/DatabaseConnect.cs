using Microsoft.Data.SqlClient;

namespace StockSync
{
    public static class DatabaseConnect
    {
        private static readonly string connectionString = "Server=LAPTOP-ESH3CLDI;Database=POS_Inventory;Integrated Security=True;TrustServerCertificate=True;Connection Timeout=60;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
