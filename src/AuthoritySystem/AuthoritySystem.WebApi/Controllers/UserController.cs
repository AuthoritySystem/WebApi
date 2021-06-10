using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.ApiModel;
using AuthoritySystem.Model.Dto.Request;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="searchRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getlist")]
        public async Task<ActionResult<ApiResponseWithData<List<UserDto>>>> Getlist([FromBody] UserRequestDto requestDto)
        {
            ApiResponseWithData<List<UserDto>> result = new ApiResponseWithData<List<UserDto>>();
            UserResponseDto dto = await _userService.GetPatgeListAsync(requestDto);
            if (dto != null)
            {
                result.Code = (int)CustomerCode.Success;
                result.Msg = EnumHelper.GetEnumDesc(CustomerCode.Success);
                result.Data = dto.ResponseData;
                result.Count = dto.Count;
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
                result.Msg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
            }
            return result;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] TB_User user)
        {
            ApiResponse result = new ApiResponse();
            ValidateResult validateResult = await _userService.AddAsync(user);
            if (validateResult.ValidateCode > 0)
            {
                result.Code = (int)CustomerCode.Success;
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
            }
            result.Msg = validateResult.ValidateMsg;
            return result;
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Put([FromBody] TB_User user)
        {
            ApiResponse result = new ApiResponse();
            ValidateResult validateResult = await _userService.UpdateAsync(user);
            if (validateResult.ValidateCode > 0)
            {
                result.Code = (int)CustomerCode.Success;
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
            }
            result.Msg = validateResult.ValidateMsg;
            return result;
        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            ApiResponse result = new ApiResponse();
            ValidateResult validateResult = await _userService.DeleteAsync(id);
            if (validateResult.ValidateCode > 0)
            {
                result.Code = (int)CustomerCode.Success;
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
            }
            result.Msg = validateResult.ValidateMsg;
            return result;
        }
    }
}
