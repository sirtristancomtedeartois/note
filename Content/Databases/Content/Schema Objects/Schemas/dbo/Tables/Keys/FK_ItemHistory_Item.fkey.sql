﻿ALTER TABLE [dbo].[ItemHistory]
    ADD CONSTRAINT [FK_ItemHistory_Item] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Item] ([ItemID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

