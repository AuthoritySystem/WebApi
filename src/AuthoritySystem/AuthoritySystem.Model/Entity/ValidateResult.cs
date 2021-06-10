using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 服务端处理返回结果
    /// </summary>
    public class ValidateResult
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int ValidateCode { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public string ValidateMsg { get; set; }
    }
}
