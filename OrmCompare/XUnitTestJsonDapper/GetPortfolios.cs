using JsonDapper.Controllers;
using JsonDapper.Models;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestJsonDapper
{
    public class GetPortfolios
    {
        [Fact]
        public void Get_16000_Portfolios()
        {
            //arrange
            var pcontroller = new PortfolioController();

            //act
            var res =pcontroller.PortfoliosListDapper();
            Microsoft.AspNetCore.Mvc.ObjectResult output = (Microsoft.AspNetCore.Mvc.ObjectResult)res;
            var list = (List<Portfolio>)output.Value;

            //assert
            Assert.True(output.StatusCode.Value == 200);
            Assert.True(list.Count>16000);
        }
    }
}
