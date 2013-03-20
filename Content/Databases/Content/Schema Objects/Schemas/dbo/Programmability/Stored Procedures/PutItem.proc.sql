
-- =============================================
-- Author:		Chuan Yu
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[PutItem]
  -- Add the parameters for the stored procedure here
  @ItemID       uniqueidentifier,
  @ItemTypeID   tinyint,
  @ExternalUrl  nvarchar(max),
  @InternalUrl  nvarchar(max),
  @ItemTitle    nvarchar(50),
  @ItemAbstract nvarchar(256),
  @ItemText     ntext,
  @CreatedDate  datetime,
  @LastUpdated  datetime
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @RowCount int

    BEGIN TRAN

    IF EXISTS (SELECT *
               FROM   [Content].[dbo].[Item]
               WHERE  ItemID = @ItemID)
    BEGIN
        UPDATE [Content].[dbo].[Item]
        SET    [ItemTypeID] = @ItemTypeID,
               [ExternalUrl] = @ExternalUrl,
               [InternalUrl] = @InternalUrl,
               [ItemTitle] = @ItemTitle,
               [ItemAbstract] = @ItemAbstract,
               [ItemText] = @ItemText,
               [CreatedDate] = @CreatedDate,
               [LastUpdated] = @LastUpdated
        WHERE  [ItemID] = @ItemID

        SET @RowCount = @@ROWCOUNT
    END
    ELSE
    BEGIN
        INSERT INTO [Content].[dbo].[Item]
        VALUES      (@ItemID,
                     @ItemTypeID,
                     @ExternalUrl,
                     @InternalUrl,
                     @ItemTitle,
                     @ItemAbstract,
                     @ItemText,
                     @CreatedDate,
                     @LastUpdated)

        SET @RowCount = @@ROWCOUNT
    END

    COMMIT

    SELECT @RowCount
END