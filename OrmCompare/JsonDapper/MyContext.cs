using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JsonDapper
{
    public class MyContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public MyContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("local");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
