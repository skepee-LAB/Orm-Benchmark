using JsonPath.Controllers;
using Xunit;

namespace XUnitTestJsonPath
{
    public class GetPortfolios
    {
        [Fact]
        public void Get_16000_Portfolios()
        {
            //arrange
            var pcontroller = new ValuesController();

            //act
            var res=pcontroller.PortfoliosListPath();

            var output = (Microsoft.AspNetCore.Mvc.ObjectResult)res;

            //assert
            Assert.True(output.StatusCode==200 && output.Value.ToString().Split("portfoliocode").Length>16000);
        }
    }
}
