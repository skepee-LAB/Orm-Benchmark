using JsonEF_2_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace JsonEF_2_1.Services
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
            return _myContext.Portfolio.AsEnumerable();
        }
    }
}
