using AuthoritySystem.IRepository.Base;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using System.Threading.Tasks;

namespace AuthoritySystem.IRepository.Repository
{
    public interface IUserRepository : IBaseRepository<TB_User>
    {
        Task<UserResponseDto> GetPatgeListAsync(PagingRequest pagingRequest);
    }
}
