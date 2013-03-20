using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Notenet.User.Contract.DataContract
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid userID { get; private set; }

        [DataMember]
        public string UserName { get; private set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public string NickName { get; set; }

        [DataMember]
        public string RealName { get; set; }

        public User(Guid userID, string userName)
        {
            this.userID = userID;
            this.UserName= userName;
        }
    }
}
