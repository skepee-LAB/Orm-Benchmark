using JsonEF_6_0.Models;
using JsonEF_6_0.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonEF_6_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController: ControllerBase
    {
        private readonly IPortfolioRepository repository;

        public PortfolioController(IPortfolioRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        [Route("ef6_0")]
        public IActionResult GetPortfolios()
        {
            var res = repository.GetPortfolios();

            return Ok(res);
        }

        [HttpPost]
        [Route("ef6_0")]
        public IActionResult AddPortfolio([FromBody] portfolio item)
        {
            repository.InsertPortfolio(item);
            return Ok();
        }

        [HttpPut]
        [Route("ef6_0")]
        public IActionResult UpdatePortfolio([FromBody] portfolio item)
        {
            repository.UpdatePortfolio(item);
            return Ok();
        }

        [HttpDelete]
        [Route("ef6_0")]
        public IActionResult RemovePortfolio([FromBody] int portfolioId)
        {
            repository.DeletePortfolio(portfolioId);
            return Ok();
        }
    }
}
