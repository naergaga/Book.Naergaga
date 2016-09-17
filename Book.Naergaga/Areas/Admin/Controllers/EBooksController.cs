﻿using System;
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
    public class BooksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/EBooks
        public ActionResult Index()
        {
            var eBooks = db.EBooks.Include(e => e.Author).Include(e => e.Category);
            return View(eBooks.ToList());
        }

        // GET: Admin/EBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EBook eBook = db.EBooks.Find(id);
            if (eBook == null)
            {
                return HttpNotFound();
            }
            return View(eBook);
        }

        // GET: Admin/EBooks/Create
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.Authors, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/EBooks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,authorId,CategoryId,Name,PostTime,Description,Path")] EBook eBook)
        {
            if (ModelState.IsValid)
            {
                db.EBooks.Add(eBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.Authors, "Id", "Name", eBook.authorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", eBook.CategoryId);
            return View(eBook);
        }

        // GET: Admin/EBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EBook eBook = db.EBooks.Find(id);
            if (eBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.Authors, "Id", "Name", eBook.authorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", eBook.CategoryId);
            return View(eBook);
        }

        // POST: Admin/EBooks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,authorId,CategoryId,Name,PostTime,Description,Path")] EBook eBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.Authors, "Id", "Name", eBook.authorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", eBook.CategoryId);
            return View(eBook);
        }

        // GET: Admin/EBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EBook eBook = db.EBooks.Find(id);
            if (eBook == null)
            {
                return HttpNotFound();
            }
            return View(eBook);
        }

        // POST: Admin/EBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EBook eBook = db.EBooks.Find(id);
            db.EBooks.Remove(eBook);
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
