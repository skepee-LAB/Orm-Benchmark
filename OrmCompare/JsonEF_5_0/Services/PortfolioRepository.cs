using JsonEF_5_0.Models;
using System.Collections.Generic;
using System.Linq;

namespace JsonEF_5_0.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private MyContext _myContext;

        public PortfolioRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IEnumerable<portfolio> GetPortfolios()
        {
            return _myContext.portfolio.ToList();
        }
    }
}
