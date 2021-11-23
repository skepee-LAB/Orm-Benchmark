using JsonDapper.Models;
using System.Collections.Generic;

namespace JsonDapper.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> GetPortfolios();
    }
}
