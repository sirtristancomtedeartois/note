using System.Runtime.Serialization;

namespace Notenet.Content.DataContract
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
        public string InternalUrl
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

        public ItemContent(string externalUrl, string internalUrl, string itemText)
        {
            this.ExternalUrl = externalUrl;
            this.InternalUrl = internalUrl;
            this.ItemText = ItemText;
        }

        public ItemContent()
        {
        }
    }
}