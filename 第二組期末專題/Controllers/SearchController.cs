using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;
using 第二組期末專題.ViewModels;

namespace 第二組期末專題.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            NameValueCollection name = Request.Params;

            List<文章> 全部文章 = 資料庫.讀取<文章>();

            if (name["user"] != null)
                全部文章.ForEach(文章 => {
                    if (name["user"] != 文章["用戶_FK"] as string) 全部文章.Remove(文章);
                });

            if (name["hashtag"] != null)
                全部文章.ForEach(文章 => {
                    List<Hashtag> Hashtag清單 = 文章.GetHashtag清單();
                    if (!Hashtag清單.Exists(Hashtag => name["hashtag"] == Hashtag.Id.ToString())) 全部文章.Remove(文章);
                });

            if (name["favorite"] != null)
                全部文章.ForEach(文章 => {
                    List<用戶> 收藏用戶清單 = 文章.Get收藏用戶清單();
                    if (!收藏用戶清單.Exists(收藏用戶 => name["favorite"] == 收藏用戶.Id.ToString())) 全部文章.Remove(文章);
                });

            if (name["result"] != null)
                全部文章.ForEach(文章 => {
                    if (!(文章["內容"] as string).Contains(name["result"])) 全部文章.Remove(文章);
                });

            if (name["starttime"] != null)
                全部文章.ForEach(文章 => {
                    if (!(文章["日期起始"] as DateTime? < DateTime.Parse(name["starttime"]))) 全部文章.Remove(文章);
                });

            if (name["endtime"] != null)
                全部文章.ForEach(文章 => {
                    if (!(文章["日期起始"] as DateTime? < DateTime.Parse(name["starttime"]))) 全部文章.Remove(文章);
                });

            //var 用戶Id = name["user"];
            //var HashtagId = name["hashtag"];
            //var 用戶收藏文章Id = name["favorite"];
            //var 用戶Id = name["starttime"];
            //var 用戶Id = name["user"];
            //var 用戶Id = name["user"];

            return View(new Search() {
                搜尋結果 = 資料庫.讀取<文章>()
            });

            
        }

        public ActionResult By(FormCollection form)
        {
            string where = "/Search";
            where += (form["result"] != null) ? $"?result={form["result"]}" : "";
            where += (form["active"] != null) ? $"?active={form["active"]}" : "";
            where += (form["starttime"] != null) ? $"?starttime={form["starttime"]}" : "";
            where += (form["endtime"] != null) ? $"?endtime={form["endtime"]}" : "";
            where += (form["point"] != null) ? $"?point={form["point"]}" : "";
            return Redirect(where);
        }
    }
}