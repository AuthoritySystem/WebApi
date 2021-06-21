using AuthoritySystem.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 登录验证结果
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// 枚举
        /// </summary>
        public LoginStatus LoginStatus { get; set; }
    }
}
