ALTER TABLE [dbo].[ItemPermissionSpecificUser]
    ADD CONSTRAINT [FK_ItemPermissionSpecificUser_Item] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

