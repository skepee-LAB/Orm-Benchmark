using Dapper;
using JsonDapper_6_0.Models;
using System.Data;

namespace JsonDapper_6_0.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private readonly MyContext _myContext;
         
        public PortfolioRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task DeletePortfolio(int portfolioId)
        {
            using (var conn = _myContext.CreateConnection())
            {
                await conn.ExecuteAsync("PortfolioDel", new { portfolioId }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<portfolio>> GetPortfolios()
        {
            using (var conn = _myContext.CreateConnection())
            {
                return await conn.QueryAsync<portfolio>("PortfolioList", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task InsertPortfolio(portfolio item)
        {
            using (var conn = _myContext.CreateConnection())
            {
                await conn.ExecuteAsync("PortfolioIns", item, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdatePortfolio(portfolio item)
        {
            using (var conn = _myContext.CreateConnection())
            {
                await conn.ExecuteAsync("PortfolioUpd", item, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<portfolio> GetPortfolio(int portfolioId)
        {
            using (var conn = _myContext.CreateConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<portfolio>("PortfolioGet", new { portfolioId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
