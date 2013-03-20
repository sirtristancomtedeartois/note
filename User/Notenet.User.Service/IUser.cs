using System.Runtime.Serialization;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using Notenet.User.Data.Repository;

namespace Notenet.User.Service
{
    [ServiceContract]
    public interface IUser
    {
        /// <summary>
        /// Get friend list for specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        List<Contract.DataContract.User> GetFriendList(Guid userId);

        /// <summary>
        /// Check if the given userName is already exists in system.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsLegalUserName(string userName);

        [OperationContract]
        int SubscribeUser(Guid friendUserId);

        [OperationContract]
        int PutUserProfile(Contract.DataContract.User user);

        /// <summary>
        /// Get user profile for specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        Contract.DataContract.User GetUser();

        [OperationContract]
        Contract.DataContract.User FindUserByUserId(Guid userId);

        [OperationContract]
        Contract.DataContract.User FindUserByUserName(string userName);

        [OperationContract]
        Contract.DataContract.User FindUserByEmail(string email);
    }
}
