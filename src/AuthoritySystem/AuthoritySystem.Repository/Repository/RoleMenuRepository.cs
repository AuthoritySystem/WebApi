using AuthoritySystem.EFCore.Context;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Repository.Base;

namespace AuthoritySystem.Repository.Repository
{
    public class RoleMenuRepository : BaseRepository<TB_RoleMenu>, IRoleMenuRepository
    {
        public RoleMenuRepository(AppDbContext dbContext)
     : base(dbContext, dbContext.RoleMenus)
        {
        }
    }
}
