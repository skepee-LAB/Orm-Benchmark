using JsonDapper_6_0.Models;
using System.Collections.Generic;

namespace JsonDapper_6_0.Services
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
