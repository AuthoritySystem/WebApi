using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Builder
{
    public interface ICoreServiceBuilder
    {
        /// <summary>
        /// 添加数据库连接配置
        /// </summary>
        void AddDbConfig();

        void AddAssembly();

        void AddOther();
    }
}
