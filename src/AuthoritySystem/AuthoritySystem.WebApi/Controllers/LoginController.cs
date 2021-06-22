using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.ApiModel;
using AuthoritySystem.Model.Dto.Request;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        // 使用Serilog
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] LoginRequestDto request)
        {
            ApiResponse result = new ApiResponse();
            LoginResult loginResult = await _loginService.IsExist(request);
            int value = (int)loginResult.LoginStatus;
            // 获取描述信息
            result.Msg = EnumHelper.GetEnumDesc(loginResult.LoginStatus);
            if (value == 1)
            {
                result.Code = (int)CustomerCode.Success;
                // 登录成功，记录日志
                _logger.LogInformation("登录成功");
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
            }
            return result;
        }
    }
}
