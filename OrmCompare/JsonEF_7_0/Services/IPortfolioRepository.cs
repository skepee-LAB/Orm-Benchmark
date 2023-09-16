using JsonEF_7_0.Models;

namespace JsonEF_7_0.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<portfolio> GetPortfolios();
        void InsertPortfolio(portfolio item);
        void UpdatePortfolio(portfolio item);
        void DeletePortfolio(int portfolioId);
    }
}
