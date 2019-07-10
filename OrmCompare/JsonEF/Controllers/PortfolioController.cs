using System.Data.SqlClient;
using JsonEF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JsonEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        private readonly string connString = "xxxxx";

        [HttpGet]
        [Route("ef")]
        public IActionResult GetPortfolios()
        {
            var connection = new SqlConnection(connString);
            var options = new DbContextOptionsBuilder<MyContext>().UseSqlServer(connection).Options;

            using (var context = new MyContext(options))
            {
                var portfolioRep = new PortfolioRepository(context);
                var res = portfolioRep.GetPortfolios();

                return Ok(res);
            }
        }
    }
}
