using System;
using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private static readonly string connectionString = @"Server=LAPTOP-ESH3CLDI;Database=POS_Inventory;Trusted_Connection=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
}
