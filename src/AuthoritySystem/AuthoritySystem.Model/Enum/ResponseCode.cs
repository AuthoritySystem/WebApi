using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoritySystem.Model.Enum
{
    /// <summary>
    /// 统一返回可是Code描述
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 失败，服务器错误
        /// </summary>
        ServerError = 1,

        /// <summary>
        /// 失败，接口返回失败
        /// </summary>
        ActionError = 2,

        /// <summary>
        /// 请求已提交，请勿重复提交
        /// </summary>
        NotRequestAgain = 998,

        /// <summary>
        /// 操作超时
        /// </summary>
        Timeout = 997,

        /// <summary>
        /// 请重新登录
        /// </summary>
        Relogin = 999,
    }
}
