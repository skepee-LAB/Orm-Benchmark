using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JsonPath_6_0
{
    public class MyContext
    {
        private readonly IConfiguration _configuration;
        public readonly string _connectionString;
        //private SqlConnection conn { get; set; }

        public MyContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("local");
        }
        //public void CloseConnection()
        //{ 
        //    conn.Close();
        //}

        //public SqlCommand PortfolioCommand(string query)
        //{
        //    using (conn = new SqlConnection(_connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand cm = new SqlCommand(query, conn);
        //        //SqlDataReader rd = cm.ExecuteReader();
        //        //return rd;
        //        return cm;
        //    }            
        //}
    }
}
