using AuthoritySystem.EFCore.Context;
using AuthoritySystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AuthoritySystem.Framework.Extensions;
using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.EFCore.Uow;

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
        /// 批量注入服务
        /// </summary>
        public void AddAssembly()
        {
            _services.RegisterService(ServiceLifetime.Scoped, new string[] { "AuthoritySystem.Service", "AuthoritySystem.Repository" });
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

        public void AddOther()
        {
            #region 解决返回时间带T的问题
            _services.AddControllers().AddJsonOptions(configure =>
            {
                configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverterHelper());
            });
            #endregion

            #region 设置返回的json首字母都是大写
            _services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            #endregion

            _services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
        }
    }
}
