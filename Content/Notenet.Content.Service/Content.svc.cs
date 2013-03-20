using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Notenet.Content.Data.Repository;
using Notenet.Content.Data.Translator;
using Notenet.Content.DataContract;
using Notenet.Security;
using Notenet.Security.DataContract;

namespace Notenet.Content.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public sealed class Content : IContent, IDisposable
    {
        private ContentEntities content = new ContentEntities();

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<Tag> GetUserTagList()
        {
            return this.content.ItemTags.Where(itemTag => itemTag.OwnerID == ((NotenetIdentity)HttpContext.Current.User.Identity).UID).ToList().Select(itemTag => TagTranslator.Translate(itemTag)).ToList();
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public ICollection<DataContract.Item> GetUserTagItemList(string Tag)
        {
            return this.content.ItemTags.Where(itemTag => itemTag.OwnerID == ((NotenetIdentity)HttpContext.Current.User.Identity).UID && itemTag.Tag == Tag).Select(itemTag => itemTag.Item).ToList().Select(Item => ListItemTranslator.Translate(Item)).ToList();
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        public ItemContent GetUserItemContent(Guid ItemID)
        {
            return ItemContentTranslator.Translate(this.content.ItemTags.Where(itemTag => itemTag.OwnerID == ((NotenetIdentity)HttpContext.Current.User.Identity).UID && itemTag.ItemID == ItemID).Select(itemTag => itemTag.Item).Single());
        }

        [WCFPermission]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public int PutItem(DataContract.Item Item)
        {
            // Owner
            // UriTemplate = "PutItem/{Item}",
            int itemsChanged = 0;
            Notenet.Content.Data.Repository.Item dbItem = this.content.Items.Where(i => i.ItemID == Item.ItemID).Single();
            try
            {
                ItemTranslator.Translate(dbItem, Item);
                itemsChanged = this.content.SaveChanges();
            }
            catch (OptimisticConcurrencyException e)
            {
                this.content.Refresh(RefreshMode.ClientWins, dbItem);
                itemsChanged = this.content.SaveChanges();
                // log exception after operation called by some attributes?
            }

            // this.content.PutItem();

            return itemsChanged;
        }

        //create item is needed

        public void Dispose()
        {
            this.content.Dispose();
        }
    }
}
