using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.EntityContext;

namespace Book.Naergaga.Areas.Admin.Controllers
{
    public class BookTagsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/BookTags
        public ActionResult Index()
        {
            var bookTags = db.BookTags.Include(b => b.Book).Include(b => b.Tag);
            return View(bookTags.ToList());
        }

        // GET: Admin/BookTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTags bookTags = db.BookTags.Find(id);
            if (bookTags == null)
            {
                return HttpNotFound();
            }
            return View(bookTags);
        }

        // GET: Admin/BookTags/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.EBooks, "Id", "Name");
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name");
            return View();
        }

        // POST: Admin/BookTags/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookId,TagId")] BookTags bookTags)
        {
            if (ModelState.IsValid)
            {
                db.BookTags.Add(bookTags);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.EBooks, "Id", "Name", bookTags.BookId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", bookTags.TagId);
            return View(bookTags);
        }

        // GET: Admin/BookTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTags bookTags = db.BookTags.Find(id);
            if (bookTags == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.EBooks, "Id", "Name", bookTags.BookId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", bookTags.TagId);
            return View(bookTags);
        }

        // POST: Admin/BookTags/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookId,TagId")] BookTags bookTags)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTags).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.EBooks, "Id", "Name", bookTags.BookId);
            ViewBag.TagId = new SelectList(db.Tags, "Id", "Name", bookTags.TagId);
            return View(bookTags);
        }

        // GET: Admin/BookTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTags bookTags = db.BookTags.Find(id);
            if (bookTags == null)
            {
                return HttpNotFound();
            }
            return View(bookTags);
        }

        // POST: Admin/BookTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookTags bookTags = db.BookTags.Find(id);
            db.BookTags.Remove(bookTags);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
