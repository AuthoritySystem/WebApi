namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DbConfig
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DbConnection { get; set; }
    }
}
