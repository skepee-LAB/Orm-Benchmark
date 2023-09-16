using JsonEF_7_0.Models;

namespace JsonEF_7_0.Services
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<portfolio>> GetPortfolios();
        Task InsertPortfolio(portfolio item);
        Task UpdatePortfolio(portfolio item);
        Task DeletePortfolio(int portfolioId);
        Task<portfolio> GetPortfolio(int portfolioId);
    }
}
