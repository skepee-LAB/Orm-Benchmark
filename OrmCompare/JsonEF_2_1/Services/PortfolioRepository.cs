﻿using JsonEF_2_1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonEF_2_1.Services
{
    public class PortfolioRepository:IPortfolioRepository
    {
        private MyContext _myContext;

        public PortfolioRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<IEnumerable<portfolio>> GetPortfolios()
        {
            return await _myContext.portfolio.ToListAsync();
        }

        public async Task DeletePortfolio(int portfolioId)
        {
            var item = _myContext.portfolio.FirstOrDefault(x => x.PortfolioId == portfolioId);

            if (item != null)
            {
                _myContext.portfolio.Remove(item);
                await _myContext.SaveChangesAsync();
            }
        }

        public async Task InsertPortfolio(portfolio item)
        {
            if (item != null)
            {
                await _myContext.portfolio.AddAsync(item);
                await _myContext.SaveChangesAsync();
            }
        }

        public async Task UpdatePortfolio(portfolio item)
        {
            if (item != null)
            {
                _myContext.portfolio.Update(item);
                await _myContext.SaveChangesAsync();
            }
        }

        public async Task<portfolio> GetPortfolio(int portfolioId)
        {
            return await _myContext.portfolio.FirstOrDefaultAsync(x => x.PortfolioId == portfolioId);
        }
    }
}
