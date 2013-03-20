ALTER TABLE [dbo].[FriendInfo]
    ADD CONSTRAINT [FK_FriendInfo_aspnet_Users_UID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[aspnet_Users] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

