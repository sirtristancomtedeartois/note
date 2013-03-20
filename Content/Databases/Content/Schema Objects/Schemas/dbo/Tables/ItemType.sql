USE [Content]
GO

/****** Object:  Table [dbo].[ItemType]    Script Date: 06/16/2012 13:27:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemType]') AND type in (N'U'))
DROP TABLE [dbo].[ItemType]
GO

USE [Content]
GO

/****** Object:  Table [dbo].[ItemType]    Script Date: 06/16/2012 13:27:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemType](
	[ItemTypeID] [tinyint] NOT NULL,
	[ItemTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED 
(
	[ItemTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

