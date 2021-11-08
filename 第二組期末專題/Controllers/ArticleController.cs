using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;
using 第二組期末專題.ViewModels;


namespace 第二組期末專題.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index(int? id, int? pack)
        {
            if (id == null)
                return Redirect("/Search");

            Article 貼文ViewModel = new Article
            {
                文章 = 資料庫.讀取<文章>(id)
            };

            if (pack != null)
                貼文ViewModel.旅程包 = 資料庫.讀取<旅程包>(pack);

            return View(貼文ViewModel);
        }

        public string NewComment(FormCollection form)
        {
            try
            {
                HttpRequestBase post = Request;
                // 將回傳的東西存進資料庫
                評級 新評級 = new 評級();
                新評級["分數"] = post["分數"];
                新評級["評分用戶_FK"] = Session["ID"];
                新評級["文章_FK"] = post["文章_FK"];
                新評級["評論"] = post["評論"];

                資料庫.新增(新評級);
            }
            catch (Exception e)
            {
                return e.ToString();
            }

            return "";
        }
    }
}