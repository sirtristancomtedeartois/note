using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using endnote.Lib;
using System.Web.Security;
using System.Data.Objects.DataClasses;
using endnote.Handler;
using System.Web.Script.Serialization;

namespace endnote.Controllers
{
    public class UserController : Controller
    {
        private endnoteEntities db = new endnoteEntities();
        Guid userId = Membership.GetUser() != null ? Guid.Parse(Membership.GetUser().ProviderUserKey.ToString()) : Guid.Empty;
        private endnote.Lib.Rules rule = new Rules();

        //
        // GET: /User/

        public ActionResult Index()
        {
            List<NotebookInfo> blogList = this.rule.getNotebookByUserId(this.db, this.userId);
            Dictionary<DateTime, EntityObject> list = new Dictionary<DateTime,EntityObject>();
            List<EntityObject> result = new List<EntityObject>();
            ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
            return View(result);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(Guid userId)
        {
            aspnet_Users user = db.aspnet_Users.Single(obj => obj.UserId == userId);
            ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
            return View(user);
        }

        public ActionResult Home()
        {
            if (this.userId != Guid.Empty)
            {
                aspnet_Users user = db.aspnet_Users.Single(obj => obj.UserId == userId);
                ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
                return View(user);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Profiles(Guid userId)
        {
            var blogs = db.NoteInfo.Where(obj => obj.UserId == userId);
            ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
            return View(blogs.ToList());
        }

        public ActionResult Menu(Guid userId)
        {
            aspnet_Users user = db.aspnet_Users.Single(obj => obj.UserId == userId);
            return View(user);
        }

        public PartialViewResult NewNotebook(NotebookInfo notebook)
        {
            if (ModelState.IsValid)
            {
                notebook.NotebookId= Guid.NewGuid();
                notebook.UserId = Guid.Parse(Membership.GetUser().ProviderUserKey.ToString());
                db.NotebookInfo.AddObject(notebook);
                db.SaveChanges();
                var notebookList = db.NotebookInfo.Where(obj => obj.UserId == userId);
                ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
                return PartialView("_Profiles", notebookList.ToList());
            }

            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", notebook.UserId);
            return PartialView(notebook);
        }

        [HttpPost]
        [ValidateInput(false)]
        public PartialViewResult NewNote(NoteInfo note)
        {
            if (ModelState.IsValid)
            {
                if (note.NoteId == Guid.Empty)
                {
                    note.NoteId = Guid.NewGuid();
                    note.UserId = Guid.Parse(Membership.GetUser().ProviderUserKey.ToString());
                    note.NotebookInfo = db.NotebookInfo.First(obj => obj.NotebookId == note.NotebookId.Value);
                    db.NoteInfo.AddObject(note);
                }
                db.SaveChanges();
                var notebookList = db.NotebookInfo.Where(obj => obj.UserId == userId);
                ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
                return PartialView("_Profiles", notebookList.ToList());
            }

            //ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", note.UserId);
            
            return PartialView(note);
        }

        public PartialViewResult DeleteNote(Guid id)
        {
            NoteInfo blog = db.NoteInfo.Single(b => b.NoteId == id);
            db.NoteInfo.DeleteObject(blog);
            db.SaveChanges();
            var blogs = db.NoteInfo.Where(obj => obj.UserId == userId);
            ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
            return PartialView("_Profiles", blogs.ToList()); 
        }

        [HttpPost, ActionName("CommentOffer")]
        public ActionResult CommentOffer(Guid id)
        {
            return View();
        }

        [HttpPost, ActionName("ForwardBlog")]
        public ActionResult ForwardBlog(Guid id)
        {
            return View();
        }

        public PartialViewResult Unfollow(Guid friendUserId)
        {
            if (db.NoteShare.Count(obj => obj.UserId == userId) > 0)
            {
                NoteShare friend = db.NoteShare.Single(obj => obj.UserId == userId);
                friend.Status = 0;
                db.SaveChanges();
            }

            ViewBag.User = db.aspnet_Users.Single(obj => obj.UserId == userId);
            return PartialView("_Follows");
        }
    }
}
