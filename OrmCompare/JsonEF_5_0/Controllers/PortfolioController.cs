using JsonEF_5_0.Models;
using JsonEF_5_0.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonEF_5_0.Controllers
{
    [Route("api/[controller]/ef5_0")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioController(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetPortfolios()
        {
            var res = _repository.GetPortfolios();
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
