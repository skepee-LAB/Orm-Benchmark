using System.Data.SqlClient;
using JsonEF_2_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JsonEF_2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        private readonly MyContext context;

        public PortfolioController(MyContext _context)
        {
            context = _context ;
        }

        [HttpGet]
        [Route("ef")]
        public IActionResult GetPortfolios()
        {
            var portfolioRep = new PortfolioRepository(context);
            var res = portfolioRep.GetPortfolios();

            return Ok(res);
        }
    }
}
