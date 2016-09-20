using AutoMapper;
using Book.Naergaga.Models.AdminView;
using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.Entity;
using Book.Naergaga.Models.ViewModel;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Areas.Admin.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private ITagService service;
        private PageOption option;

        public TagController(ITagService service, PageOption option)
        {
            this.service = service;
            this.option = option;
            this.option.Asc = false;
        }

        // GET: Admin/Tag
        public ActionResult Index(int? currentPage)
        {
            option.CurrentPage = currentPage ?? 1;
            option.PageCount = service.CountPage(option.PageSize);
            var tags = service.GetPage(option, t => t.Id);
            var model = new TagIndexViewModel
            {
                Tags = tags,
                Option = option
            };
            return View(model);
        }

        // GET: Admin/Tag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Tag/Create
        public ActionResult Create()
        {
            var model = new TagEditViewModel
            {
                IsCreate = true,
                Tag = new Tag()
            };
            return PartialView("Edit",model);
        }

        // POST: Admin/Tag/Create
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                service.Create(tag);
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Tag/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new TagEditViewModel {
                IsCreate = false,
                Tag = service.GetById(id)
            };
            return View(model);
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (service.Update(tag))
                return RedirectToAction("Index");
            else
                //TODO: error occur
                return null;
        }

        // GET: Admin/Tag/Delete/5
        public ActionResult Delete(int id)
        {
            var tag = service.GetById(id);
            return PartialView(Mapper.Map<TagViewModel>(tag));
        }

        // POST: Admin/Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (service.Delete(id))
                return RedirectToAction("Index");
            else
                //TODO: error occur
                return null;
        }
    }
}
