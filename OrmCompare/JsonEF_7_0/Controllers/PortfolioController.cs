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

        [HttpGet("portfolio")]
        public async Task<IActionResult> GetPortfolio([FromQuery(Name = "id")] int portfolioId)
        {
            var res = await _repository.GetPortfolio(portfolioId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio([FromBody] portfolio item)
        {
            await _repository.InsertPortfolio(item);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePortfolio([FromBody] portfolio item)
        {
            await _repository.UpdatePortfolio(item);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePortfolio([FromBody] int portfolioId)
        {
            await _repository.DeletePortfolio(portfolioId);
            return Ok();
        }
    }
}
