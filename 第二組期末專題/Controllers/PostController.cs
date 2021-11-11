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
                文章 新文章 = new 文章();
                新文章["標題"] = post["pTitle"];
                新文章["作者用戶_FK"] = Session["ID"];
                新文章["內容"] = post["pContent"];
                新文章["日期起始"] = Convert.ToDateTime(post["startDate"] + " " + post["startTime"]);
                新文章["日期結束"] = Convert.ToDateTime(post["endDate"] + " " + post["endTime"]);
                新文章["圖片_FK"] = 1;
                新文章["地點"] = post["pAddress"];
                新文章["接待人數"] = Convert.ToInt32(post["pplNumber"]);
                新文章["類型"] = post["ptype"];
                新文章["點數"] = Convert.ToInt32(post["pPoint"]);
                新文章["文章註冊時間"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                資料庫.新增<文章>(新文章);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return null;
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
                    ["名稱"] = post["名稱"],
                    ["類別"] = post["類別"]
                };

                new 任務InsertInto<Hashtag>(新Hashtag).Set();

                result = 資料庫.讀取<Hashtag>("WHERE [名稱]=@NAME", new { NAME = post["名稱"] });
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}