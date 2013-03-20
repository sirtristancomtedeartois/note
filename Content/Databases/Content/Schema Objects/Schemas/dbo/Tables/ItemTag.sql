USE [Content]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemTag_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemTag]'))
ALTER TABLE [dbo].[ItemTag] DROP CONSTRAINT [FK_ItemTag_Item]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemTag]    Script Date: 06/16/2012 13:25:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemTag]') AND type in (N'U'))
DROP TABLE [dbo].[ItemTag]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemTag]    Script Date: 06/16/2012 13:25:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ItemTag](
	[OwnerID] [uniqueidentifier] NOT NULL,
	[Tag] [varchar](50) NOT NULL,
	[ItemID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ItemTag] PRIMARY KEY CLUSTERED 
(
	[OwnerID] ASC,
	[ItemID] ASC,
	[Tag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ItemTag]  WITH CHECK ADD  CONSTRAINT [FK_ItemTag_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO

ALTER TABLE [dbo].[ItemTag] CHECK CONSTRAINT [FK_ItemTag_Item]
GO


