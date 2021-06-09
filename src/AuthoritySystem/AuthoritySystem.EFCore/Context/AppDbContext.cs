using AuthoritySystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace AuthoritySystem.EFCore.Context
{
    /// <summary>
    /// 数据上下文类
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 通过构造函数给父类传参
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region DbSet属性
        public DbSet<TB_User> Users { get; set; }

        public DbSet<TB_Role> Roles { get; set; }

        public DbSet<TB_Department> Departments { get; set; }

        public DbSet<TB_Menu> Menus { get; set; }

        public DbSet<TB_RoleMenu> RoleMenus { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 动态添加应用配置类
            //将实现了IEntityTypeConfiguration<Entity>接口的模型配置类加入到modelBuilder中，进行注册
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            foreach (var type in typesToRegister)
            {
                // 创建实例
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            #endregion

            base.OnModelCreating(modelBuilder);

            #region 填充种子数据

            Guid guid = Guid.NewGuid();
            // 部门
            Guid deptGuid = Guid.NewGuid();
            // 角色ID
            Guid roleGuid = Guid.NewGuid();
            // 菜单ID
            Guid menuId = Guid.NewGuid();
            // 角色菜单
            Guid roleMenuId = Guid.NewGuid();

            // 填充部门数据
            modelBuilder.Entity<TB_Department>().HasData(new TB_Department()
            {
                ClusterID = 1,
                ID = deptGuid,
                CreateUser = "系统管理员",
                UpdateUser = "系统管理员",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                DepartmentName = "系统维护部"
            });

            // 填充角色数据
            modelBuilder.Entity<TB_Role>().HasData(new TB_Role()
            {
                ClusterID = 1,
                ID = roleGuid,
                CreateUser = "系统管理员",
                UpdateUser = "系统管理员",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                RoleName = "系统管理员"
            });

            // 填充用户数据
            modelBuilder.Entity<TB_User>().HasData(new TB_User()
            {
                ClusterID = 1,
                ID = guid,
                CreateUser = "系统管理员",
                UpdateUser = "系统管理员",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                LoginID = "admin",
                Password = "e10adc3949ba59abbe56e057f20f883e",
                Name = "系统管理员",
                DepartmentID = deptGuid,
                RoleID = roleGuid,
                Status = 0
            });
            // 填充角色菜单数据
            modelBuilder.Entity<TB_RoleMenu>().HasData(new TB_RoleMenu()
            {
                ClusterID = 1,
                ID = roleMenuId,
                CreateUser = "系统管理员",
                UpdateUser = "系统管理员",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                RoleID = roleGuid,
                MenuID = menuId
            });
            #endregion
        }
    }
}
