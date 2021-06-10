using AuthoritySystem.IRepository.Base;
using AuthoritySystem.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthoritySystem.IRepository.Repository
{
    public interface IMenuRepository : IBaseRepository<TB_Menu>
    {
        Task<List<TB_Menu>> GetListAsync();
    }
}
