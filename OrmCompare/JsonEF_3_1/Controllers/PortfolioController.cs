using JsonEF_3_1.Models;
using JsonEF_3_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonEF_3_1.Controllers
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
        [Route("ef3_1")]
        public IActionResult GetPortfolios()
        {
            var res = repository.GetPortfolios();

            return Ok(res);
        }

        [HttpPost]
        [Route("ef3_1")]
        public IActionResult AddPortfolio([FromBody] portfolio item)
        {
            repository.InsertPortfolio(item);
            return Ok();
        }

        [HttpPut]
        [Route("ef3_1")]
        public IActionResult UpdatePortfolio([FromBody] portfolio item)
        {
            repository.UpdatePortfolio(item);
            return Ok();
        }

        [HttpDelete]
        [Route("ef3_1")]
        public IActionResult RemovePortfolio([FromBody] int portfolioId)
        {
            repository.DeletePortfolio(portfolioId);
            return Ok();
        }

    }
}
