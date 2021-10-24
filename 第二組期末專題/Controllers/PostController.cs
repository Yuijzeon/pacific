using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;
using 第二組期末專題.ViewModels;

namespace 第二組期末專題.Controllers
{
    public class PostController : Controller
    {
        // GET: Post

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(FormCollection post)
        {
            var sss = post[""];
            return "<html></html>";
        }
    }
}