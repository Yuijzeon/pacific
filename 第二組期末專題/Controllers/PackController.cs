using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class PackController : Controller
    {
        // GET: Pack
        public ActionResult Index()
        {
            if (!(Session["ID"] is int))
                return Redirect("/SignUp");

            return View(資料庫.讀取<用戶>(Session["ID"]));
        }

        public ActionResult New()
        {
            HttpRequestBase post = Request;
            // 將回傳的東西存進資料庫
            旅程包 新旅程包 = new 旅程包();
            新旅程包["標題"] = post["pTitle"];
            新旅程包["作者用戶_FK"] = Session["ID"];
            新旅程包["描述"] = post["pContent"];

            資料庫.新增<旅程包>(新旅程包);

            var pack = 資料庫.讀取<用戶>(Session["ID"]).Get最新旅程包();

            string[] postIds = post["packPosts"].Split(',');

            foreach (string postId in postIds)
            {
                資料庫.新增<旅程包Link>
            }

            return Redirect("/Search?pack=" + pack["Id"]);
        }
    }
}