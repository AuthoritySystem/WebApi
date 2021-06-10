using AuthoritySystem.WebApi.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthoritySystem.WebApi.Extensions
{
    public static class CoreBuilderExtensions
    {
        /// <summary>
        /// 注册服务到依赖注入容器
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">配置信息</param>
        public static void AddCoreServiceProvider(this IServiceCollection services, IConfiguration configuration)
        {
            // 实例化
            ICoreServiceBuilder servicebuilder = new CoreServiceBuilder(services);
            // 添加数据库
            servicebuilder.AddDbConfig();
            // 依赖注入
            servicebuilder.AddAssembly();
            servicebuilder.AddOther();
        }
    }
}
