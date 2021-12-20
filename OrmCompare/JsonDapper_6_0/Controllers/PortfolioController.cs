using Microsoft.AspNetCore.Mvc;
using JsonDapper_6_0.Services;
using JsonDapper_6_0.Models;

namespace JsonDapper_6_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository PortfolioRepository;

        public PortfolioController(IPortfolioRepository _PortfolioRepository)
        {
            PortfolioRepository = _PortfolioRepository;
        }

        [HttpGet]
        [Route("dapper")]
        public IActionResult PortfoliosListDapper()
        {
            var res = PortfolioRepository.GetPortfolios();
            return Ok(res);
        }

        [HttpPut]
        [Route("dapper")]
        public IActionResult PortfolioPutDapper([FromBody] Portfolio item)
        {
            PortfolioRepository.UpdatePortfolio(item);
            return Ok();
        }

        [HttpPost]
        [Route("dapper")]
        public IActionResult PortfolioInsertDapper([FromBody] Portfolio item)
        {
            PortfolioRepository.InsertPortfolio(item);
            return Ok();
        }

        [HttpDelete]
        [Route("dapper")]
        public IActionResult PortfolioDeleteDapper([FromBody] int portfolioId)
        {
            PortfolioRepository.DeletePortfolio(portfolioId);
            return Ok();
        }
    }
}
