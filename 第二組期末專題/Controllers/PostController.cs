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
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.文章 = new 貼文();
            }
            else
            {
                ViewBag.文章 = Teamdb2.Get貼文ById((int)id);
            }
            
            return View();
        }

        public ActionResult article()
        {
            return View();
        }
    }
}