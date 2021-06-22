using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class CustomerGlobalExceptionFilterAsync : IAsyncExceptionFilter
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<CustomerGlobalExceptionFilterAsync> _logger;

        public CustomerGlobalExceptionFilterAsync(ILogger<CustomerGlobalExceptionFilterAsync> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            // 如果异常没有被处理，则进行处理
            if (context.ExceptionHandled == false)
            {

                // 使用Serilog记录错误信息
                _logger.LogError(exception: context.Exception, "Exception");
                // 设置为true，表示异常已经被处理了，其它捕获异常的地方就不会再处理了
                context.ExceptionHandled = true;
            }

            return Task.CompletedTask;
        }
    }
}
