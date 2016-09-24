using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Service.ModelService.Interface;
using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.AdminView;
using AutoMapper;
using Book.Naergaga.Models.ViewModel;
using System.Web.Routing;

namespace Book.Naergaga.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class AuthorController : Controller
    {
        private IAuthorService service;

        public AuthorController(IAuthorService service,PageOption option)
        {
            this.service = service;
        }

        // GET: Admin/Categories
        public ActionResult Index(int? currentPage)
        {
            var option = new PageOption
            {
                Asc = false,
                CurrentPage = currentPage ?? 1
            };
            option.PageCount = option.CountPage(service.Count());
            var model = new IndexViewModel<Author>
            {
                List = service.GetPage(option,c=>c.Id),
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
            option.PageCount = option.CountPage(service.Count(t => t.Name.Contains(keyword)));
            var authors = service.GetPage(option, t => t.Name.Contains(keyword), t => t.Id);
            var routeData = new RouteValueDictionary();
            routeData.Add("keyword", keyword);
            var model = new IndexViewModel<Author>
            {
                List = authors,
                Option = option,
                RouteData = routeData
            };
            return View("Index", model);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author Author = service.GetById(id??0);
            if (Author == null)
            {
                return HttpNotFound();
            }
            return View(Author);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            var model = new AuthorEditViewModel
            {
                Author = new Author(),
                IsCreate = true
            };
            return PartialView("Edit",model);
        }

        // POST: Admin/Categories/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,RealName,Description")] Author Author)
        {
            if (ModelState.IsValid)
            {
                service.Create(Author);
                return RedirectToAction("Index");
            }
            //TODO:error occur
            return null;
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Author = service.GetById(id??0);
            if (Author == null)
            {
                return HttpNotFound();
            }

            var model = new AuthorEditViewModel
            {
                Author = Author,
                IsCreate = false
            };
            return PartialView(model);
        }

        // POST: Admin/Categories/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,RealName,Description")] Author Author)
        {
            if (ModelState.IsValid)
            {
                service.Update(Author);
                return RedirectToAction("Index");
            }
            //TODO:error occur
            return null;
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author Author = service.GetById(id??0);
            if (Author == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AuthorViewModel>(Author));
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (service.Delete(id))
                return RedirectToAction("Index");
            else
                //TODO:error occor
                return null;
        }
    }
}
