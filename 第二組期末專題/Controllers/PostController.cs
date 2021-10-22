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
        public ActionResult Index(int? id, int? pack)
        {
            if (id == null)
                return Redirect("/Search");

            Post 貼文 = new Post();
            貼文.文章 = new 任務SelectById<文章>((int)id).Get();

            if (pack != null)
                貼文.旅程包 = new 任務SelectById<旅程包>((int)pack).Get();
            

            return View(貼文);
        }

        public ActionResult article()
        {
            return View();
        }
    }
}