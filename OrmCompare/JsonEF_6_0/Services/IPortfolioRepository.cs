using JsonEF_6_0.Models;

namespace JsonEF_6_0.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<portfolio> GetPortfolios();
        void InsertPortfolio(portfolio item);
        void UpdatePortfolio(portfolio item);
        void DeletePortfolio(int portfolioId);
    }
}
