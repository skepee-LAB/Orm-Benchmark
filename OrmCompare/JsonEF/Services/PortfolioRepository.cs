using JsonEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace JsonEF.Services
{
    public class PortfolioRepository
    {
        private MyContext _myContext;


        public PortfolioRepository(MyContext myContext)
        {
            _myContext = myContext;
        }


        public IEnumerable<tbl_pm01_portfolio> GetPortfolios()
        {
            return _myContext.tbl_pm01_portfolio.ToList();
        }




    }
}
