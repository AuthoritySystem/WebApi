using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthoritySystem.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ValidateResult> AddAsync(TB_User entity)
        {
            ValidateResult validateResult = new ValidateResult();
            // 判断是否已经存在要新增的用户
            TB_User user = await _userRepository.GetEntityAsync(p => p.LoginID == entity.LoginID && p.IsDeleted == (int)DeleteFlag.NotDeleted && p.Status == (int)UserStatus.Normal);
            if (user != null)
            {
                validateResult.ValidateCode = (int)CustomerCode.UserIsExist;
                validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.UserIsExist);
            }
            else
            {
                entity.CreateUser = entity.UpdateUser = "admin";
                entity.Password = MD5Helper.Get32LowerMD5(entity.Password);
                entity.LoginErrorCount = 0;
                // 保存数据
                int count = await _userRepository.AddAsync(entity);
                if (count > 0)
                {
                    validateResult.ValidateCode = (int)CustomerCode.Success;
                    validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Success);
                }
                else
                {
                    validateResult.ValidateCode = (int)CustomerCode.Fail;
                    validateResult.ValidateMsg = EnumHelper.GetEnumDesc(CustomerCode.Fail);
                }
            }

            return validateResult;
        }

        public async Task<ValidateResult> DeleteAsync(Guid id)
        {
            ValidateResult validateResult = new ValidateResult();
            var user = await _userRepository.GetEntityAsync(p => p.ID == id);
            // 
            user.IsDeleted = (int)DeleteFlag.Deleted;
            user.UpdateTime = DateTime.Now;
            user.UpdateUser = "admin";

            Expression<Func<TB_User, object>>[] updatedProperties =
            {
               p=>p.Password,
               p=>p.UpdateUser,
               p=>p.UpdateTime
            };
            // 保存数据
            int count = await _userRepository.UpdateAsync(user, updatedProperties);
            if (count > 0)
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

        public Task<IEnumerable<TB_User>> GetAllListAsync(Expression<Func<TB_User, bool>> predicate)
        {
            return _userRepository.GetAllListAsync(predicate);
        }

        public Task<TB_User> GetEntityAsync(Expression<Func<TB_User, bool>> predicate)
        {
            return _userRepository.GetEntityAsync(predicate);
        }

        public async Task<UserResponseDto> GetPatgeListAsync(PagingRequest pagingRequest)
        {
            return await _userRepository.GetPatgeListAsync(pagingRequest);
        }

        public async Task<ValidateResult> UpdateAsync(TB_User entity)
        {
            ValidateResult validateResult = new ValidateResult();
            var user = await _userRepository.GetEntityAsync(p => p.ID == entity.ID);
            user.Name = entity.Name;
            user.MobileNumber = entity.MobileNumber;
            user.Description = entity.Description;
            user.EmailAddress = entity.EmailAddress;
            user.DepartmentID = entity.DepartmentID;
            user.RoleID = entity.RoleID;
            user.UpdateTime = DateTime.Now;
            user.UpdateUser = "admin";
            // 用表达式树，更新部分字段
            Expression<Func<TB_User, object>>[] updatedProperties =
            {
               p=>p.Name,
               p=>p.MobileNumber,
               p=>p.Description,
               p=>p.EmailAddress,
               p=>p.Position,
               p=>p.DepartmentID,
               p=>p.RoleID,
               p=>p.Status,
               p=>p.UpdateUser,
               p=>p.UpdateTime
            };

            // 保存数据
            int count = await _userRepository.UpdateAsync(user, updatedProperties);
            if (count > 0)
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
