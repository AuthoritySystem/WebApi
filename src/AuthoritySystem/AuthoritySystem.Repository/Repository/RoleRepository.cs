using AuthoritySystem.EFCore.Context;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.Model.Dto.Response;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Repository.Base;
using System.Linq;
using System.Threading.Tasks;
using AuthoritySystem.Model.Enum;
using Microsoft.EntityFrameworkCore;

namespace AuthoritySystem.Repository.Repository
{
    public class RoleRepository : BaseRepository<TB_Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext dbContext)
       : base(dbContext, dbContext.Roles)
        {
        }

        public async Task<RoleResponseDto> GetPatgeListAsync(PagingRequest pagingRequest)
        {
            RoleResponseDto responseDto = new RoleResponseDto();
            var query = from r in _dbContext.Roles
                        where r.IsDeleted == (int)DeleteFlag.NotDeleted
                        select new RoleDto
                        {
                            ClusterID = r.ClusterID,
                            ID = r.ID,
                            CreateTime = r.CreateTime,
                            CreateUser = r.CreateUser,
                            UpdateTime = r.UpdateTime,
                            UpdateUser = r.UpdateUser,
                            RoleName = r.RoleName,
                            Description = r.Description,
                            IsDeleted = r.IsDeleted
                        };
            // 分页查询
            if (pagingRequest.IsPaging)
            {
                var skip = (pagingRequest.PageIndex - 1) * pagingRequest.PageSize;
                responseDto.ResponseData = await query.Skip(skip).Take(pagingRequest.PageSize).ToListAsync();
            }
            else
            {
                responseDto.ResponseData = await query.ToListAsync();
            }
            responseDto.Count = query.Count();
            return responseDto;
        }
    }
}
