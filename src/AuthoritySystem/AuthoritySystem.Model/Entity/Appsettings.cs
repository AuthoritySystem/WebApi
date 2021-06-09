using Microsoft.Extensions.Configuration;
using System.Threading;

namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 全局配置类，单例模式
    /// </summary>
    public class Appsettings
    {
        private static Appsettings single;

        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static Appsettings Instance()
        {
            if (single != null)
                return single;
            Appsettings temp = new Appsettings();
            Interlocked.CompareExchange(ref single, temp, null);

            return single;
        }


        #region 属性

        /// <summary>
        ///  数据库配置类
        /// </summary>
        public DbConfig DbConfig { get; set; }

        #endregion

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        /// <param name="configuration"></param>
        public void Initaial(IConfiguration configuration)
        {
            // 默认配置
            DbConfig = new DbConfig()
            {
                DbType = "PostgreSQL",
                DbConnection = "User ID=postgres;Password=1qaz@WSX;Host=10.10.10.201;Port=5432;Database=AuthoritySystem;Pooling=true;"
            };
            // 绑定
            configuration.GetSection("DbConfig").Bind(DbConfig);
        }
    }
}
