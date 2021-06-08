IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Department] (
    [ClusterID] int NOT NULL IDENTITY,
    [ID] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(32) NOT NULL,
    [CreateTime] timestamp NOT NULL DEFAULT (now()),
    [UpdateUser] nvarchar(32) NOT NULL,
    [UpdateTime] timestamp NOT NULL DEFAULT (now()),
    [Description] nvarchar(max) NULL,
    [IsDeleted] int NOT NULL DEFAULT 0,
    [ParentID] uniqueidentifier NULL,
    [DepartmentName] nvarchar(32) NOT NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([ClusterID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
EXEC sp_addextendedproperty 'MS_Description', N'部门表', 'SCHEMA', @defaultSchema, 'TABLE', N'Department';
EXEC sp_addextendedproperty 'MS_Description', N'创建用户', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'CreateUser';
EXEC sp_addextendedproperty 'MS_Description', N'创建时间', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'CreateTime';
EXEC sp_addextendedproperty 'MS_Description', N'更新用户', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'UpdateUser';
EXEC sp_addextendedproperty 'MS_Description', N'更新时间', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'UpdateTime';
EXEC sp_addextendedproperty 'MS_Description', N'备注信息', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'Description';
EXEC sp_addextendedproperty 'MS_Description', N'是否删除 0：未删除 1：删除', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'IsDeleted';
EXEC sp_addextendedproperty 'MS_Description', N'部门名称', 'SCHEMA', @defaultSchema, 'TABLE', N'Department', 'COLUMN', N'DepartmentName';

GO

CREATE TABLE [Menu] (
    [ClusterID] int NOT NULL IDENTITY,
    [ID] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(32) NOT NULL,
    [CreateTime] timestamp NOT NULL DEFAULT (now()),
    [UpdateUser] nvarchar(32) NOT NULL,
    [UpdateTime] timestamp NOT NULL DEFAULT (now()),
    [Description] nvarchar(max) NULL,
    [IsDeleted] int NOT NULL DEFAULT 0,
    [ParentID] uniqueidentifier NULL,
    [MenuName] nvarchar(32) NOT NULL,
    [Url] nvarchar(max) NOT NULL,
    [NameSpace] nvarchar(max) NOT NULL,
    [ClassName] nvarchar(32) NOT NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY ([ClusterID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
EXEC sp_addextendedproperty 'MS_Description', N'菜单表', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu';
EXEC sp_addextendedproperty 'MS_Description', N'创建用户', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'CreateUser';
EXEC sp_addextendedproperty 'MS_Description', N'创建时间', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'CreateTime';
EXEC sp_addextendedproperty 'MS_Description', N'更新用户', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'UpdateUser';
EXEC sp_addextendedproperty 'MS_Description', N'更新时间', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'UpdateTime';
EXEC sp_addextendedproperty 'MS_Description', N'备注信息', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'Description';
EXEC sp_addextendedproperty 'MS_Description', N'是否删除 0：未删除 1：删除', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'IsDeleted';
EXEC sp_addextendedproperty 'MS_Description', N'父级菜单ID', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'ParentID';
EXEC sp_addextendedproperty 'MS_Description', N'菜单名称', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'MenuName';
EXEC sp_addextendedproperty 'MS_Description', N'dll文件名称', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'Url';
EXEC sp_addextendedproperty 'MS_Description', N'命名空间', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'NameSpace';
EXEC sp_addextendedproperty 'MS_Description', N'类名', 'SCHEMA', @defaultSchema, 'TABLE', N'Menu', 'COLUMN', N'ClassName';

GO

CREATE TABLE [Role] (
    [ClusterID] int NOT NULL IDENTITY,
    [ID] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(32) NOT NULL,
    [CreateTime] timestamp NOT NULL DEFAULT (now()),
    [UpdateUser] nvarchar(32) NOT NULL,
    [UpdateTime] timestamp NOT NULL DEFAULT (now()),
    [Description] nvarchar(max) NULL,
    [IsDeleted] int NOT NULL DEFAULT 0,
    [RoleName] nvarchar(32) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([ClusterID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
EXEC sp_addextendedproperty 'MS_Description', N'角色表', 'SCHEMA', @defaultSchema, 'TABLE', N'Role';
EXEC sp_addextendedproperty 'MS_Description', N'创建用户', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'CreateUser';
EXEC sp_addextendedproperty 'MS_Description', N'创建时间', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'CreateTime';
EXEC sp_addextendedproperty 'MS_Description', N'更新用户', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'UpdateUser';
EXEC sp_addextendedproperty 'MS_Description', N'更新时间', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'UpdateTime';
EXEC sp_addextendedproperty 'MS_Description', N'备注信息', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'Description';
EXEC sp_addextendedproperty 'MS_Description', N'是否删除 0：未删除 1：删除', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'IsDeleted';
EXEC sp_addextendedproperty 'MS_Description', N'角色名称', 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'RoleName';

GO

CREATE TABLE [RoleMenu] (
    [ClusterID] int NOT NULL IDENTITY,
    [ID] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(32) NOT NULL,
    [CreateTime] timestamp NOT NULL DEFAULT (now()),
    [UpdateUser] nvarchar(32) NOT NULL,
    [UpdateTime] timestamp NOT NULL DEFAULT (now()),
    [Description] nvarchar(max) NULL,
    [IsDeleted] int NOT NULL DEFAULT 0,
    [RoleID] uniqueidentifier NOT NULL,
    [MenuID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_RoleMenu] PRIMARY KEY ([ClusterID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
EXEC sp_addextendedproperty 'MS_Description', N'角色菜单表', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu';
EXEC sp_addextendedproperty 'MS_Description', N'创建用户', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'CreateUser';
EXEC sp_addextendedproperty 'MS_Description', N'创建时间', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'CreateTime';
EXEC sp_addextendedproperty 'MS_Description', N'更新用户', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'UpdateUser';
EXEC sp_addextendedproperty 'MS_Description', N'更新时间', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'UpdateTime';
EXEC sp_addextendedproperty 'MS_Description', N'备注信息', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'Description';
EXEC sp_addextendedproperty 'MS_Description', N'是否删除 0：未删除 1：删除', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'IsDeleted';
EXEC sp_addextendedproperty 'MS_Description', N'角色ID', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'RoleID';
EXEC sp_addextendedproperty 'MS_Description', N'菜单ID', 'SCHEMA', @defaultSchema, 'TABLE', N'RoleMenu', 'COLUMN', N'MenuID';

GO

CREATE TABLE [User] (
    [ClusterID] int NOT NULL IDENTITY,
    [ID] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(32) NOT NULL,
    [CreateTime] timestamp NOT NULL DEFAULT (now()),
    [UpdateUser] nvarchar(32) NOT NULL,
    [UpdateTime] timestamp NOT NULL DEFAULT (now()),
    [Description] nvarchar(max) NULL,
    [IsDeleted] int NOT NULL DEFAULT 0,
    [LoginID] nvarchar(32) NOT NULL,
    [Password] nvarchar(32) NOT NULL,
    [Name] nvarchar(32) NOT NULL,
    [MobileNumber] nvarchar(16) NULL,
    [DepartmentID] uniqueidentifier NULL,
    [RoleID] uniqueidentifier NULL,
    [EmailAddress] nvarchar(128) NULL,
    [Position] nvarchar(64) NULL,
    [Status] int NOT NULL DEFAULT 0,
    [LoginTime] datetime2 NULL,
    [LoginErrorCount] int NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([ClusterID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
EXEC sp_addextendedproperty 'MS_Description', N'用户表', 'SCHEMA', @defaultSchema, 'TABLE', N'User';
EXEC sp_addextendedproperty 'MS_Description', N'创建用户', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CreateUser';
EXEC sp_addextendedproperty 'MS_Description', N'创建时间', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CreateTime';
EXEC sp_addextendedproperty 'MS_Description', N'更新用户', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'UpdateUser';
EXEC sp_addextendedproperty 'MS_Description', N'更新时间', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'UpdateTime';
EXEC sp_addextendedproperty 'MS_Description', N'备注信息', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Description';
EXEC sp_addextendedproperty 'MS_Description', N'是否删除 0：未删除 1：删除', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IsDeleted';
EXEC sp_addextendedproperty 'MS_Description', N'用户账号', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LoginID';
EXEC sp_addextendedproperty 'MS_Description', N'密码', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Password';
EXEC sp_addextendedproperty 'MS_Description', N'姓名', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Name';
EXEC sp_addextendedproperty 'MS_Description', N'手机号码', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'MobileNumber';
EXEC sp_addextendedproperty 'MS_Description', N'部门ID', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'DepartmentID';
EXEC sp_addextendedproperty 'MS_Description', N'角色ID', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'RoleID';
EXEC sp_addextendedproperty 'MS_Description', N'邮箱地址', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'EmailAddress';
EXEC sp_addextendedproperty 'MS_Description', N'职务', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Position';
EXEC sp_addextendedproperty 'MS_Description', N'用户状态 0：正常 1 冻结 2：注销 默认0', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Status';
EXEC sp_addextendedproperty 'MS_Description', N'错误登录次数', 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LoginErrorCount';

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'DepartmentName', N'Description', N'ID', N'ParentID', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[Department]'))
    SET IDENTITY_INSERT [Department] ON;
INSERT INTO [Department] ([ClusterID], [CreateTime], [CreateUser], [DepartmentName], [Description], [ID], [ParentID], [UpdateTime], [UpdateUser])
VALUES (1, 0x88D8D95E54080374, N'系统管理员', N'系统维护部', NULL, '8f1c1d65-81fe-46c9-9044-f5a73fd1ad05', NULL, 0x88D8D95E54080546, N'系统管理员');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'DepartmentName', N'Description', N'ID', N'ParentID', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[Department]'))
    SET IDENTITY_INSERT [Department] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'ClassName', N'CreateTime', N'CreateUser', N'Description', N'ID', N'MenuName', N'NameSpace', N'ParentID', N'UpdateTime', N'UpdateUser', N'Url') AND [object_id] = OBJECT_ID(N'[Menu]'))
    SET IDENTITY_INSERT [Menu] ON;
INSERT INTO [Menu] ([ClusterID], [ClassName], [CreateTime], [CreateUser], [Description], [ID], [MenuName], [NameSpace], [ParentID], [UpdateTime], [UpdateUser], [Url])
VALUES (1, N'System', 0x88D8D95E54084EC1, N'系统管理员', NULL, '9d62d75f-69ac-4395-b1cf-0534bfea0c5f', N'系统管理', N'FaClient.System', NULL, 0x88D8D95E54084EC2, N'系统管理员', N'FaClient.System');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'ClassName', N'CreateTime', N'CreateUser', N'Description', N'ID', N'MenuName', N'NameSpace', N'ParentID', N'UpdateTime', N'UpdateUser', N'Url') AND [object_id] = OBJECT_ID(N'[Menu]'))
    SET IDENTITY_INSERT [Menu] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'Description', N'ID', N'RoleName', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[Role]'))
    SET IDENTITY_INSERT [Role] ON;
INSERT INTO [Role] ([ClusterID], [CreateTime], [CreateUser], [Description], [ID], [RoleName], [UpdateTime], [UpdateUser])
VALUES (1, 0x88D8D95E54083D28, N'系统管理员', NULL, 'fafc8bf5-724d-467c-919f-d7579f2cff44', N'系统管理员', 0x88D8D95E54083D30, N'系统管理员');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'Description', N'ID', N'RoleName', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[Role]'))
    SET IDENTITY_INSERT [Role] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'Description', N'ID', N'MenuID', N'RoleID', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[RoleMenu]'))
    SET IDENTITY_INSERT [RoleMenu] ON;
INSERT INTO [RoleMenu] ([ClusterID], [CreateTime], [CreateUser], [Description], [ID], [MenuID], [RoleID], [UpdateTime], [UpdateUser])
VALUES (1, 0x88D8D95E54085849, N'系统管理员', NULL, '68f11b6f-9558-42d5-b104-4adc83bca507', '9d62d75f-69ac-4395-b1cf-0534bfea0c5f', 'fafc8bf5-724d-467c-919f-d7579f2cff44', 0x88D8D95E5408584A, N'系统管理员');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'Description', N'ID', N'MenuID', N'RoleID', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[RoleMenu]'))
    SET IDENTITY_INSERT [RoleMenu] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'DepartmentID', N'Description', N'EmailAddress', N'ID', N'LoginErrorCount', N'LoginID', N'LoginTime', N'MobileNumber', N'Name', N'Password', N'Position', N'RoleID', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] ON;
INSERT INTO [User] ([ClusterID], [CreateTime], [CreateUser], [DepartmentID], [Description], [EmailAddress], [ID], [LoginErrorCount], [LoginID], [LoginTime], [MobileNumber], [Name], [Password], [Position], [RoleID], [UpdateTime], [UpdateUser])
VALUES (1, 0x88D8D95E540841A6, N'系统管理员', '8f1c1d65-81fe-46c9-9044-f5a73fd1ad05', NULL, NULL, 'aa6d379e-ff78-4514-a2ee-c2b80e66ab00', 0, N'admin', NULL, NULL, N'系统管理员', N'e10adc3949ba59abbe56e057f20f883e', NULL, 'fafc8bf5-724d-467c-919f-d7579f2cff44', 0x88D8D95E540841A7, N'系统管理员');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClusterID', N'CreateTime', N'CreateUser', N'DepartmentID', N'Description', N'EmailAddress', N'ID', N'LoginErrorCount', N'LoginID', N'LoginTime', N'MobileNumber', N'Name', N'Password', N'Position', N'RoleID', N'UpdateTime', N'UpdateUser') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210225072403_InitialDb', N'3.1.0');

GO

