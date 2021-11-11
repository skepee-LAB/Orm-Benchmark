using JsonEF_2_2.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonEF_2_2
{
    public class MyContext: DbContext
    {
        public DbSet<portfolio> Portfolio { get; set; }


        public MyContext(DbContextOptions<MyContext> options): base(options)
        {}

    }
}
