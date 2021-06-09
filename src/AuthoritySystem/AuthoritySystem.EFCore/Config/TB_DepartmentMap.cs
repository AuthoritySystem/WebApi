﻿using AuthoritySystem.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoritySystem.EFCore.Config
{
    public class TB_DepartmentMap : IEntityTypeConfiguration<TB_Department>
    {
        public void Configure(EntityTypeBuilder<TB_Department> builder)
        {
            // 配置生成的表名
            builder.ToTable("TB_Department");
            // 设置表注释
            builder.HasComment("部门表");
            // 配置主键
            builder.HasKey(p => p.ClusterID);
            // 设置主键自增
            builder.Property(p => p.ClusterID).ValueGeneratedOnAdd();

            builder.Property(p => p.ID).IsRequired();
            builder.Property(p => p.CreateUser).HasMaxLength(32).IsRequired().HasComment("创建用户");
            builder.Property(p => p.UpdateUser).HasMaxLength(32).IsRequired().HasComment("更新用户");
            // 配置CreatedTime列的类型
            builder.Property(p => p.CreateTime).IsRequired().HasComment("创建时间");
            // 配置UpdatedTime列为计算列
            builder.Property(p => p.UpdateTime).IsRequired().HasComment("更新时间");
            // 设置是否删除默认值
            builder.Property(p => p.IsDeleted).HasDefaultValue<int>(0).HasComment("是否删除 0：未删除 1：删除");
            builder.Property(p => p.Description).HasComment("备注信息");
            builder.Property(p => p.DepartmentName).HasMaxLength(32).IsRequired().HasComment("部门名称");
        }
    }
}
