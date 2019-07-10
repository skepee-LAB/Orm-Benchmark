using JsonEF.Controllers;
using JsonEF.Models;
using System.Collections.Generic;
using Xunit;

namespace XUnitJsonEF
{
    public class GetPortfolios
    {
        [Fact]
        public void Get_16000_Portfolios()
        {
            //arrange
            var portfolioController = new PortfolioController();

            //act
            var res=portfolioController.GetPortfolios();
            Microsoft.AspNetCore.Mvc.ObjectResult output = (Microsoft.AspNetCore.Mvc.ObjectResult)res;
            var list = (List<tbl_pm01_portfolio>)output.Value;

            //assert
            Assert.True(output.StatusCode.Value == 200);
            Assert.True(list.Count > 16000);
        }
    }
}
