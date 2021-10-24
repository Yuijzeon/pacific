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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection post)
        {
            // 將回傳的東西存進資料庫
            文章 新文章 = new 文章()
            {
                標題 = post["name"],
                作者用戶_FK = Convert.ToInt32(post["name"]),
                內容 = post["name"],
                日期起始 = Convert.ToDateTime(post["name"]),
                日期結束 = Convert.ToDateTime(post["name"]),
                圖片_FK = Convert.ToInt32(post["name"]),
                時段 = post["name"],
                地點 = post["name"],
                接待人數 = Convert.ToInt32(post["name"]),
                類型 = post["name"]
            };
            new 任務InsertInto<文章>(新文章).Set();
            return View();
        }

        public JsonResult GetHashtags()
        {
            return Json(new 任務SelectList<Hashtag>().Get(), JsonRequestBehavior.AllowGet);
        }
    }
}