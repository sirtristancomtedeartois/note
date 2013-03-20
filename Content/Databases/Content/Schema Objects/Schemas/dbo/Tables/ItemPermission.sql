USE [Content]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemPermission_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemPermission]'))
ALTER TABLE [dbo].[ItemPermission] DROP CONSTRAINT [FK_ItemPermission_Item]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemPermission]    Script Date: 06/16/2012 13:25:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemPermission]') AND type in (N'U'))
DROP TABLE [dbo].[ItemPermission]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemPermission]    Script Date: 06/16/2012 13:25:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemPermission](
	[ItemID] [uniqueidentifier] NOT NULL,
	[RoleType] [tinyint] NOT NULL,
	[RolePermission] [tinyint] NOT NULL,
	[HasSpecificUserIDPermission] [bit] NOT NULL,
 CONSTRAINT [PK_ItemPermission] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[RoleType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ItemPermission]  WITH CHECK ADD  CONSTRAINT [FK_ItemPermission_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO

ALTER TABLE [dbo].[ItemPermission] CHECK CONSTRAINT [FK_ItemPermission_Item]
GO


