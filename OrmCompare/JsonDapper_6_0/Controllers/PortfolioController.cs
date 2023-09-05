using Microsoft.AspNetCore.Mvc;
using JsonDapper_6_0.Services;
using JsonDapper_6_0.Models;

namespace JsonDapper_6_0.Controllers
{
    [Route("api/[controller]/dapper")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioController(IPortfolioRepository _portfolioRepository)
        {
            portfolioRepository = _portfolioRepository;
        }

        [HttpGet]
        public IActionResult PortfoliosListDapper()
        {
            var res = portfolioRepository.GetPortfolios();
            return Ok(res);
        }

        [HttpPut]
        public IActionResult PortfolioPutDapper([FromBody] Portfolio item)
        {
            portfolioRepository.UpdatePortfolio(item);
            return Ok();
        }

        [HttpPost]
        public IActionResult PortfolioInsertDapper([FromBody] Portfolio item)
        {
            portfolioRepository.InsertPortfolio(item);
            return Ok();
        }

        [HttpDelete]
        public IActionResult PortfolioDeleteDapper([FromBody] int portfolioId)
        {
            portfolioRepository.DeletePortfolio(portfolioId);
            return Ok();
        }
    }
}
