using System.Data.SqlClient;
using System.Linq;
using JsonDapper.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Collections.Generic;

namespace JsonDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly string connString = "xxxxx";

        [HttpGet]
        [Route("dapper")]
        public IActionResult PortfoliosListDapper()
        {
            string qry = "SELECT portfolio_code, portfolio_name, portfolio_type, portfolio_status FROM dbo.tbl_pm01_portfolio";

            var res = GetPortfolios(qry);
            return Ok(res);
        }



        internal IEnumerable<Portfolio> GetPortfolios(string query)
        {
            using (var conn = new SqlConnection(connString))
            {
               var res = conn.Query<Portfolio>(query).AsEnumerable();
               return res;
            }            
        }

    }
}
