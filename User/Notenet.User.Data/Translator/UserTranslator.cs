using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notenet.User.Data.Repository;

namespace Notenet.User.Data.Translator
{
    public class UserTranslator
    {
        public static Notenet.User.Contract.DataContract.User Translate(Repository.aspnet_Users aspnetUser)
        {
            Notenet.User.Contract.DataContract.User user = new Notenet.User.Contract.DataContract.User(aspnetUser.UserId, aspnetUser.UserName);
            if (aspnetUser.UserInfo != null)
            {
                user.Birthday = aspnetUser.UserInfo.Birthday.Value;
                user.Email = aspnetUser.UserInfo.Email;
                user.NickName = aspnetUser.UserInfo.NickName;
                user.RealName = aspnetUser.UserInfo.RealName;
            }
            else
            {
                user.Birthday = DateTime.Now.Date;
            }

            return user;
        }
    }
}
