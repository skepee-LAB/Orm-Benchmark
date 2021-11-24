using JsonEF_2_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonEF_2_1.Controllers
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
        [Route("ef2_1")]
        public IActionResult GetPortfolios()
        {
            var res = repository.GetPortfolios();

            return Ok(res);
        }
    }
}
