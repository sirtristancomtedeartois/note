using System.Runtime.Serialization;

namespace Notenet.Feed.DataContract
{
    [DataContract]
    public class ItemContent
    {
        [DataMember]
        public string ExternalUrl
        {
            get;
            internal set;
        }

        [DataMember]
        public string ItemText
        {
            get;
            internal set;
        }

        public ItemContent(string externalUrl, string itemText)
        {
            this.ExternalUrl = externalUrl;
            this.ItemText = ItemText;
        }

        public ItemContent()
        {
        }
    }
}