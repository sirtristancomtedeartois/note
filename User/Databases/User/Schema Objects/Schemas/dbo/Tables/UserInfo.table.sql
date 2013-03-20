CREATE TABLE [dbo].[UserInfo] (
    [UserId]   UNIQUEIDENTIFIER NOT NULL,
    [Birthday] DATE             NULL,
    [NickName] NVARCHAR (50)    NULL,
    [RealName] NVARCHAR (50)    NULL,
    [Email]    NVARCHAR (50)    NULL
);

