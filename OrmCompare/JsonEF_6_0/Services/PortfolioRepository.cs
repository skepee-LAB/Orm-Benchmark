using JsonEF_6_0.Models;

namespace JsonEF_6_0.Services
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

        public void DeletePortfolio(int portfolioId)
        {
            var item = _myContext.portfolio.FirstOrDefault(x => x.PortfolioId == portfolioId);

            if (item != null)
            {
                _myContext.portfolio.Remove(item);
                _myContext.SaveChanges();
            }
        }

        public void InsertPortfolio(portfolio item)
        {
            if (item != null)
            {
                _myContext.portfolio.Add(item);
                _myContext.SaveChanges();
            }
        }

        public void UpdatePortfolio(portfolio item)
        {
            if (item != null)
            {
                _myContext.portfolio.Update(item);
                _myContext.SaveChanges();
            }
        }
    }
}
