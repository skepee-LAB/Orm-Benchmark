using JsonPath_6_0.Models;

namespace JsonPath_6_0.Services
{
    public interface IPortfolioRepository
    {
        Task<string> GetPortfolios();
        Task InsertPortfolio(portfolio item);
        Task UpdatePortfolio(portfolio item);
        Task DeletePortfolio(int portfolioId);
        Task<string> GetPortfolio(int portfolioId);
    }
}
