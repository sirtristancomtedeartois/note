CREATE TABLE [dbo].[ItemHistory] (
    [ItemID]       UNIQUEIDENTIFIER NOT NULL,
    [RevisionDate] DATETIME         NOT NULL,
    [ItemTitle]    NVARCHAR (50)    NOT NULL,
    [ItemAbstract] NVARCHAR (256)   NOT NULL,
    [ItemText]     NTEXT            NOT NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NOT NULL
);

