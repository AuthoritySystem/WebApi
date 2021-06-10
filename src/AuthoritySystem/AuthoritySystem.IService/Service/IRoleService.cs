using AuthoritySystem.IService.Base;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using System.Threading.Tasks;

namespace AuthoritySystem.IService.Service
{
    public interface IRoleService : IBaseService<TB_Role>
    {
        Task<RoleResponseDto> GetPatgeListAsync(PagingRequest pagingRequest);
    }
}
