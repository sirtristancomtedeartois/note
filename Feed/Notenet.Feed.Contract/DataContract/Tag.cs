using System;
using System.Runtime.Serialization;

namespace Notenet.Feed.DataContract
{
    [DataContract]
    public class Tag
    {
        [DataMember]
        public string TagText
        {
            get;
            private set;
        }

        [DataMember]
        public Guid ItemID
        {
            get;
            private set;
        }

        public Tag(string tag, Guid itemID)
        {
            this.TagText = tag;
            this.ItemID = itemID;
        }
    }
}