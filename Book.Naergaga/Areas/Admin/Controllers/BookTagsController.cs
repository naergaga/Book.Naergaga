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
using Book.Naergaga.Service.ModelService.Interface;
using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.AdminView;
using System.Web.Routing;

namespace Book.Naergaga.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BookTagsController : Controller
    {
        private DataContext db = new DataContext();
        private IBookTagsService service;
        private ITagService service2;

        public BookTagsController(IBookTagsService service, ITagService service2)
        {
            this.service = service;
            this.service2 = service2;
        }

        // GET: Admin/BookTags
        public ActionResult Index(int? currentPage)
        {
            var option = new PageOption
            {
                Asc = false,
                CurrentPage = currentPage ?? 1
            };
            option.PageCount = option.CountPage(service.Count());
            var model = new IndexViewModel<BookTags>
            {
                List = service.GetListFull(option,t=>true,t=>t.BookId),
                Option = option
            };

            return View(model);
        }

        public ActionResult Search(int? currentPage, string keyword)
        {
            PageOption option = new PageOption
            {
                Asc = false,
                CurrentPage = currentPage ?? 1
            };
            option.PageCount = option.CountPage(service.Count(t => t.Book.Name.Contains(keyword)||t.Tag.Name.Contains(keyword)));
            var authors = service.GetListFull(option, t=>t.Book.Name.Contains(keyword) || t.Tag.Name.Contains(keyword),t=>t.BookId);
            var routeData = new RouteValueDictionary();
            routeData.Add("keyword", keyword);
            var model = new IndexViewModel<BookTags>
            {
                List = authors,
                Option = option,
                RouteData = routeData
            };
            return View("Index", model);
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
            ViewData["tags"] = service2.GetAll();
            return View();
        }

        // POST: Admin/BookTags/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int bookId, int[] tag)
        {
            foreach (var item in tag)
            {
                db.BookTags.Add(new BookTags
                {
                    BookId = bookId,
                    TagId = item
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
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
        public ActionResult Delete(int? bookId, int? tagId)
        {
            if (bookId == null || tagId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTags bookTags = db.BookTags.Find(bookId, tagId);
            if (bookTags == null)
            {
                return HttpNotFound();
            }
            return View(bookTags);
        }

        // POST: Admin/BookTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int bookId, int tagId)
        {
            BookTags bookTags = db.BookTags.Find(bookId, tagId);
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
