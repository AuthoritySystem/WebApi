using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.ApiModel;
using AuthoritySystem.Model.Dto.Request;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
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
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
            }
            return result;
        }
    }
}
