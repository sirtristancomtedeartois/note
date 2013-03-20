using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace endnote.Lib
{
    public class Rules
    {
        public endnote.Lib.endnoteEntities entity = new endnoteEntities();

        public List<NoteInfo> getNoteByUserId(endnoteEntities db, Guid userId)
        {
            return db.NoteInfo.Where(obj => obj.UserId == userId).ToList();
        }

        public List<NoteInfo> getNoteByNotebookId(endnoteEntities db, Guid notebookId)
        {
            return db.NoteInfo.Where(obj => obj.NotebookId == notebookId).ToList();
        }

        public List<NotebookInfo> getNotebookByUserId(endnoteEntities db, Guid userId)
        {
            return db.NotebookInfo.Where(obj => obj.UserId == userId).ToList();
        }


        public List<aspnet_Users> getFriendList(endnoteEntities db, Guid userId)
        {
            List<aspnet_Users> userList = new List<aspnet_Users>();
            List<FriendInfo> friendList = db.FriendInfo.Where(obj => obj.UserID1 == userId).ToList();
            foreach (FriendInfo friend in friendList)
            {
                userList.Add(db.aspnet_Users.First(obj => obj.UserId == friend.UserID2));
            }
            return userList;
        }
    }
}
