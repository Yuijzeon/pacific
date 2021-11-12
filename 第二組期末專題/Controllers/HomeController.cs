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
            var 全部文章 = new SQL任務(
                "SELECT TOP 7 * FROM [文章] INNER JOIN [圖片] ON [文章].[圖片_FK]=[圖片].[Id] ORDER BY [文章].[Id] DESC"
                ).讀取();
            return Json(全部文章, JsonRequestBehavior.AllowGet);
        }
    }
}