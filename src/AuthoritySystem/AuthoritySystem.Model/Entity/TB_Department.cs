using AuthoritySystem.Model.Entity.Base;
using System;

namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 部门实体
    /// </summary>
    public class TB_Department  : BaseEntity
    {
        /// <summary>
        /// 上级部门ID
        /// </summary>
        public Guid? ParentID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
