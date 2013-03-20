using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;

namespace Notenet.Feed.DataContract
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public Guid ItemID
        {
            get;

            private set;
        }

        [DataMember]
        public string ItemTitle
        {
            get;
            private set;
        }

        [DataMember]
        public string ItemAbstract
        {
            get;
            private set;
        }

        [DataMember]
        public DateTime CreatedDate
        {
            get;
            private set;
        }

        [DataMember]
        public DateTime LastUpdated
        {
            get;
            private set;
        }

        [DataMember]
        public ItemContent Content
        {
            get;
            private set;
        }

        public Item(Guid itemID, string itemTitle, string itemAbstract, DateTime createdDate, DateTime lastUpdated)
        {
            this.ItemID = itemID;
            this.ItemTitle = itemTitle;
            this.ItemAbstract = itemAbstract;
            this.CreatedDate = createdDate;
            this.LastUpdated = lastUpdated;
        }

        public void SetContent(ItemContent content)
        {
            Contract.Requires<ArgumentNullException>(content != null);
            this.Content.ExternalUrl = content.ExternalUrl;
            this.Content.ItemText = content.ItemText;
        }
    }
}