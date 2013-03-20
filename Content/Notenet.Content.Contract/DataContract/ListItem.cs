using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Notenet.Content.DataContract
{
    [DataContract]
    public class ListItem
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

        public ListItem(Guid itemID, string itemTitle, string itemAbstract, DateTime createdDate, DateTime lastUpdated)
        {
            this.ItemID = itemID;
            this.ItemTitle = itemTitle;
            this.ItemAbstract = ItemAbstract;
            this.CreatedDate = createdDate;
            this.LastUpdated = lastUpdated;
        }
    }
}