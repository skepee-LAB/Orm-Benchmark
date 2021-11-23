using Microsoft.AspNetCore.Mvc;
using JsonDapper_6_0.Services;

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

    }
}
