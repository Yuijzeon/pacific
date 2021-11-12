using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoGoShare.Models;

namespace GoGoShare.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorite
        public ActionResult Index(int? id)
        {
            List<文章> 文章 = new SQL任務().用戶.Find(id).文章.ToList();
            return View(文章);
        }

    }  
}