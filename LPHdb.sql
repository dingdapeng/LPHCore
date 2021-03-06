USE [master]
GO
/****** Object:  Database [LPHdb]    Script Date: 2017/5/27 17:38:17 ******/
CREATE DATABASE [LPHdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LPHdb', FILENAME = N'D:\DB\LPHdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LPHdb_log', FILENAME = N'D:\DB\LPHdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LPHdb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LPHdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LPHdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LPHdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LPHdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LPHdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LPHdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LPHdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LPHdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LPHdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LPHdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LPHdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LPHdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LPHdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LPHdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LPHdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LPHdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LPHdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LPHdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LPHdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LPHdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LPHdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LPHdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LPHdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LPHdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LPHdb] SET  MULTI_USER 
GO
ALTER DATABASE [LPHdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LPHdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LPHdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LPHdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LPHdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LPHdb] SET QUERY_STORE = OFF
GO
USE [LPHdb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [LPHdb]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[ImgUrl] [nvarchar](100) NULL,
	[Contents] [ntext] NULL,
	[CreateTime] [datetime] NOT NULL,
	[Click] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Seq] [int] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsCategory]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_News_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysMenu]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[URL] [varchar](500) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[Seq] [int] NOT NULL,
 CONSTRAINT [PK_SysMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysPermissin]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysPermissin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Types] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SysAuthority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysPermissinSysMenu]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysPermissinSysMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SysPermissinID] [int] NOT NULL,
	[SysMenuID] [int] NOT NULL,
 CONSTRAINT [PK_SysPermissin_SysMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysRole]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysRoleSysPermissin]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysRoleSysPermissin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SysRoleID] [int] NOT NULL,
	[SysPermissinID] [int] NOT NULL,
 CONSTRAINT [PK_SysRole_SysPermissin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [varchar](100) NOT NULL,
	[TrueName] [nvarchar](50) NOT NULL,
	[CreatTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_SysUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SysUserSysRole]    Script Date: 2017/5/27 17:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUserSysRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SysUserID] [int] NOT NULL,
	[SysRoleID] [int] NOT NULL,
 CONSTRAINT [PK_SysUser_SysRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_Click]  DEFAULT ((0)) FOR [Click]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_Seq]  DEFAULT ((0)) FOR [Seq]
GO
ALTER TABLE [dbo].[SysMenu] ADD  CONSTRAINT [DF_SysMenu_Seq]  DEFAULT ((0)) FOR [Seq]
GO
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF_SysUser_CreatTime]  DEFAULT (getdate()) FOR [CreatTime]
GO
ALTER TABLE [dbo].[SysUser] ADD  CONSTRAINT [DF__SysUser__Statusa__2645B050]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[News]  WITH NOCHECK ADD  CONSTRAINT [FK_News_News_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[NewsCategory] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[News] NOCHECK CONSTRAINT [FK_News_News_Category]
GO
ALTER TABLE [dbo].[SysPermissinSysMenu]  WITH CHECK ADD  CONSTRAINT [FK_SysPermissin_SysMenu_SysMenu] FOREIGN KEY([SysMenuID])
REFERENCES [dbo].[SysMenu] ([ID])
GO
ALTER TABLE [dbo].[SysPermissinSysMenu] CHECK CONSTRAINT [FK_SysPermissin_SysMenu_SysMenu]
GO
ALTER TABLE [dbo].[SysPermissinSysMenu]  WITH CHECK ADD  CONSTRAINT [FK_SysPermissin_SysMenu_SysPermissin] FOREIGN KEY([SysPermissinID])
REFERENCES [dbo].[SysPermissin] ([ID])
GO
ALTER TABLE [dbo].[SysPermissinSysMenu] CHECK CONSTRAINT [FK_SysPermissin_SysMenu_SysPermissin]
GO
ALTER TABLE [dbo].[SysRoleSysPermissin]  WITH CHECK ADD  CONSTRAINT [FK_SysRole_SysPermissin_SysPermissin] FOREIGN KEY([SysPermissinID])
REFERENCES [dbo].[SysPermissin] ([ID])
GO
ALTER TABLE [dbo].[SysRoleSysPermissin] CHECK CONSTRAINT [FK_SysRole_SysPermissin_SysPermissin]
GO
ALTER TABLE [dbo].[SysRoleSysPermissin]  WITH CHECK ADD  CONSTRAINT [FK_SysRole_SysPermissin_SysRole] FOREIGN KEY([SysRoleID])
REFERENCES [dbo].[SysRole] ([ID])
GO
ALTER TABLE [dbo].[SysRoleSysPermissin] CHECK CONSTRAINT [FK_SysRole_SysPermissin_SysRole]
GO
ALTER TABLE [dbo].[SysUserSysRole]  WITH CHECK ADD  CONSTRAINT [FK_SysUserSysRole_SysRole] FOREIGN KEY([SysRoleID])
REFERENCES [dbo].[SysRole] ([ID])
GO
ALTER TABLE [dbo].[SysUserSysRole] CHECK CONSTRAINT [FK_SysUserSysRole_SysRole]
GO
ALTER TABLE [dbo].[SysUserSysRole]  WITH CHECK ADD  CONSTRAINT [FK_SysUserSysRole_SysUser] FOREIGN KEY([SysUserID])
REFERENCES [dbo].[SysUser] ([ID])
GO
ALTER TABLE [dbo].[SysUserSysRole] CHECK CONSTRAINT [FK_SysUserSysRole_SysUser]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'ImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Contents'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Click'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Seq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NewsCategory', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NewsCategory', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'Seq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPermissin', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPermissin', @level2type=N'COLUMN',@level2name=N'Types'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPermissinSysMenu', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PermissinID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPermissinSysMenu', @level2type=N'COLUMN',@level2name=N'SysPermissinID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SysMenuID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPermissinSysMenu', @level2type=N'COLUMN',@level2name=N'SysMenuID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleSysPermissin', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SysRoleID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleSysPermissin', @level2type=N'COLUMN',@level2name=N'SysRoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SysPermissinID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRoleSysPermissin', @level2type=N'COLUMN',@level2name=N'SysPermissinID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'TrueName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'CreatTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态0禁用1启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserSysRole', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SysUserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserSysRole', @level2type=N'COLUMN',@level2name=N'SysUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SysRoleID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserSysRole', @level2type=N'COLUMN',@level2name=N'SysRoleID'
GO
USE [master]
GO
ALTER DATABASE [LPHdb] SET  READ_WRITE 
GO
