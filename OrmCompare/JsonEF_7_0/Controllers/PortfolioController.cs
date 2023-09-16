using JsonEF_7_0.Models;
using JsonEF_7_0.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonEF_7_0.Controllers
{
    [Route("api/[controller]/ef7_0")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioController(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPortfolios()
        {
            var res = await _repository.GetPortfolios();

            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddPortfolio([FromBody] portfolio item)
        {
            _repository.InsertPortfolio(item);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePortfolio([FromBody] portfolio item)
        {
            _repository.UpdatePortfolio(item);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemovePortfolio([FromBody] int portfolioId)
        {
            _repository.DeletePortfolio(portfolioId);
            return Ok();
        }
    }
}
