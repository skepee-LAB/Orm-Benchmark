using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace BenchmarkJsonPath
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _connectionstring;
        private SqlConnection _connection;

        [GlobalSetup]
        public void Init()
        {
            _connectionstring = "Server=localhost;Database=DB_Orm;Trusted_Connection=True;";
        }

        [Benchmark]
        public void EF6_GetSingle()
        {
            int portfolioId = 100;
            using (_connection = new SqlConnection(_connectionstring))
            {
                var jsonItem = JsonConvert.SerializeObject(portfolioId);
                _connection.Open();
                SqlCommand cm = new SqlCommand("JsonGet", _connection);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "portfolioId", Value = jsonItem, Direction = ParameterDirection.Input });

                using (var rd = cm.ExecuteReader())
                    if (rd.HasRows)
                    {
                        var dt = new DataTable();
                        dt.Load(rd);
                        _ = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    }

                _connection.Close();
            }
        }

        [Benchmark]
        public void EF6_GetList()
        {
            using (_connection = new SqlConnection(_connectionstring))
            {
                _connection.Open();
                SqlCommand cm = new SqlCommand("JsonList", _connection);
                cm.CommandType = CommandType.StoredProcedure;

                using (var rd = cm.ExecuteReader())
                    if (rd.HasRows)
                    {
                        var dt = new DataTable();
                        dt.Load(rd);
                        _ = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    }
                _connection.Close();
            }
        }
    }
}
