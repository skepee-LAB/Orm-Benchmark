using JsonDapper.Net_6_0.Models;
using System.Collections.Generic;

namespace JsonDapper.Net_6_0.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> GetPortfolios();
    }
}
