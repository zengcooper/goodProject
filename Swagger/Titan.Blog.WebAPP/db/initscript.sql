USE [TestDB]
GO
/****** Object:  User [TestUser]    Script Date: 2019/1/9 15:28:29 ******/
CREATE USER [TestUser] FOR LOGIN [TestUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [TestUser]
GO
/****** Object:  Table [dbo].[SysButton]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysButton](
	[SysButtonId] [uniqueidentifier] NOT NULL,
	[SysModuleId] [uniqueidentifier] NULL,
	[ButtonCode] [int] NULL,
	[ButtonName] [varchar](40) NULL,
 CONSTRAINT [PK_SYSBUTTON] PRIMARY KEY NONCLUSTERED 
(
	[SysButtonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysModule]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysModule](
	[SysModuleId] [uniqueidentifier] NOT NULL,
	[ModuleName] [varchar](50) NULL,
	[LinkUrl] [varchar](200) NULL,
	[Controller] [varchar](100) NULL,
	[Action] [varchar](100) NULL,
	[ModuleStatus] [bit] NULL,
	[Sort] [int] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[ModuleIcon] [varchar](200) NULL,
	[IsDelete] [bit] NULL,
	[ModuleDesc] [varchar](400) NULL,
	[ModuleType] [int] NULL,
	[SysUserId] [uniqueidentifier] NULL,
	[UserName] [varchar](100) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [uniqueidentifier] NULL,
	[ModifyByName] [varchar](100) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_SYSMODULE] PRIMARY KEY NONCLUSTERED 
(
	[SysModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysOperateLog]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysOperateLog](
	[SysOperateLogId] [uniqueidentifier] NOT NULL,
	[Controller] [varchar](100) NULL,
	[Action] [varchar](100) NULL,
	[LinkUrl] [varchar](200) NULL,
	[IPAddress] [varchar](50) NULL,
	[OperateTime] [datetime] NULL,
	[SysUserId] [uniqueidentifier] NULL,
	[UserName] [varchar](100) NULL,
	[OperateDesc] [varchar](400) NULL,
	[OperateType] [int] NULL,
	[BusinessId] [uniqueidentifier] NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_SYSOPERATELOG] PRIMARY KEY NONCLUSTERED 
(
	[SysOperateLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysRole]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysRole](
	[SysRoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [varchar](40) NULL,
	[RoleDesc] [varchar](400) NULL,
	[RoleStatus] [bit] NULL,
	[IsDelete] [bit] NULL,
	[SysUserId] [uniqueidentifier] NULL,
	[UserName] [varchar](100) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [uniqueidentifier] NULL,
	[ModifyByName] [varchar](100) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_SYSROLE] PRIMARY KEY NONCLUSTERED 
(
	[SysRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysRoleModuleButton]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysRoleModuleButton](
	[SysRoleModuleButtonId] [uniqueidentifier] NOT NULL,
	[SysRoleId] [uniqueidentifier] NULL,
	[SysModuleId] [uniqueidentifier] NULL,
	[AvailableButtonJson] [varchar](4000) NULL,
	[ModuleType] [int] NULL,
 CONSTRAINT [PK_SYSROLEMODULEBUTTON] PRIMARY KEY NONCLUSTERED 
(
	[SysRoleModuleButtonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysUser](
	[SysUserId] [uniqueidentifier] NOT NULL,
	[UserId] [varchar](100) NULL,
	[UserPwd] [varchar](100) NULL,
	[UserType] [int] NULL,
	[UserStatus] [int] NULL,
	[Telphone] [varchar](50) NULL,
 CONSTRAINT [PK_SYSUSER] PRIMARY KEY NONCLUSTERED 
(
	[SysUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysUserRole]    Script Date: 2019/1/9 15:28:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUserRole](
	[SysUserRoleId] [uniqueidentifier] NOT NULL,
	[SysUserId] [uniqueidentifier] NULL,
	[SysRoleId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_SYSUSERROLE] PRIMARY KEY NONCLUSTERED 
(
	[SysUserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮表Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysButton', @level2type=N'COLUMN',@level2name=N'SysButtonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'API和模块Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysButton', @level2type=N'COLUMN',@level2name=N'SysModuleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮代号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysButton', @level2type=N'COLUMN',@level2name=N'ButtonCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysButton', @level2type=N'COLUMN',@level2name=N'ButtonName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysButton'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'API和模块表Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'SysModuleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModuleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'API或模块地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'Controller'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'Action'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModuleStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModuleIcon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModuleDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否模块（0：api 1：模块）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModuleType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'SysUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModifyByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'API和模块表存储api接口和模块' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysModule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作记录Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'SysOperateLogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'Controller'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方法' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'Action'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'API或模块地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'LinkUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'IPAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'OperateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'SysUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'OperateDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作动作（0：登录 1：增 2：删 3：改 4：查）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'OperateType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'BusinessId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysOperateLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'SysRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'SysUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'ModifyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'ModifyByName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色与模块按钮关系Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleModuleButton', @level2type=N'COLUMN',@level2name=N'SysRoleModuleButtonId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleModuleButton', @level2type=N'COLUMN',@level2name=N'SysRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块或APIId' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleModuleButton', @level2type=N'COLUMN',@level2name=N'SysModuleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'可用按钮Json（最大应该不会超过2000个）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleModuleButton', @level2type=N'COLUMN',@level2name=N'AvailableButtonJson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否模块（0：api 1：模块）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleModuleButton', @level2type=N'COLUMN',@level2name=N'ModuleType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色与模块、按钮关系中间表
   一个角色下有多个模块，每个模块可用按钮存这个模块有哪些按钮是可以使用的。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleModuleButton'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'SysUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户帐号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserPwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型（0：普通用户 1：管理员 2：超级管理员）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态（0：禁用 1：启用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Telphone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表-用户信息表可以在建一个扩展表存真实姓名签名性别。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户与角色的关系Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserRole', @level2type=N'COLUMN',@level2name=N'SysUserRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserRole', @level2type=N'COLUMN',@level2name=N'SysUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserRole', @level2type=N'COLUMN',@level2name=N'SysRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户与角色中间表（一个用户可以有多个角色）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserRole'
GO
