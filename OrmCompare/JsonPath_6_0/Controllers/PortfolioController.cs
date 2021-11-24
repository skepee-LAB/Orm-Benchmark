using JsonPath_6_0.Services;
using Microsoft.AspNetCore.Mvc;

namespace JsonPath_6_0.Controllers
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
        [Route("jsonpath")]
        public IActionResult GetPortfolios()
        {
            var res = repository.GetPortfolios();

            return Ok(res);
        }
    }
}
