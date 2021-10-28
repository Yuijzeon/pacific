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

        public string New()
        {
            try
            {
                HttpRequestBase post = Request;
                // 將回傳的東西存進資料庫
                文章 新文章 = new 文章()
                {
                    標題 = post["title"],
                    //作者用戶_FK = Convert.ToInt32(post["name"]),
                    內容 = post["about"],
                    日期起始 = Convert.ToDateTime(post["startDate"]),
                    日期結束 = Convert.ToDateTime(post["endDate"]),
                    //圖片_FK = Convert.ToInt32(post["name"]),
                    //時段 = post["name"],
                    地點 = post["display_name"],
                    接待人數 = Convert.ToInt32(post["pplNumber"]),
                    類型 = post["name"]
                };
                new 任務InsertInto<文章>(新文章).Set();
            }
            catch (Exception e)
            {
                return e.ToString();
            }

            return "增加成功";
        }

        public JsonResult GetHashtags()
        {
            return Json(new 任務SelectList<Hashtag>().Get(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddHashtag()
        {
            object result;
            try
            {
                HttpRequestBase post = Request;
                // 將回傳的東西存進資料庫
                Hashtag 新Hashtag = new Hashtag()
                {
                    名稱 = post["名稱"],
                    類別 = post["類別"]
                };
                new 任務InsertInto<Hashtag>(新Hashtag).Set();

                result = new 資料庫任務("SELECT * FROM [Hashtag] WHERE [名稱]=@NAME").注入參數by(new {NAME = post["名稱"] }).Get();
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}