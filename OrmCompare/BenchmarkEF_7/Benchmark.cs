using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkEF7
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _connectionstring;
        private DbContextOptions<JsonEF_7_0.MyContext> _contextOptions;

        [GlobalSetup]
        public void Init()
        {
            _connectionstring = "Server=localhost;Database=DB_Orm;Trusted_Connection=True;TrustServerCertificate=True";
            _contextOptions = new DbContextOptionsBuilder<JsonEF_7_0.MyContext>().UseSqlServer(_connectionstring).Options;
        }

        [Benchmark]
        public void EF7_GetSingle()
        {
            var context = new JsonEF_7_0.MyContext(_contextOptions);
            _ = context.portfolio.FirstOrDefault();
        }

        [Benchmark]
        public void EF7_GetList()
        {
            var context = new JsonEF_7_0.MyContext(_contextOptions);
            _ = context.portfolio.ToList();
        }
    }
}
