using Book.Naergaga.Models.Common;
using Book.Naergaga.Models.PublicView;
using Book.Naergaga.Service.ModelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Controllers
{
    public class HomeController : Controller
    {
        IBookService service1;
        PageOption option = new PageOption();

        public HomeController(IBookService service)
        {
            this.service1 = service;
            //默认降序
            option.Asc = false;
        }

        public ActionResult Index()
        {
            var books = service1.GetPage(option,c=>c.PostTime);

            var model = new HomeIndexViewModel
            {
                Books = books
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}