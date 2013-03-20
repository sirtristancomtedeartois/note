ALTER TABLE [dbo].[ItemPermission]
    ADD CONSTRAINT [FK_ItemPermission_Item] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

