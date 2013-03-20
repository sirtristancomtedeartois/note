ALTER TABLE [dbo].[Item]
    ADD CONSTRAINT [DF_Item_ItemID] DEFAULT (newid()) FOR [ItemID];

