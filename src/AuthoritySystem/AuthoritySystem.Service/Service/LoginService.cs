using AuthoritySystem.Framework.CommonHelper;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.IService.Service;
using AuthoritySystem.Model.Dto.Request;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthoritySystem.Service.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResult> IsExist(LoginRequestDto loginRequestDto)
        {
            LoginResult result = new LoginResult();
            string loginId = loginRequestDto.LoginID.Trim();
            // MD5加密
            string password = MD5Helper.Get32LowerMD5(loginRequestDto.Password).Trim();
            // 数据库查询是否有该用户
            TB_User user = await _userRepository.GetEntityAsync(p => p.LoginID == loginId && p.Password == password);
            if (null != user)
            {
                // 判断用户当前状态
                switch ((UserStatus)user.Status)
                {
                    // 用户被冻结
                    case UserStatus.Forzen:
                        result.LoginStatus = LoginStatus.UserForzen;
                        break;
                    case UserStatus.Cancle:
                        result.LoginStatus = LoginStatus.UserCancle;
                        break;
                    default:
                        result.LoginStatus = LoginStatus.Success;
                        break;
                }
            }
            else
            {
                result.LoginStatus = LoginStatus.Error;
            }

            return result;
        }
    }
}
