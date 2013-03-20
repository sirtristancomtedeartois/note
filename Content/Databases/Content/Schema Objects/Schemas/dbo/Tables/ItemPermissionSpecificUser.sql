USE [Content]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemPermissionSpecificUser_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemPermissionSpecificUser]'))
ALTER TABLE [dbo].[ItemPermissionSpecificUser] DROP CONSTRAINT [FK_ItemPermissionSpecificUser_Item]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemPermissionSpecificUser]    Script Date: 06/16/2012 13:27:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemPermissionSpecificUser]') AND type in (N'U'))
DROP TABLE [dbo].[ItemPermissionSpecificUser]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemPermissionSpecificUser]    Script Date: 06/16/2012 13:27:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemPermissionSpecificUser](
	[ItemID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[UserPermission] [tinyint] NOT NULL,
 CONSTRAINT [PK_ItemPermissionSpecificUser] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ItemPermissionSpecificUser]  WITH CHECK ADD  CONSTRAINT [FK_ItemPermissionSpecificUser_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO

ALTER TABLE [dbo].[ItemPermissionSpecificUser] CHECK CONSTRAINT [FK_ItemPermissionSpecificUser_Item]
GO

