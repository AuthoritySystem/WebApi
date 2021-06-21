using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AuthoritySystem.Model.Enum
{
    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginStatus
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        [Description("登录成功")]
        Success = 1,

        /// <summary>
        /// 登录失败,用户名或密码错误
        /// </summary>
        [Description("登录失败,用户名或密码错误")]
        Error = 2,

        /// <summary>
        /// 退出成功
        /// </summary>
        [Description("退出成功")]
        LoginOut = 3,

        /// <summary>
        /// 登录失败,该用户已被冻结
        /// </summary>
        [Description("登录失败,该用户已被冻结")]
        UserForzen = 4,

        /// <summary>
        /// 登录失败,该用户已被注销
        /// </summary>
        [Description("登录失败,该用户已被注销")]
        UserCancle = 5
    }
}
