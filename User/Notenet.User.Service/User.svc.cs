using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Notenet.Security;
using Notenet.Security.DataContract;
using Notenet.User.Data.Repository;
using Notenet.User.Data.Translator;

namespace Notenet.User.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public sealed class User : IUser, IDisposable
    {
        public UserEntities db = new UserEntities();

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public List<Notenet.User.Contract.DataContract.User> GetFriendList(Guid userId)
        {
            List<Contract.DataContract.User> userList = new List<Contract.DataContract.User>();
            List<FriendInfo> friendList = db.FriendInfoes.Where(userInfo => userInfo.UserID == userId).ToList();
            if (friendList.Count > 0)
            {
                foreach (FriendInfo friend in friendList)
                {
                    userList.Add(UserTranslator.Translate(friend.aspnet_Users));
                }
            }
            return userList;
        }

        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public bool IsLegalUserName(string userName)
        {
            return !db.aspnet_Users.Any(obj => obj.UserName == userName);
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public int PutUserProfile(Contract.DataContract.User user)
        {
            Guid userId = ((NotenetIdentity)HttpContext.Current.User.Identity).UID;
            if (userId != user.userID)
            {
                return -1;//will not be stopped at exception
            }

            return (int)db.PutUserInfo(user.userID, user.Birthday, user.NickName, user.RealName, user.Email).FirstOrDefault();
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public Contract.DataContract.User GetUser()
        {
            Guid userId = ((NotenetIdentity)HttpContext.Current.User.Identity).UID;
            return UserTranslator.Translate(db.aspnet_Users.First(obj => obj.UserId == userId));
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public Contract.DataContract.User FindUserByUserId(Guid userId)
        {
            return UserTranslator.Translate(db.aspnet_Users.First(obj => obj.UserId == userId));
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public Contract.DataContract.User FindUserByUserName(string userName)
        {
            return UserTranslator.Translate(db.aspnet_Users.First(obj => obj.UserName == userName));
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public Contract.DataContract.User FindUserByEmail(string email)
        {
            return UserTranslator.Translate(db.aspnet_Users.First(obj => obj.UserInfo.Email == email));
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public int SubscribeUser(Guid friendUserId)
        {
            Guid userId = ((NotenetIdentity)HttpContext.Current.User.Identity).UID;
            if (userId == friendUserId)
            {
                return -1;
            }

            return (int)db.SubscribeUser(userId, friendUserId).FirstOrDefault();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
