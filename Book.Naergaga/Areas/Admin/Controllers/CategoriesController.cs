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

namespace Book.Naergaga.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ICategoryService service;

        public CategoriesController(ICategoryService service)
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
            var model = new IndexViewModel<Category>
            {
                List = service.GetPage(option,c=>c.Id),
                Option = option
            };

            return View(model);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = service.GetById(id??0);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            var model = new CategoryEditViewModel
            {
                Category = new Category(),
                IsCreate = true
            };
            return PartialView("Edit",model);
        }

        // POST: Admin/Categories/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                service.Create(category);
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
            var category = service.GetById(id??0);
            if (category == null)
            {
                return HttpNotFound();
            }

            var model = new CategoryEditViewModel
            {
                Category = category,
                IsCreate = false
            };
            return PartialView(model);
        }

        // POST: Admin/Categories/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                service.Update(category);
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
            Category category = service.GetById(id??0);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CategoryViewModel>(category));
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
