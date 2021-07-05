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
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Controllers
{
    [Route("api/Menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseWithData<List<TB_Menu>>>> Get()
        {
            ApiResponseWithData<List<TB_Menu>> result = new ApiResponseWithData<List<TB_Menu>>();
            Expression<Func<TB_Menu, bool>> func = p => p.IsDeleted == (int)DeleteFlag.NotDeleted;
            var list = await _service.GetAllListAsync(func);
            if(null != list)
            {
                result.Code = (int)CustomerCode.Success;
                result.Msg = EnumHelper.GetEnumDesc(CustomerCode.Success);
                result.Data = list.ToList();
                result.Count = list.Count();
            }
            else
            {
                result.Code = (int)CustomerCode.Fail;
                result.Msg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] TB_Menu entity)
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
        public async Task<ActionResult<ApiResponse>> Put([FromBody] TB_Menu entity)
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
