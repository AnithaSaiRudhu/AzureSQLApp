
using System.Collections.Generic;
using System.Data.SqlClient;
using AzureSQLApp.Models;

namespace AzureSQLApp.Services
{
    public class ProductServices
    {
        private static string db_source = "appvmdb.database.windows.net";
        private static string db_user = "adminvb";
        private static string db_password = "Anitha@1994";
        private static string db_database = "app-dev";

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_database;
            return new SqlConnection(builder.ConnectionString);
        }

        public List<Product> GetProductfromSQL()
        {
            SqlConnection conn = GetConnection();
            List < Product > product_List = new List<Product>();
            string statement = "Select [ProductID],[ProductName],[Quantity] from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    };

                    product_List.Add(product);
                }
            }
            conn.Close();
            return product_List;
        }
    }
}
