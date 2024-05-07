using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace F2.EntityFramework.Core
{
    /// <summary>
    /// 配置连接字符串
    /// </summary>
    [AppDbContext("DefaultConnection", DbProvider.SqlServer)]
    public class FurionDbContext : AppDbContext<FurionDbContext>  // 继承 AppDbContext<> 类
    {
        /// <summary>
        /// 继承父类构造函数
        /// </summary>
        /// <param name="options"></param>
        public FurionDbContext(DbContextOptions<FurionDbContext> options) : base(options)
        {
        }
        
    }
    /// <summary>
    /// 数据库上下文注册
    /// </summary>
    [AppStartup(600)]
    public sealed class FurEntityFrameworkCoreStartup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<FurionDbContext>(DbProvider.SqlServer);
            });
        }
    }
}