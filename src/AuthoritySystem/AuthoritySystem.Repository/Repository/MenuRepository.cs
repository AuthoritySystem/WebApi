using AuthoritySystem.EFCore.Context;
using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.Model.Entity;
using AuthoritySystem.Repository.Base;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AuthoritySystem.Repository.Repository
{
    public class MenuRepository : BaseRepository<TB_Menu>, IMenuRepository
    {
        public MenuRepository(AppDbContext dbContext)
     : base(dbContext, dbContext.Menus)
        {
        }

        public async Task<List<TB_Menu>> GetListAsync()
        {
            var query = from m in _dbContext.Menus
                        select new TB_Menu
                        {
                            ClusterID = m.ClusterID,
                            ID = m.ID,
                            CreateTime = m.CreateTime,
                            CreateUser = m.CreateUser,
                            UpdateTime = m.UpdateTime,
                            UpdateUser = m.UpdateUser,
                            ClassName = m.ClassName,
                            MenuName = m.MenuName,
                            ParentID = m.ParentID,
                            Url = m.Url,
                            NameSpace = m.NameSpace,
                            IsDeleted = m.IsDeleted,
                            Description = m.Description
                        };
            return await query.ToListAsync();
        }
    }
}
