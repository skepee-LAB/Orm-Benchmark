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

        public string GetPortfolios()
        {
            string query = "SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus FROM portfolio FOR JSON PATH";

            using (var conn = new SqlConnection(myContext._connectionString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand(query, conn);

                using (var rd = cm.ExecuteReader())
                    if (rd.HasRows)
                    {
                        var res = new StringBuilder();
                        while (rd.Read())
                        {
                            res.Append(rd.GetValue(0));
                        }
                        rd.Close();
                        return res.ToString();
                    }
                    else
                        return null;
            }
        }
    }
}
