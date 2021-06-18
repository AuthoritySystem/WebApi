using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.ApiModel;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthoritySystem.WebApi.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("GetList")]
        public async Task<ActionResult<ApiResponseWithData<List<TB_Department>>>> GetList([FromBody] PagingRequest pagingRequest)
        {
            ApiResponseWithData<List<TB_Department>> result = new ApiResponseWithData<List<TB_Department>>();
            IEnumerable<TB_Department> dto = await _service.GetAllListAsync(null);
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
        public async Task<ActionResult<ApiResponse>> Post([FromBody] TB_Department entity)
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
        public async Task<ActionResult<ApiResponse>> Put([FromBody] TB_Department entity)
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
