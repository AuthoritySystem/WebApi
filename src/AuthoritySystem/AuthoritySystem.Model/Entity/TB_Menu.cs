using AuthoritySystem.Model.Entity.Base;
using System;

namespace AuthoritySystem.Model.Entity
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    public class TB_Menu  : BaseEntity
    {
        /// <summary>
        /// 父级菜单ID
        /// </summary>
        public Guid? ParentID { get; set; }

        /// <summary>
        /// 对应的dll文件
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
    }
}
