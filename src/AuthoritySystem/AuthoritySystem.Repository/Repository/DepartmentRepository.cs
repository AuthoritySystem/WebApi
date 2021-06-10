using AuthoritySystem.EFCore.Context;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Repository.Base;
using System.Linq;
using System.Threading.Tasks;
using AuthoritySystem.Model.Enum;
using AuthoritySystem.Model.Dto.Response;
using Microsoft.EntityFrameworkCore;

namespace AuthoritySystem.Repository.Repository
{
    public class DepartmentRepository : BaseRepository<TB_Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext)
     : base(dbContext, dbContext.Departments)
        {
        }

        public async Task<DepartmentResponseDto> GetPatgeListAsync(bool isPaging, PagingRequest pagingRequest)
        {
            DepartmentResponseDto responseDto = new DepartmentResponseDto();
            var query = from r in _dbContext.Departments
                        where r.IsDeleted == (int)DeleteFlag.NotDeleted
                        select new TB_Department
                        {
                            ClusterID = r.ClusterID,
                            ID = r.ID,
                            CreateTime = r.CreateTime,
                            CreateUser = r.CreateUser,
                            UpdateTime = r.UpdateTime,
                            UpdateUser = r.UpdateUser,
                            DepartmentName = r.DepartmentName,
                            Description = r.Description,
                            IsDeleted = r.IsDeleted
                        };
            // 分页查询
            if (isPaging)
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
