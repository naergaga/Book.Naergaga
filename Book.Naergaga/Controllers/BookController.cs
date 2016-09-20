using AutoMapper;
using Book.Naergaga.Models.ViewModel;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Controllers
{
    public class BookController : Controller
    {
        IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;
        }

        // GET: Book
        public ActionResult Index(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("index", "Home", null);
            }
            var book = service.GetById(id);
            return View(Mapper.Map<EBookViewModel>(book));
        }

        [HttpGet]
        public FileStreamResult Down(int id)
        {
            var book = service.GetById(id);
            var path = Server.MapPath(book.Path);
            return File(new FileStream(path,FileMode.Open), "application/octet-stream",book.Name+".txt");
        }
    }
}