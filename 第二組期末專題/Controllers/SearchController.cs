using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            string str = "SELECT * FROM [文章]";
            任務SelectList<文章> 新任務 = new 任務SelectList<文章>(str);

            List<文章> 文章列表 = 新任務.Get();

            return View(文章列表);
        }
    }
}