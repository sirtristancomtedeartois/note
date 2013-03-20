using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Security;
using System.Runtime.Serialization;

namespace Notenet.Security.DataContract
{
    [DataContract]
    public class NotenetIdentity : IIdentity
    {
        public static string AuthType = "NotenetAuthentication";

        [DataMember]
        public string Name
        {
            get;
            private set;
        }

        [DataMember]
        public Guid UID
        {
            get;
            private set;
        }

        [DataMember]
        public string AuthenticationType
        {
            get;
            private set;
        }

        [DataMember]
        public bool IsAuthenticated
        {
            get;
            private set;
        }

        public NotenetIdentity(string name, Guid userID, string authType, bool isAuthenticated)
        {
            this.Name = name;
            this.UID = userID;
            this.AuthenticationType = authType;
            this.IsAuthenticated = isAuthenticated;
        }
    }
}
