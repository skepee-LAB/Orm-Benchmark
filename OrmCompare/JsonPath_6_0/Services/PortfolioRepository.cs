using JsonPath_6_0.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JsonPath_6_0.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private readonly MyContext _myContext;

        public PortfolioRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task DeletePortfolio(int portfolioId)
        {
            using (var conn = new SqlConnection(_myContext._connectionString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("PortfolioDel", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "portfolioId", Value = portfolioId, Direction = ParameterDirection.Input });
                await cm.ExecuteNonQueryAsync();
                conn.Close();
            }
        }

        public async Task<string> GetPortfolio(int portfolioId)
        {
            string jsonres = string.Empty;
            using (var conn = new SqlConnection(_myContext._connectionString))
            {
                var jsonItem = JsonConvert.SerializeObject(portfolioId);
                conn.Open();
                SqlCommand cm = new SqlCommand("JsonGet", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "portfolioId", Value = jsonItem, Direction = ParameterDirection.Input });

                using (var rd = cm.ExecuteReader())
                    if (rd.HasRows)
                    {
                        var dt = new DataTable();
                        dt.Load(rd);
                        jsonres = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    }

                conn.Close();
            }
            return jsonres;
        }

        public async Task<string> GetPortfolios()
        {
            string jsonres = string.Empty;
            using (var conn = new SqlConnection(_myContext._connectionString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("JsonList", conn);
                cm.CommandType = CommandType.StoredProcedure;

                using (var rd = cm.ExecuteReader())
                    if (rd.HasRows)
                    {
                        var dt = new DataTable();
                        dt.Load(rd);
                        jsonres = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    }
                conn.Close();
            }
            return jsonres;
        }

        public async Task InsertPortfolio(portfolio item)
        {
            using (var conn = new SqlConnection(_myContext._connectionString))
            {
                var jsonItem = JsonConvert.SerializeObject(item);
                conn.Open();
                SqlCommand cm = new SqlCommand("JsonInsert", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() {SqlDbType=SqlDbType.NVarChar, ParameterName="jsonItem", Value=jsonItem, Direction=ParameterDirection.Input });
                await cm.ExecuteNonQueryAsync();
                conn.Close();
            }
        }

        public async Task UpdatePortfolio(portfolio item)
        {
            using (var conn = new SqlConnection(_myContext._connectionString))
            {
                var jsonItem = JsonConvert.SerializeObject(item);
                conn.Open();
                SqlCommand cm = new SqlCommand("JsonUpdate", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "jsonItem", Value = jsonItem, Direction = ParameterDirection.Input });
                await cm.ExecuteNonQueryAsync();
                conn.Close();
            }
        }
    }
}
