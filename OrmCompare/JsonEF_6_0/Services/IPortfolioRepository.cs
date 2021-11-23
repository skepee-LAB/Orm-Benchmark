using JsonEF_6_0.Models;

namespace JsonEF_6_0.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<portfolio> GetPortfolios();
    }
}
