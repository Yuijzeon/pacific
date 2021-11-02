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

            Post 貼文ViewModel = new Post
            {
                文章 = 資料庫.讀取<文章>(id)
            };

            if (pack != null)
                貼文ViewModel.旅程包 = 資料庫.讀取<旅程包>(pack);


            return View(貼文ViewModel);
        }
    }
}