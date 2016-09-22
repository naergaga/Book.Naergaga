using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Naergaga.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public FileStreamResult Back()
        {
            var index = DateTime.Now.DayOfYear % 7+1;
            var path = Server.MapPath("~/App_Data/img/" + index + ".jpg");
            return File(new FileStream(path,FileMode.Open), "image/jpeg");
        }
    }
}