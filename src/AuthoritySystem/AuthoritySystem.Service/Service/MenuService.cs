﻿using AuthoritySystem.EFCore.Uow;
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
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IMenuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<ValidateResult> AddAsync(TB_Menu entity)
        {
            ValidateResult validateResult = new ValidateResult();
            entity.CreateUser = entity.UpdateUser = "admin";

            // 保存数据
            _repository.Add(entity);
            // 保存数据
            int rows = await _unitOfWork.SaveChangesAsync();
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

            Expression<Func<TB_Menu, object>>[] updatedProperties =
            {
                p=>p.IsDeleted,
                p=>p.UpdateTime,
                p=>p.UpdateUser
            };

            _repository.Update(entity, updatedProperties);
            int rows = await _unitOfWork.SaveChangesAsync();
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

        public async Task<IEnumerable<TB_Menu>> GetAllListAsync(Expression<Func<TB_Menu, bool>> predicate)
        {
            return await _repository.GetAllListAsync(predicate);
        }

        public async Task<TB_Menu> GetEntityAsync(Expression<Func<TB_Menu, bool>> predicate)
        {
            return await _repository.GetEntityAsync(predicate);
        }

        public async Task<ValidateResult> UpdateAsync(TB_Menu entity)
        {
            ValidateResult validateResult = new ValidateResult();
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUser = "admin";

            Expression<Func<TB_Menu, object>>[] updatedProperties =
            {
                p=>p.UpdateTime,
                p=>p.UpdateUser
            };

            // 保存数据
            _repository.Update(entity, updatedProperties);
            int rows = await _unitOfWork.SaveChangesAsync();
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
