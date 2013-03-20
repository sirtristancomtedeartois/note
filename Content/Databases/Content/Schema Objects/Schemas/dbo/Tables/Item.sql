USE [Content]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Item_ItemType]') AND parent_object_id = OBJECT_ID(N'[dbo].[Item]'))
ALTER TABLE [dbo].[Item] DROP CONSTRAINT [FK_Item_ItemType]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 06/16/2012 13:23:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
DROP TABLE [dbo].[Item]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 06/16/2012 13:23:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[ItemID] [uniqueidentifier] NOT NULL,
	[ItemTypeID] [tinyint] NOT NULL,
	[ExternalUrl] [nvarchar](max) NOT NULL,
	[InternalUrl] [nvarchar](max) NOT NULL,
	[ItemTitle] [nvarchar](50) NOT NULL,
	[ItemAbstract] [nvarchar](256) NOT NULL,
	[ItemText] [ntext] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_ItemType] FOREIGN KEY([ItemTypeID])
REFERENCES [dbo].[ItemType] ([ItemTypeID])
GO

ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_ItemType]
GO


