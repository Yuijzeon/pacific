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

            string 內文 = "";

            foreach (文章 一文章 in 文章列表)
            {
                內文 += "<div class=\"col-md-4 ftco-animate\"><div class=\"project-wrap\"><a href=\"#\" class=\"img\" style=\"background-image: url(../../Content/images/destination-1.jpg);\"><!--<span class=\"price\">$550/person</span>--></a><div class=\"text p-4\"><span class=\"days\">8 Days Tour</span><h3><a href=\"#\">" + @一文章.標題 + "</a></h3><p class=\"location\"><span class=\"fa fa-map-marker\"></span> Banaue, Ifugao, Philippines</p><ul><li><span class=\"flaticon-shower\"></span>2</li><li><span class=\"flaticon-king-size\"></span>3</li><li><span class=\"flaticon-mountains\"></span>" + @一文章.Get作者().名字 + "</li></ul></div></div></div>";
            }

            ViewBag.文章列表 = 內文;

            return View();
        }
    }
}