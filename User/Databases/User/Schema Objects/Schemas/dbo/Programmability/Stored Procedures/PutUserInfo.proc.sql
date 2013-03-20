
-- =============================================
-- Author:		Chuan Yu
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[PutUserInfo]
  -- Add the parameters for the stored procedure here
  @UserId   uniqueidentifier,
  @Birthday date,
  @NickName nvarchar(50),
  @RealName nvarchar(50),
  @Email    nvarchar(50)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @RowCount int

    BEGIN TRAN

    IF EXISTS (SELECT *
               FROM   [User].[dbo].[UserInfo]
               WHERE  UserId = @UserId)
    BEGIN
        UPDATE [User].[dbo].[UserInfo]
        SET    [Birthday] = @Birthday,
               [NickName] = @NickName,
               [RealName] = @RealName,
               [Email] = @Email
        WHERE  [UserId] = @UserId

        SET @RowCount = @@ROWCOUNT
    END
    ELSE
    BEGIN
        INSERT INTO [User].[dbo].[UserInfo]
        VALUES      (@UserId,
                     @Birthday,
                     @NickName,
                     @RealName,
                     @Email)

        SET @RowCount = @@ROWCOUNT
    END

    COMMIT

    SELECT @RowCount
END