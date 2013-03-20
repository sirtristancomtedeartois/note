ALTER TABLE [dbo].[UserInfo]
    ADD CONSTRAINT [FK_UserInfo_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

