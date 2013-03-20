using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using endnote.Lib;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace endnote.Handler
{
    /// <summary>
    /// Summary description for GetTreeDataFromDB
    /// </summary>
    public class GetTreeDataFromDB : IHttpHandler
    {
        endnote.Lib.Rules rule = new Lib.Rules();
        private endnoteEntities db = new endnoteEntities();
        Guid userId = Membership.GetUser() != null ? Guid.Parse(Membership.GetUser().ProviderUserKey.ToString()) : Guid.Empty;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sJson = string.Empty;
            if (this.userId != Guid.Empty)
            {
                List<NotebookInfo> notebookList = rule.getNotebookByUserId(this.db, this.userId);
                List<NotebookObject> result = new List<NotebookObject>();
                foreach (NotebookInfo notebook in notebookList)
                {
                    NotebookObject notebookObject = new NotebookObject() { data = notebook.NotebookName, NoteCount = 1 };
                    notebookObject.attr = new Dictionary<string, string>();
                    notebookObject.attr.Add("id", notebook.NotebookId.ToString());
                    notebookObject.icon = "folder";
                    result.Add(notebookObject);
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                sJson = jss.Serialize(result);
            }
            context.Response.Write(sJson);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}