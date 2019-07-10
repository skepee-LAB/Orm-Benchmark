using JsonEF.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonEF
{
    public class MyContext: DbContext
    {
        public DbSet<tbl_pm01_portfolio> tbl_pm01_portfolio { get; set; }


        public MyContext(DbContextOptions<MyContext> options): base(options)
        {}

    }
}
