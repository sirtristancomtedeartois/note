
-- =============================================
-- Author:		Chuan Yu
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SubscribeUser]
  -- Add the parameters for the stored procedure here
  @UserId   uniqueidentifier,
  @FriendId uniqueidentifier
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @RowCount int

    BEGIN TRAN

    IF EXISTS (SELECT *
               FROM   [User].[dbo].[FriendInfo]
               WHERE  UserId = @UserId
                      AND FriendID = @FriendId)
    BEGIN
        UPDATE [User].[dbo].[FriendInfo]
        SET    [Status] = 1
        WHERE  UserId = @UserId
               AND FriendID = @FriendId

        SET @RowCount = @@ROWCOUNT
    END
    ELSE
    BEGIN
        INSERT INTO [User].[dbo].[FriendInfo]
        VALUES      (@UserId,
                     @FriendId,
                     1)

        SET @RowCount = @@ROWCOUNT
    END

    COMMIT

    SELECT @RowCount
END