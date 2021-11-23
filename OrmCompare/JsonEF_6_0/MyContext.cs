using JsonEF_6_0.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonEF_6_0
{
    public class MyContext: DbContext
    {
        public DbSet<portfolio> portfolio { get; set; }


        public MyContext(DbContextOptions<MyContext> options): base(options)
        {}

    }
}
