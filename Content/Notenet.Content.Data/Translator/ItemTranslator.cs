using System;

namespace Notenet.Content.Data.Translator
{
    public class ItemTranslator
    {
        public static void Translate(Repository.Item dbItem, DataContract.Item item)
        {
            dbItem.ItemAbstract = item.ItemAbstract;
            dbItem.ItemTitle = item.ItemTitle;
            dbItem.LastUpdated = DateTime.Now;

            if (item.Content != null)
            {
                dbItem.InternalUrl = item.Content.InternalUrl;
                dbItem.ExternalUrl = item.Content.ExternalUrl;
                dbItem.ItemText = item.Content.ItemText;
            }
        }
    }
}