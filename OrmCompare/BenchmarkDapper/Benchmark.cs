using BenchmarkDotNet.Attributes;
using Dapper;
using JsonDapper_6_0.Models;
using System.Data;
using System.Data.SqlClient;

namespace BenchmarkDapper
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
                _connection.QueryFirstOrDefault<portfolio>("PortfolioGet", new { portfolioId }, commandType: CommandType.StoredProcedure);
            }
        }

        [Benchmark]
        public void EF6_GetList()
        {
            using (_connection = new SqlConnection(_connectionstring))
            {
                _connection.Query<portfolio>("PortfolioList", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
