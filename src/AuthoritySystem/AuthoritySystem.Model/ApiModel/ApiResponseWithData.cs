using AuthoritySystem.Model.Enum;

namespace AuthoritySystem.Model.ApiModel
{
    public class ApiResponseWithData<T> : ApiResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 数据总量
        /// </summary>
        public int Count { get; set; }

        public new static ApiResponseWithData<T> Success()
        {
            return new ApiResponseWithData<T>()
            {
                Code = (int)ResponseCode.Success,
                Msg = "成功"
            };
        }
        public new ApiResponseWithData<T> ActionError(string msg, ResponseCode? code = null)
        {
            base.ActionError(msg, code);
            return this;
        }
        public new ApiResponseWithData<T> ActionError(string msg, int code)
        {
            base.ActionError(msg, code);
            return this;
        }
    }
}
