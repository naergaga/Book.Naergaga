using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("Error")]
        public ActionResult Index()
        {
            return View();
        }
    }
}