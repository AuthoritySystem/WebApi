using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthoritySystem.Service.Service
{
    public class RoleMenuService : IRoleMenuService
    {
        private readonly IRoleMenuRepository _repository;

        public RoleMenuService(IRoleMenuRepository repository)
        {
            _repository = repository;
        }


        public async Task<ValidateResult> AddAsync(TB_RoleMenu entity)
        {
            ValidateResult validateResult = new ValidateResult();
            entity.CreateUser = entity.UpdateUser = "admin";
            // 保存数据
            int rows = await _repository.AddAsync(entity);
            if (rows > 0)
            {
                validateResult.ValidateCode = (int)CustomerCode.Success;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Success);
            }
            else
            {
                validateResult.ValidateCode = (int)CustomerCode.Fail;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
            }
            return validateResult;
        }

        public async Task<ValidateResult> DeleteAsync(Guid id)
        {
            ValidateResult validateResult = new ValidateResult();
            // 根据ID获取数据
            var entity = await _repository.GetEntityAsync(p => p.ID == id);
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUser = "admin";
            entity.IsDeleted = (int)DeleteFlag.Deleted;

            Expression<Func<TB_RoleMenu, object>>[] updatedProperties =
            {
                p=>p.IsDeleted,
                p=>p.UpdateTime,
                p=>p.UpdateUser
            };

            int rows = await _repository.UpdateAsync(entity, updatedProperties);
            if (rows > 0)
            {
                validateResult.ValidateCode = (int)CustomerCode.Success;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Success);
            }
            else
            {
                validateResult.ValidateCode = (int)CustomerCode.Fail;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
            }
            return validateResult;
        }

        public async Task<IEnumerable<TB_RoleMenu>> GetAllListAsync(Expression<Func<TB_RoleMenu, bool>> predicate)
        {
            return await _repository.GetAllListAsync(predicate);
        }

        public async Task<TB_RoleMenu> GetEntityAsync(Expression<Func<TB_RoleMenu, bool>> predicate)
        {
            return await _repository.GetEntityAsync(predicate);
        }

        public async Task<ValidateResult> UpdateAsync(TB_RoleMenu entity)
        {
            ValidateResult validateResult = new ValidateResult();
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUser = "admin";

            Expression<Func<TB_RoleMenu, object>>[] updatedProperties =
            {
                p=>p.UpdateTime,
                p=>p.UpdateUser
            };
            // 保存数据
            int rows = await _repository.UpdateAsync(entity, updatedProperties);
            if (rows > 0)
            {
                validateResult.ValidateCode = (int)CustomerCode.Success;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Success);
            }
            else
            {
                validateResult.ValidateCode = (int)CustomerCode.Fail;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
            }
            return validateResult;
        }
    }
}
