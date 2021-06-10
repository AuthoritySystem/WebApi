using AuthoritySystem.Model.Enum;

namespace AuthoritySystem.Model.ApiModel
{
    /// <summary>
    /// 接口统一返回格式
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回内容
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        public static ApiResponse Success()
        {
            return new ApiResponse()
            {
                Code = (int)ResponseCode.Success,
                Msg = "成功"
            };
        }

        public ApiResponse ActionError(string msg, ResponseCode? code = null)
        {
            Code = code.HasValue ? (int)code.Value : (int)ResponseCode.ActionError;
            Msg = msg;
            return this;
        }

        public ApiResponse ActionError(string msg, int code)
        {
            Code = code;
            Msg = msg;
            return this;
        }
    }
}
