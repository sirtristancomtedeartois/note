using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Notenet.Content.DataContract;
using Notenet.FriendContent.Service.Data;

namespace Notenet.FriendContent.Service.Translator
{
    class ListItemTranslator
    {
        internal static ListItem Translate(Item item)
        {
            return new ListItem(item.ItemID, item.ItemTitle, item.ItemAbstract, item.CreatedDate, item.LastUpdated);
        }
    }
}