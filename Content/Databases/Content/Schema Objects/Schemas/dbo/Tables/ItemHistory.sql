USE [Content]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemHistory_Item]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemHistory]'))
ALTER TABLE [dbo].[ItemHistory] DROP CONSTRAINT [FK_ItemHistory_Item]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemHistory]    Script Date: 06/16/2012 13:24:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemHistory]') AND type in (N'U'))
DROP TABLE [dbo].[ItemHistory]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemHistory]    Script Date: 06/16/2012 13:24:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemHistory](
	[ItemID] [uniqueidentifier] NOT NULL,
	[RevisionDate] [datetime] NOT NULL,
	[ItemTitle] [nvarchar](50) NOT NULL,
	[ItemAbstract] [nvarchar](256) NOT NULL,
	[ItemText] [ntext] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ItemHistory] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[RevisionDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ItemHistory]  WITH CHECK ADD  CONSTRAINT [FK_ItemHistory_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ItemID])
GO

ALTER TABLE [dbo].[ItemHistory] CHECK CONSTRAINT [FK_ItemHistory_Item]
GO


