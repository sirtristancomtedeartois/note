using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Notenet.Content.DataContract;
using Notenet.Content.Service.Data;

namespace Notenet.Content.Service.Translator
{
    class TagTranslator
    {
        internal static Tag Translate(ItemTag tag)
        {
            return new Tag(tag.Tag, tag.ItemID);
        }
    }
}