using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;
using 第二組期末專題.ViewModels;

namespace 第二組期末專題.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index(int? id, int? pack)
        {
            if (id == null)
                return Redirect("/Search");

            Post 貼文 = new Post
            {
                文章 = new 任務SelectById<文章>((int)id).Get()
            };

            if (pack != null)
                貼文.旅程包 = new 任務SelectById<旅程包>((int)pack).Get();


            return View(貼文);
        }
    }
}