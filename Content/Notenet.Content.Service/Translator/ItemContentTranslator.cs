using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Notenet.Content.DataContract;
using Notenet.Content.Service.Data;

namespace Notenet.Content.Service.Translator
{
    class ItemContentTranslator
    {
        internal static ItemContent Translate(Item item)
        {
            return new ItemContent(item.ExternalUrl, item.InternalUrl, item.ItemText);
        }
    }
}