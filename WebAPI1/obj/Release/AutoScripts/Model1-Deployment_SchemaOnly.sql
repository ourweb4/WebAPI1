SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContextKey] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MadterEntities](
	[MasterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShowWebsite] [bit] NOT NULL,
	[Website] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShowEmail] [bit] NOT NULL,
	[Email] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Username] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.MadterEntities] PRIMARY KEY CLUSTERED 
(
	[MasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreEntities](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShowWebsite] [bit] NOT NULL,
	[Website] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShowEmail] [bit] NOT NULL,
	[Email] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Sun] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mon] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Tue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Wed] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Thu] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fri] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Sat] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MadterEntity_MasterId] [int] NULL,
 CONSTRAINT [PK_dbo.StoreEntities] PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
CREATE NONCLUSTERED INDEX [IX_MadterEntity_MasterId] ON [dbo].[StoreEntities]
(
	[MadterEntity_MasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[StoreEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StoreEntities_dbo.MadterEntities_MadterEntity_MasterId] FOREIGN KEY([MadterEntity_MasterId])
REFERENCES [dbo].[MadterEntities] ([MasterId])
GO
ALTER TABLE [dbo].[StoreEntities] CHECK CONSTRAINT [FK_dbo.StoreEntities_dbo.MadterEntities_MadterEntity_MasterId]
GO
