using System;
using System.Collections.Generic;
using System.ServiceModel;
using Notenet.Content.DataContract;

namespace Notenet.Content.Service
{
    [ServiceContract]
    public interface IContent
    {
        [OperationContract]
        ICollection<Tag> GetUserTagList();

        [OperationContract]
        ICollection<DataContract.Item> GetUserTagItemList(string Tag);

        [OperationContract]
        ItemContent GetUserItemContent(Guid ItemID);

        [OperationContract]
        int PutItem(DataContract.Item Item);
    }
}
