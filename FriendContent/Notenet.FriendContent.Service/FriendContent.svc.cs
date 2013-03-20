using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Notenet.Content.Data.Repository;
using Notenet.Content.Data.Translator;
using Notenet.Content.DataContract;
using Notenet.Security;
using Notenet.Security.DataContract;
using Notenet.User.Data.Repository;

namespace Notenet.FriendContent.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public sealed class FriendContent : IFriendContent, IDisposable
    {
        private ContentEntities content = new ContentEntities();
        private UserEntities user = new UserEntities();

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Tag> GetFriendTagList(Guid FriendID)
        {
            Guid uid = ((NotenetIdentity)HttpContext.Current.User.Identity).UID;
            this.CheckAccess(uid, FriendID);
            return this.content.ItemTags.Where(itemTag => itemTag.OwnerID == FriendID).ToList().Select(itemTag => TagTranslator.Translate(itemTag)).ToList();
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Notenet.Content.DataContract.Item> GetFriendTagItemList(Guid FriendID, string Tag)
        {
            Guid uid = ((NotenetIdentity)HttpContext.Current.User.Identity).UID;
            this.CheckAccess(uid, FriendID);
            return this.content.ItemTags.Where(itemTag => itemTag.OwnerID == FriendID && itemTag.Tag == Tag).Select(itemTag => itemTag.Item).ToList().Select(Item => ListItemTranslator.Translate(Item)).ToList();
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public ItemContent GetFriendItemContent(Guid FriendID, Guid ItemID)
        {
            Guid uid = ((NotenetIdentity)HttpContext.Current.User.Identity).UID;
            this.CheckAccess(uid, FriendID);
            return ItemContentTranslator.Translate(this.content.ItemTags.Where(itemTag => itemTag.OwnerID == FriendID && itemTag.ItemID == ItemID).Select(itemTag => itemTag.Item).Single());
        }

        public void Dispose()
        {
            this.content.Dispose();
            this.user.Dispose();
        }

        private void CheckAccess(Guid UserID, Guid FriendID)
        {
            // to be replaced, have to check relation type
            if (!user.FriendInfoes.Any(info => info.UserID == UserID && info.FriendID == FriendID))
            {
                throw new ArgumentException("Don't have access to the content of the requested user");
            }
        }
    }
}
