using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkEF8
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _connectionstring;
        private DbContextOptions<JsonEF_8_0.MyContext> _contextOptions;

        [GlobalSetup]
        public void Init()
        {
            _connectionstring = "Server=localhost;Database=DB_Orm;Trusted_Connection=True;TrustServerCertificate=True";
            _contextOptions = new DbContextOptionsBuilder<JsonEF_8_0.MyContext>().UseSqlServer(_connectionstring).Options;
        }

        [Benchmark]
        public void EF8_GetSingle()
        {
            var context = new JsonEF_8_0.MyContext(_contextOptions);
            _ = context.portfolio.FirstOrDefault();
        }

        [Benchmark]
        public void EF8_GetList()
        {
            var context = new JsonEF_8_0.MyContext(_contextOptions);
            _ = context.portfolio.ToList();
        }
    }
}
