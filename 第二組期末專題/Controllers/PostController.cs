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

            文章 此文章 = new 讀取文章任務().GetById((int)id);

            if (此文章 == null)
                return Redirect("/Search");
            else
                ViewBag.文章 = 此文章;

            if (post != null)
                ViewBag.文章.所屬旅程包 = new 讀取旅程包任務().GetById((int)post);

            return View();
        }

        public ActionResult article()
        {
            return View();
        }
    }
}