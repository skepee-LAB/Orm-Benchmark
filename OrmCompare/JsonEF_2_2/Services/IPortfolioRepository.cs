using JsonEF_2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonEF_2_2.Services
{
    interface IPortfolioRepository
    {
        IEnumerable<portfolio> GetPortfolios();
    }
}
