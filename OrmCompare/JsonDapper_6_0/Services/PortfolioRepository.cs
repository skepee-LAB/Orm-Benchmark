using Dapper;
using JsonDapper_6_0.Models;
using System.Data;

namespace JsonDapper_6_0.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private readonly MyContext myContext;
         
        public PortfolioRepository(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public void DeletePortfolio(int portfolioId)
        {
            using (var conn = myContext.CreateConnection())
            {
                conn.Query<Portfolio>("PortfolioDel", new { portfolioId=portfolioId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<Portfolio> GetPortfolios()
        {
            using (var conn = myContext.CreateConnection())
            {
                var res = conn.Query<Portfolio>("PortfolioList", commandType: CommandType.StoredProcedure).AsEnumerable();
                return res;
            }
        }

        public void InsertPortfolio(Portfolio item)
        {
            using (var conn = myContext.CreateConnection())
            {
                var values = new
                {
                    portfolioCode = item.PortfolioCode,
                    portfolioName = item.PortfolioName,
                    portfolioType = item.PortfolioType,
                    portfolioStatus = item.PortfolioStatus
                };

                conn.Query<Portfolio>("PortfolioIns", values, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void UpdatePortfolio(Portfolio item)
        {
            using (var conn = myContext.CreateConnection())
            {
                var values = new
                {
                    portfolioId = item.PortfolioId,
                    portfolioCode = item.PortfolioCode,
                    portfolioName = item.PortfolioName,
                    portfolioType = item.PortfolioType,
                    portfolioStatus = item.PortfolioStatus
                };

                conn.Query<Portfolio>("PortfolioUpd", values, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
