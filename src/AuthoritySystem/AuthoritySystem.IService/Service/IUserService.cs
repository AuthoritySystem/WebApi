using AuthoritySystem.IService.Base;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using System.Threading.Tasks;

namespace AuthoritySystem.IService.Service
{
    public interface IUserService : IBaseService<TB_User>
    {
        Task<UserResponseDto> GetPatgeListAsync(PagingRequest pagingRequest);
    }
}
