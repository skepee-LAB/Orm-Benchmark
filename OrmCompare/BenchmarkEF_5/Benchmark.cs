using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BenchmarkEF5
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _connectionstring;
        private DbContextOptions<JsonEF_5_0.MyContext> _contextOptions;

        [GlobalSetup]
        public void Init()
        {
            _connectionstring = "Server=localhost;Database=DB_Orm;Trusted_Connection=True;";
            _contextOptions = new DbContextOptionsBuilder<JsonEF_5_0.MyContext>().UseSqlServer(_connectionstring).Options;
        }

        [Benchmark]
        public void EF5_GetSingle()
        {
            var context = new JsonEF_5_0.MyContext(_contextOptions);
            _ = context.portfolio.FirstOrDefault();
        }

        [Benchmark]
        public void EF5_GetList()
        {
            var context = new JsonEF_5_0.MyContext(_contextOptions);
            _ = context.portfolio.ToList();
        }
    }
}
