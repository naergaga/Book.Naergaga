using AutoMapper;
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
    public class TagController : Controller
    {
        private ITagService service;

        public TagController(ITagService service)
        {
            this.service = service;
        }

        // GET: Admin/Tag
        public ActionResult Index()
        {
            var tags = service.GetAll();
            return View(Mapper.Map<List<TagViewModel>>(tags));
        }

        // GET: Admin/Tag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Tag/Create
        public ActionResult Create()
        {
            return PartialView(new Tag());
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
            return View(service.GetById(id));
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            try
            {
                service.Update(tag);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            try
            {
                service.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
