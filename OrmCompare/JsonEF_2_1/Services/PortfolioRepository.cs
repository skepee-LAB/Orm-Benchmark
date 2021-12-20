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

        public void DeletePortfolio(int portfolioId)
        {
            var item = _myContext.Portfolio.FirstOrDefault(x => x.PortfolioId == portfolioId);

            if (item != null)
            {
                _myContext.Portfolio.Remove(item);
                _myContext.SaveChanges();
            }
        }

        public void InsertPortfolio(portfolio item)
        {
            if (item != null)
            {
                _myContext.Portfolio.Add(item);
                _myContext.SaveChanges();
            }
        }

        public void UpdatePortfolio(portfolio item)
        {
            if (item != null)
            {
                _myContext.Portfolio.Update(item);
                _myContext.SaveChanges();
            }
        }
    }
}
