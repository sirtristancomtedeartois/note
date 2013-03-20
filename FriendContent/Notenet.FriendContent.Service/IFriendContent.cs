using System;
using System.Collections.Generic;
using System.ServiceModel;
using Notenet.Content.DataContract;

namespace Notenet.FriendContent.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFriendContent
    {
        [OperationContract]
        ICollection<Tag> GetFriendTagList(Guid FriendID);

        [OperationContract]
        ICollection<Item> GetFriendTagItemList(Guid FriendID, string Tag);

        [OperationContract]
        ItemContent GetFriendItemContent(Guid FriendID, Guid ItemID);

        // TODO: Add your service operations here
    }
}
