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
            文章 新文章 = new 文章();
            新文章["標題"] = "";
            新文章["內容"] = "";
            新文章["日期起始"] = DateTime.Now;
            新文章["日期結束"] = DateTime.Now;
            新文章["圖片_FK"] = 1;
            新文章["地點"] = "";
            新文章["接待人數"] = 1;
            新文章["類型"] = "";
            新文章["點數"] = 0;

            return View(新文章);
        }

        public ActionResult Edit(int id)
        {
            var post = 資料庫.讀取<文章>(id);

            return View("Index", post);
        }

        public string New()
        {
            var 作者 = 資料庫.讀取<用戶>(Session["ID"]);
            圖片 image = new 圖片() { ["Id"] = 1 };

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var 副檔名點索引 = file.FileName.LastIndexOf('.');
                if (副檔名點索引 == -1) continue;
                var 檔名 = DateTime.Now.ToString("yyyyMMddhhmmss") + file.FileName.Substring(副檔名點索引);

                file.SaveAs(Server.MapPath("~/Content/images/uploads/") + 檔名);
                資料庫.新增<圖片>(new 圖片() {
                    ["上傳用戶_FK"] = Session["ID"],
                    ["路徑"] = "uploads/" + 檔名
                });

                image = 作者.Get最新圖片();
            }

            try
            {
                HttpRequestBase post = Request;
                // 將回傳的東西存進資料庫
                文章 新文章 = new 文章();
                新文章["標題"] = post["pTitle"];
                新文章["作者用戶_FK"] = Session["ID"];
                新文章["內容"] = post["pContent"];
                新文章["日期起始"] = Convert.ToDateTime(post["pStartDate"]);
                新文章["日期結束"] = Convert.ToDateTime(post["pEndDate"]);
                新文章["圖片_FK"] = image["Id"];
                新文章["地點"] = post["pAddress"];
                新文章["接待人數"] = Convert.ToInt32(post["pplNumber"]);
                新文章["類型"] = post["ptype"];
                新文章["點數"] = Convert.ToInt32(post["pPoint"]);
                新文章["文章註冊時間"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                資料庫.新增<文章>(新文章);

                var article = 作者.Get最新文章();

                string[] hashtagIds = post["hashtags"].Split(',');

                foreach (string hashtagId in hashtagIds)
                {
                    資料庫.新增(new 文章Hashtag()
                    {
                        ["文章_FK"] = article["Id"],
                        ["Hashtag_FK"] = hashtagId
                    });
                }
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

        public JsonResult DeletePost(int id)
        {
            new 資料庫任務("DELETE FROM [用戶] WHERE [Id]=@ID").注入參數by(new { ID = id }).Set();

            var 全部用戶 = 資料庫.讀取<用戶>();
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }
    }
}