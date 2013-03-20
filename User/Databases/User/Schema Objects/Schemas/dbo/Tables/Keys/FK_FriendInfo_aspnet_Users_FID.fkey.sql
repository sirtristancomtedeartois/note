ALTER TABLE [dbo].[FriendInfo]
    ADD CONSTRAINT [FK_FriendInfo_aspnet_Users_FID] FOREIGN KEY ([FriendID]) REFERENCES [dbo].[aspnet_Users] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

