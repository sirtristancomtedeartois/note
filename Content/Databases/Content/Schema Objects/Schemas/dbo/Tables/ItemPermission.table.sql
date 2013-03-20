CREATE TABLE [dbo].[ItemPermission] (
    [ItemID]                      UNIQUEIDENTIFIER NOT NULL,
    [RoleType]                    TINYINT          NOT NULL,
    [RolePermission]              TINYINT          NOT NULL,
    [HasSpecificUserIDPermission] BIT              NOT NULL
);

