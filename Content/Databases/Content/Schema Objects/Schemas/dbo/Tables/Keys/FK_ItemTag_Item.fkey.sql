﻿ALTER TABLE [dbo].[ItemTag]
    ADD CONSTRAINT [FK_ItemTag_Item] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

