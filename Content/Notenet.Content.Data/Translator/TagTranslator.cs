using Notenet.Content.Data.Repository;
using Notenet.Content.DataContract;

namespace Notenet.Content.Data.Translator
{
    public class TagTranslator
    {
        public static Tag Translate(ItemTag tag)
        {
            return new Tag(tag.Tag, tag.ItemID);
        }
    }
}