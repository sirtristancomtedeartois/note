using Notenet.Content.DataContract;

namespace Notenet.Content.Data.Translator
{
    public class ItemContentTranslator
    {
        public static ItemContent Translate(Repository.Item item)
        {
            return new ItemContent(item.ExternalUrl, item.InternalUrl, item.ItemText);
        }
    }
}