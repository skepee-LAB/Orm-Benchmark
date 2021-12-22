using JsonPath_6_0.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace JsonPath_6_0.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private readonly MyContext myContext;

        public PortfolioRepository(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public void DeletePortfolio(int portfolioId)
        {
            using (var conn = new SqlConnection(myContext._connectionString))
            {
                conn.Open();

                SqlCommand cm = new SqlCommand("PortfolioDel", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "portfolioId", Value = portfolioId, Direction = ParameterDirection.Input });
                cm.ExecuteNonQuery();
                conn.Close();
            }

        }

        public string GetPortfolios()
        {
            string jsonres = string.Empty;
            using (var conn = new SqlConnection(myContext._connectionString))
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

        public void InsertPortfolio(portfolio item)
        {
            using (var conn = new SqlConnection(myContext._connectionString))
            {
                var jsonItem = JsonConvert.SerializeObject(item);
                conn.Open();

                SqlCommand cm = new SqlCommand("JsonInsert", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() {SqlDbType=SqlDbType.NVarChar, ParameterName="jsonItem", Value=jsonItem, Direction=ParameterDirection.Input });
                cm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdatePortfolio(portfolio item)
        {
            using (var conn = new SqlConnection(myContext._connectionString))
            {
                var jsonItem = JsonConvert.SerializeObject(item);
                conn.Open();

                SqlCommand cm = new SqlCommand("JsonUpdate", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, ParameterName = "jsonItem", Value = jsonItem, Direction = ParameterDirection.Input });
                cm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
