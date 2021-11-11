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
        [HttpGet]
        [Route("dapper")]
        public IActionResult PortfoliosListDapper()
        {
            string qry = "SELECT portfoliocode, portfolioname, portfoliotype, portfoliostatus FROM portfolio";

            var res = GetPortfolios(qry);
            return Ok(res);
        }



        internal IEnumerable<Portfolio> GetPortfolios(string query)
        {
            var connString = "Server = localhost; Database = DB_Orm; Trusted_Connection = True;";

            using (var conn = new SqlConnection(connString))
            {
               var res = conn.Query<Portfolio>(query).AsEnumerable();
               return res;
            }            
        }

    }
}
