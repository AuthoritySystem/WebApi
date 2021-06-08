using AuthoritySystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthoritySystem.EFCore.Config
{
    /// <summary>
    /// User实体类的配置信息 继承自IEntityTypeConfiguration接口
    /// </summary>
    public class TB_UserMap : IEntityTypeConfiguration<TB_User>
    {
        public void Configure(EntityTypeBuilder<TB_User> builder)
        {
            // 配置生成的表名
            builder.ToTable("TB_User");
            // 设置表注释
            builder.HasComment("用户表");
            // 配置主键
            builder.HasKey(p => p.ClusterID);
            // 设置主键自增
            builder.Property(p => p.ClusterID).ValueGeneratedOnAdd();

            builder.Property(p => p.ID).IsRequired();
            // 配置账户最大长度为32，并且不能为空
            builder.Property(p => p.LoginID).HasMaxLength(32).IsRequired().HasComment("用户账号");
            // 配置密码最大长度为32，并且不能为空
            builder.Property(p => p.Password).HasMaxLength(32).IsRequired().HasComment("密码");
            // 配置姓名最大长度为32，并且不能为空
            builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasComment("姓名");
            builder.Property(p => p.MobileNumber).HasMaxLength(16).HasComment("手机号码");
            builder.Property(p => p.EmailAddress).HasMaxLength(128).HasComment("邮箱地址");
            builder.Property(p => p.Description).HasComment("备注信息");
            builder.Property(p => p.Position).HasMaxLength(64).HasComment("职务");
            builder.Property(p => p.DepartmentID).HasComment("部门ID");
            builder.Property(p => p.RoleID).HasComment("角色ID");
            builder.Property(p => p.CreateUser).HasMaxLength(32).IsRequired().HasComment("创建用户");
            builder.Property(p => p.UpdateUser).HasMaxLength(32).IsRequired().HasComment("更新用户");
            builder.Property(p => p.LoginErrorCount).HasComment("错误登录次数");

            // 配置CreatedTime列的类型
            builder.Property(p => p.CreateTime).HasColumnType("datetime").HasDefaultValueSql("GETDATE()").HasComment("创建时间");
            // 配置UpdatedTime列为计算列
            builder.Property(p => p.UpdateTime).HasColumnType("datetime").HasDefaultValueSql("GETDATE()").HasComment("更新时间");
            // 设置状态默认值
            builder.Property(p => p.Status).HasDefaultValue<int>(0).HasComment("用户状态 0：正常 1 冻结 2：注销 默认0");
            // 设置是否删除默认值
            builder.Property(p => p.IsDeleted).HasDefaultValue<int>(0).HasComment("是否删除 0：未删除 1：删除");
        }
    }
}
