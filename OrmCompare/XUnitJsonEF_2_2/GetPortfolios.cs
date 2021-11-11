using JsonEF_2_2;
using JsonEF_2_2.Controllers;
using JsonEF_2_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace XUnitJsonEF
{
    public class GetPortfolios
    {
        [Fact]
        public void Get_16000_Portfolios()
        {
            var connstring = "Server = localhost; Database = DB_Orm; Trusted_Connection = True;";
            var connection = new SqlConnection(connstring);
            var options = new DbContextOptionsBuilder<MyContext>().UseSqlServer(connection).Options;
            MyContext myContext = new MyContext(options);

            //arrange
            var portfolioController = new PortfolioController(myContext);

            //act
            var res= (Microsoft.AspNetCore.Mvc.ObjectResult)portfolioController.GetPortfolios();
            var list = (IEnumerable<portfolio>)res.Value;

            //assert
            Assert.True(res.StatusCode.Value == 200);
            Assert.True(list.ToList().Count == 20000);
        }
    }
}
