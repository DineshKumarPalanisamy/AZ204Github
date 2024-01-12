using Microsoft.Data.SqlClient;
using Microsoft.FeatureManagement;
using SQLApp.Models;

namespace SQLApp.Services
{
    public class ProductService
    {

        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

        public ProductService(IConfiguration configuration, IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration["sqlconnectionstring"]);
        }

        public async Task<bool> IsBeta()
        {
            if (await _featureManager.IsEnabledAsync("beta"))
            {
                return true;
            }

            return false;
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
