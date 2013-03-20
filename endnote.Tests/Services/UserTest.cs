using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace endnote.Tests.Services
{
    [TestClass]
    public class UserTest
    {
        [TestCategory("UserServiceTests"), TestMethod]
        public void TestGetUserProfile()
        {
            string url = String.Concat(Common.userDomain, "GetUserProfile");
            string parameters = "userId=aaf9a5a7-1f18-4a2d-b108-3ba3a978bdf6";
            //Assert.IsNotNull(, "User shouldn't be null!");
        }

        [TestCategory("UserServiceTests"), TestMethod]
        public void TestGetFriendList()
        {
            
            Guid userId = new Guid();
            string tag = string.Empty;
            //UserServiceReference.UserClient client = new UserServiceReference.UserClient();
            //UserServiceReference.aspnet_Users[] friendList = client.GetFriendList(userId);
            //Assert.AreNotEqual(0, friendList.Length, "Should have at least 1 friend");
        }

        [Description("Test if the user name is legal"), TestMethod]
        public void TestIsLegalUserID()
        {
            //Guid userId = new Guid();
            //string tag = string.Empty;
            //UserServiceReference.UserClient client = new UserServiceReference.UserClient();
            //bool isLegalUserId = client.IsLegalUserID(userId);
            //Assert.IsTrue(isLegalUserId, "Should be legal user id");
        }
    }
}
