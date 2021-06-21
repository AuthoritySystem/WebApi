using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoritySystem.Model.Dto.Request
{
    /// <summary>
    /// 登录请求
    /// </summary>
    public class LoginRequestDto
    {
        /// <summary>
        /// 登录ID
        /// </summary>
        public string LoginID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
