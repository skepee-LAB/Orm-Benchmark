using JsonEF_2_1.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonEF_2_1
{
    public class MyContext: DbContext
    {
        public DbSet<portfolio> portfolio { get; set; }




        public MyContext(DbContextOptions<MyContext> options): base(options)
        {}

    }
}
