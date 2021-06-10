using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.ApiModel;
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
    [Route("api/RoleMenu")]
    [ApiController]
    public class RoleMenuController : ControllerBase
    {
        private readonly IRoleMenuService _service;

        public RoleMenuController(IRoleMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<ApiResponseWithData<List<TB_RoleMenu>>>> GetList(Guid id)
        {
            ApiResponseWithData<List<TB_RoleMenu>> result = new ApiResponseWithData<List<TB_RoleMenu>>();
            IEnumerable<TB_RoleMenu> dto = await _service.GetAllListAsync(p => p.RoleID == id);
            if (dto != null)
            {
                result.Code = (int)CustomerCode.Success;
                result.Msg = EnumHelper.GetEnumDesc(CustomerCode.Success);
                result.Data = dto.ToList();
                result.Count = dto.Count();
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
                result.Msg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] TB_RoleMenu entity)
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
        public async Task<ActionResult<ApiResponse>> Put([FromBody] TB_RoleMenu entity)
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
