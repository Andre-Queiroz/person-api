using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace person_api.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection OpenDatabaseConnection()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return connection;
        }
    }
}