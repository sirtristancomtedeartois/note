﻿ALTER TABLE [dbo].[Item]
    ADD CONSTRAINT [FK_Item_ItemType] FOREIGN KEY ([ItemTypeID]) REFERENCES [dbo].[ItemType] ([ItemTypeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

