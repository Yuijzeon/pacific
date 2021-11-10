using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorite
        public ActionResult Index(int? id)
        {
            List<文章> 文章 = 資料庫.讀取<用戶>(id).Get收藏文章清單();
            return View(文章);
        }

        
}