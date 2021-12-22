using JsonPath_6_0.Models;

namespace JsonPath_6_0.Services
{
    public interface IPortfolioRepository
    {
        string GetPortfolios();
        void InsertPortfolio(portfolio item);
        void UpdatePortfolio(portfolio item);
        void DeletePortfolio(int portfolioId);

    }
}
