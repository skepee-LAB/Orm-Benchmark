using Dapper;
using JsonDapper.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace JsonDapper.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private readonly MyContext myContext;
         
        public PortfolioRepository(MyContext _myContext)
        {
            myContext = _myContext;
        }

        public IEnumerable<Portfolio> GetPortfolios()
        {
            string query = "SELECT portfolioId, portfolioCode, portfolioName, portfolioType, portfolioStatus FROM portfolio";

            using (var conn = myContext.CreateConnection())
            {
                var res = conn.Query<Portfolio>(query).AsEnumerable();
                return res;
            }
        }
    }
}
