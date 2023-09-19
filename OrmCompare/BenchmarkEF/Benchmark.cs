using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkEF6
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _connectionstring;
        private DbContextOptions<JsonEF_6_0.MyContext> _contextOptions;

        [GlobalSetup]
        public void Init()
        {
            _connectionstring = "Server=localhost;Database=DB_Orm;Trusted_Connection=True;";
            _contextOptions = new DbContextOptionsBuilder<JsonEF_6_0.MyContext>().UseSqlServer(_connectionstring).Options;
        }

        [Benchmark]
        public void EF6_GetSingle()
        {
            var context = new JsonEF_6_0.MyContext(_contextOptions);
            _ = context.portfolio.FirstOrDefault();
        }

        [Benchmark]
        public void EF6_GetList()
        {
            var context = new JsonEF_6_0.MyContext(_contextOptions);
            _ = context.portfolio.ToList();
        }
    }
}
