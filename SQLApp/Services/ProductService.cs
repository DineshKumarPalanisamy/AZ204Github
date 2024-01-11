using Microsoft.Data.SqlClient;
using SQLApp.Models;

namespace SQLApp.Services
{
    public class ProductService
    {

        private readonly string _dbSource = "appserverdinessns.database.windows.net";
        private readonly string _dbUser = "dinessns";
        private readonly string _dbPassword = "snsDinesh@007";
        private readonly string _dbName = "appdb";

        private SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = _dbSource;
            sqlConnectionStringBuilder.UserID = _dbUser;
            sqlConnectionStringBuilder.Password = _dbPassword;
            sqlConnectionStringBuilder.InitialCatalog = _dbName;

            return new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        public List<Product> GetProducts()
        {

            var connection = GetConnection();

            var products = new List<Product>();

            string statement = "SELECT * FROM Products";

            connection.Open();

            SqlCommand cmd = new SqlCommand(statement, connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }
            }
            connection.Close();
            return products;
        }
    }
}
