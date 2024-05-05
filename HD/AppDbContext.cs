using Data;
using Microsoft.EntityFrameworkCore;

namespace HD
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; } // DbSet代表数据库中的表
    }
}
