using AuthoritySystem.EFCore.Context;
using AuthoritySystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthoritySystem.WebApi.Builder
{
    public class CoreServiceBuilder : ICoreServiceBuilder
    {
        private readonly IServiceCollection _services;

        public CoreServiceBuilder(IServiceCollection service)
        {
            _services = service;
        }

        /// <summary>
        /// 添加数据库连接
        /// </summary>
        public void AddDbConfig()
        {
            // 获取数据库配置
            DbConfig dbConfig = Appsettings.Instance().DbConfig;
            switch (dbConfig.DbType)
            {
                case "PostgreSQL":
                    _services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseNpgsql(dbConfig.DbConnection).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    }, ServiceLifetime.Scoped);
                    break;
            }
        }
    }
}
