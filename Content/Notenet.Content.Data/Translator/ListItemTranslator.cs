
namespace Notenet.Content.Data.Translator
{
    public class ListItemTranslator
    {
        public static DataContract.Item Translate(Repository.Item item)
        {
            return new DataContract.Item(item.ItemID, item.ItemTitle, item.ItemAbstract, item.CreatedDate, item.LastUpdated);
        }
    }
}