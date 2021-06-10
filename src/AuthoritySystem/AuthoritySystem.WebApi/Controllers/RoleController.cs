using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.ApiModel;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Controllers
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetList")]
        public async Task<ActionResult<ApiResponseWithData<List<RoleDto>>>> GetList([FromBody] PagingRequest pagingRequest)
        {
            ApiResponseWithData<List<RoleDto>> result = new ApiResponseWithData<List<RoleDto>>();
            RoleResponseDto dto = await _service.GetPatgeListAsync(pagingRequest);
            if (dto != null)
            {
                result.Code =(int)CustomerCode.Success;
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

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] TB_Role entity)
        {
            ApiResponse result = new ApiResponse();
            ValidateResult validateResult = await _service.AddAsync(entity);
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

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Put([FromBody] TB_Role entity)
        {
            ApiResponse result = new ApiResponse();
            ValidateResult validateResult = await _service.UpdateAsync(entity);
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


        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            ApiResponse result = new ApiResponse();
            ValidateResult validateResult = await _service.DeleteAsync(id);
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
