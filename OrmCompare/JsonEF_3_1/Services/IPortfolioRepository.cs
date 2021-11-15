using JsonEF_3_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonEF_3_1.Services
{
    public interface IPortfolioRepository
    {
        IEnumerable<portfolio> GetPortfolios();
    }
}
