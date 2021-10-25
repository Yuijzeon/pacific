using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetJourneys()
        {
            var 全部文章 = new 資料庫任務("SELECT [文章].[Id], [標題], [內容], [日期起始], [日期結束], [路徑]" +
                " FROM [文章] INNER JOIN [圖片] ON [文章].[圖片_FK]=[圖片].[Id]").Get();
            return Json(全部文章, JsonRequestBehavior.AllowGet);
        }
    }
}