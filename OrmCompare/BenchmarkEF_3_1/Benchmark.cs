using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BenchmarkEF_3_1
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _connectionstring;
        private DbContextOptions<JsonEF_3_1.MyContext> _contextOptions;

        [GlobalSetup]
        public void Init()
        {
            _connectionstring = "Server=localhost;Database=DB_Orm;Trusted_Connection=True;";
            _contextOptions = new DbContextOptionsBuilder<JsonEF_3_1.MyContext>().UseSqlServer(_connectionstring).Options;
        }

        [Benchmark]
        public void EF3_1_GetSingle()
        {
            var context = new JsonEF_3_1.MyContext(_contextOptions);
            _ = context.portfolio.FirstOrDefault();
        }

        [Benchmark]
        public void EF3_1_GetList()
        {
            var context = new JsonEF_3_1.MyContext(_contextOptions);
            _ = context.portfolio.ToList();
        }
    }
}
