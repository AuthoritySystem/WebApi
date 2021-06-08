using AuthoritySystem.Model.Entity.Base;

namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class TB_Role : BaseEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
    }
}
