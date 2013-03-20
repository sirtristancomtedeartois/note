CREATE TABLE [dbo].[Item] (
    [ItemID]       UNIQUEIDENTIFIER NOT NULL,
    [ItemTypeID]   TINYINT          NOT NULL,
    [ExternalUrl]  NVARCHAR (MAX)   NOT NULL,
    [ItemTitle]    NVARCHAR (50)    NOT NULL,
    [ItemAbstract] NVARCHAR (256)   NOT NULL,
    [ItemText]     NTEXT            NOT NULL,
    [CreatedDate]  DATETIME         NOT NULL,
    [LastUpdated]  DATETIME         NOT NULL
);

