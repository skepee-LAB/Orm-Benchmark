using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace JsonPath.Controllers
{
    [Route("api/portfolios")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("jsonpath")]
        public IActionResult PortfoliosListPath()
        {
            var connString = "Server = localhost; Database = DB_Orm; Trusted_Connection = True;";

            string qry = "SELECT portfoliocode, portfolioname, portfoliotype, portfoliostatus FROM dbo.portfolio FOR JSON PATH";

            using (var conn = new SqlConnection(connString))
            {
                var res = new StringBuilder();
                conn.Open();
                SqlCommand cm = new SqlCommand(qry, conn);
                SqlDataReader rd = cm.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        res.Append(rd.GetValue(0));
                    }
                    rd.Close();
                    cm.Dispose();
                    conn.Close();
                    return Ok(res.ToString());
                }
                else
                    return null;
            }

        }


    }
}
