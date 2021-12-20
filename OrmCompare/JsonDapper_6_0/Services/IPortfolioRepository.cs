using JsonDapper_6_0.Models;
using System.Collections.Generic;

namespace JsonDapper_6_0.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> GetPortfolios();
        void InsertPortfolio(Portfolio item);
        void UpdatePortfolio(Portfolio item);
        void DeletePortfolio(int portfolioId);

    }
}
