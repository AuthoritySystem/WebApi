using AuthoritySystem.Model.Dto.Request;
using AuthoritySystem.Model.Entity;
using System.Threading.Tasks;

namespace AuthoritySystem.IService.Service
{
    public interface ILoginService
    {
        Task<LoginResult> IsExist(LoginRequestDto loginRequestDto);
    }
}
