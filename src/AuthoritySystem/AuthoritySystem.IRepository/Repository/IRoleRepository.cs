using AuthoritySystem.IRepository.Base;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using System.Threading.Tasks;

namespace AuthoritySystem.IRepository.Repository
{
    public interface IRoleRepository : IBaseRepository<TB_Role>
    {
        Task<RoleResponseDto> GetPatgeListAsync(PagingRequest pagingRequest);
    }
}
