using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AuthoritySystem.EFCore.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Department",
                columns: table => new
                {
                    ClusterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentID = table.Column<Guid>(type: "uuid", nullable: true),
                    DepartmentName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "部门名称"),
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "创建用户"),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "创建时间"),
                    UpdateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "更新用户"),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新时间"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "备注信息"),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "是否删除 0：未删除 1：删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Department", x => x.ClusterID);
                },
                comment: "部门表");

            migrationBuilder.CreateTable(
                name: "TB_Menu",
                columns: table => new
                {
                    ClusterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentID = table.Column<Guid>(type: "uuid", nullable: true, comment: "父级菜单ID"),
                    MenuName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "菜单名称"),
                    Url = table.Column<string>(type: "text", nullable: false, comment: "dll文件名称"),
                    NameSpace = table.Column<string>(type: "text", nullable: false, comment: "命名空间"),
                    ClassName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "类名"),
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "创建用户"),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "创建时间"),
                    UpdateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "更新用户"),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新时间"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "备注信息"),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "是否删除 0：未删除 1：删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Menu", x => x.ClusterID);
                },
                comment: "菜单表");

            migrationBuilder.CreateTable(
                name: "TB_Role",
                columns: table => new
                {
                    ClusterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "角色名称"),
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "创建用户"),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "创建时间"),
                    UpdateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "更新用户"),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新时间"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "备注信息"),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "是否删除 0：未删除 1：删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Role", x => x.ClusterID);
                },
                comment: "角色表");

            migrationBuilder.CreateTable(
                name: "TB_RoleMenu",
                columns: table => new
                {
                    ClusterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<Guid>(type: "uuid", nullable: false, comment: "角色ID"),
                    MenuID = table.Column<Guid>(type: "uuid", nullable: false, comment: "菜单ID"),
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "创建用户"),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "创建时间"),
                    UpdateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "更新用户"),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新时间"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "备注信息"),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "是否删除 0：未删除 1：删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RoleMenu", x => x.ClusterID);
                },
                comment: "角色菜单表");

            migrationBuilder.CreateTable(
                name: "TB_User",
                columns: table => new
                {
                    ClusterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginID = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "用户账号"),
                    Password = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "密码"),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "姓名"),
                    MobileNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true, comment: "手机号码"),
                    DepartmentID = table.Column<Guid>(type: "uuid", nullable: true, comment: "部门ID"),
                    RoleID = table.Column<Guid>(type: "uuid", nullable: true, comment: "角色ID"),
                    EmailAddress = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "邮箱地址"),
                    Position = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true, comment: "职务"),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "用户状态 0：正常 1 冻结 2：注销 默认0"),
                    LoginTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LoginErrorCount = table.Column<int>(type: "integer", nullable: false, comment: "错误登录次数"),
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "创建用户"),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "创建时间"),
                    UpdateUser = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false, comment: "更新用户"),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新时间"),
                    Description = table.Column<string>(type: "text", nullable: true, comment: "备注信息"),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "是否删除 0：未删除 1：删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_User", x => x.ClusterID);
                },
                comment: "用户表");

            migrationBuilder.InsertData(
                table: "TB_Department",
                columns: new[] { "ClusterID", "CreateTime", "CreateUser", "DepartmentName", "Description", "ID", "ParentID", "UpdateTime", "UpdateUser" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 15, 13, 17, 724, DateTimeKind.Local).AddTicks(2329), "系统管理员", "系统维护部", null, new Guid("bfd0c4fb-1279-437f-9654-063c1d7deb71"), null, new DateTime(2021, 6, 9, 15, 13, 17, 724, DateTimeKind.Local).AddTicks(2900), "系统管理员" });

            migrationBuilder.InsertData(
                table: "TB_Role",
                columns: new[] { "ClusterID", "CreateTime", "CreateUser", "Description", "ID", "RoleName", "UpdateTime", "UpdateUser" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 15, 13, 17, 725, DateTimeKind.Local).AddTicks(9544), "系统管理员", null, new Guid("f0cc7f21-0ed2-42c4-bd4a-a95110140efa"), "系统管理员", new DateTime(2021, 6, 9, 15, 13, 17, 725, DateTimeKind.Local).AddTicks(9545), "系统管理员" });

            migrationBuilder.InsertData(
                table: "TB_RoleMenu",
                columns: new[] { "ClusterID", "CreateTime", "CreateUser", "Description", "ID", "MenuID", "RoleID", "UpdateTime", "UpdateUser" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 15, 13, 17, 726, DateTimeKind.Local).AddTicks(6735), "系统管理员", null, new Guid("8a5d9b31-86ea-48f1-807c-81716dd291df"), new Guid("f358f4c0-a044-45a6-85ec-d38830909105"), new Guid("f0cc7f21-0ed2-42c4-bd4a-a95110140efa"), new DateTime(2021, 6, 9, 15, 13, 17, 726, DateTimeKind.Local).AddTicks(6736), "系统管理员" });

            migrationBuilder.InsertData(
                table: "TB_User",
                columns: new[] { "ClusterID", "CreateTime", "CreateUser", "DepartmentID", "Description", "EmailAddress", "ID", "LoginErrorCount", "LoginID", "LoginTime", "MobileNumber", "Name", "Password", "Position", "RoleID", "UpdateTime", "UpdateUser" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 15, 13, 17, 726, DateTimeKind.Local).AddTicks(1316), "系统管理员", new Guid("bfd0c4fb-1279-437f-9654-063c1d7deb71"), null, null, new Guid("936e5d10-071d-41a1-86a9-da1d0907626e"), 0, "admin", null, null, "系统管理员", "e10adc3949ba59abbe56e057f20f883e", null, new Guid("f0cc7f21-0ed2-42c4-bd4a-a95110140efa"), new DateTime(2021, 6, 9, 15, 13, 17, 726, DateTimeKind.Local).AddTicks(1318), "系统管理员" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Department");

            migrationBuilder.DropTable(
                name: "TB_Menu");

            migrationBuilder.DropTable(
                name: "TB_Role");

            migrationBuilder.DropTable(
                name: "TB_RoleMenu");

            migrationBuilder.DropTable(
                name: "TB_User");
        }
    }
}
