using System.Data.SqlClient;
using JsonEF_3._1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JsonEF_3._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        //private readonly string connString = "xxxxx";
        private readonly PortfolioRepository repository;


        public PortfolioController(PortfolioRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        [Route("ef")]
        public IActionResult GetPortfolios()
        {
            var res = repository.GetPortfolios();

            return Ok(res);


            //var connection = new SqlConnection(connString);
            //var options = new DbContextOptionsBuilder<MyContext>().UseSqlServer(connection).Options;

            //using (var context = new MyContext(options))
            //{
            //    var portfolioRep = new PortfolioRepository(context);
            //    var res = portfolioRep.GetPortfolios();

            //    return Ok(res);
            //}
        }
    }
}
