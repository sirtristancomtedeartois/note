CREATE TABLE [dbo].[ItemPermissionSpecificUser] (
    [ItemID]         UNIQUEIDENTIFIER NOT NULL,
    [UserID]         UNIQUEIDENTIFIER NOT NULL,
    [UserPermission] TINYINT          NOT NULL
);

