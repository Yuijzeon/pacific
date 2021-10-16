using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(int? id, int? post)
        {
            if (id == null)
                return Redirect("/Search");

            文章 此文章 = new Select文章ById((int)id).Get();

            if (此文章 == null)
                return Redirect("/Search");
            else
                ViewBag.文章 = 此文章;

            if (post != null)
                ViewBag.旅程包 = new Select旅程包ById((int)post).Get();

            return View();
        }

        public ActionResult article()
        {
            return View();
        }
    }
}