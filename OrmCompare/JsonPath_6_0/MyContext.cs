using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JsonPath_6_0
{
    public class MyContext
    {
        private readonly IConfiguration _configuration;
        public readonly string _connectionString;

        public MyContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("local");
        }
    }
}
