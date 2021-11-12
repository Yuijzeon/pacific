using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoGoShare.Models;

namespace GoGoShare.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            NameValueCollection name = Request.Params;

            List<文章> 全部文章 = new SQL任務().文章.ToList();

            if (name["user"] != null)
                全部文章.RemoveAll(文章 => {
                    return 文章.作者用戶_FK.ToString() != name["user"];
                });

            if (name["hashtag"] != null)
                全部文章.RemoveAll(文章 => {
                    List<Hashtag> Hashtag清單 = 文章.Hashtag.ToList();
                    return !Hashtag清單.Exists(Hashtag => Hashtag.Id.ToString() == name["hashtag"]);
                });

            if (name["favorite"] != null)
                全部文章.RemoveAll(文章 => {
                    List<用戶> 收藏用戶清單 = 文章.用戶.ToList();
                    return !收藏用戶清單.Exists(收藏用戶 => 收藏用戶.Id.ToString() == name["favorite"]);
                });


            if (name["result"] != null)
                全部文章.RemoveAll(文章 => {
                    bool 關鍵字符合 = false;
                    關鍵字符合 = 文章.標題.Contains(name["result"])
                              || 文章.內容.Contains(name["result"]);
                    return !關鍵字符合;
                });

            if (name["active"] != null)
                全部文章.RemoveAll(文章 => {
                    var AAA = 文章.類型;
                    return !文章.類型.Contains(name["active"]);
                });

            if (name["starttime"] != null)
                全部文章.RemoveAll(文章 => {
                    return !(文章.日期起始 > Convert.ToDateTime(name["starttime"].ToString()));
                });

            if (name["endtime"] != null)
                全部文章.RemoveAll(文章 => {
                    return !(文章.日期結束 < Convert.ToDateTime(name["endtime"].ToString()));
                });

            if (name["point"] != null)
                全部文章.RemoveAll(文章 => {
                    return !(文章.點數 <= Convert.ToInt32(name["point"]));
                });

            List<文章> 暫時的輪播用文章列表 = new SQL任務().文章.Where(x => x.Id == 1 || x.Id == 6 || x.Id == 7).ToList();

            Search 要傳的ViewModel = new Search()
            {
                輪播文章 = 暫時的輪播用文章列表,
                搜尋結果 = 全部文章
            };

            return View(要傳的ViewModel);
        }

        public ActionResult By(FormCollection form)
        {
            string where = "/Search?";
            where += 是空嗎(form["result"]) ? "" : $"result={ form["result"]}&";
            where += 是空嗎(form["active"]) ? "" : $"active={form["active"]}&";
            where += 是空嗎(form["starttime"]) ? "" : $"starttime={form["starttime"]}&";
            where += 是空嗎(form["endtime"]) ? "" : $"endtime={form["endtime"]}&";
            where += 是空嗎(form["point"]) ? "" : $"point={form["point"]}&";
            return Redirect(where.TrimEnd('&') + "#搜尋");

            bool 是空嗎(string input)
            {
                return string.IsNullOrEmpty(input) || (input == "null");
            };
        }

        //用戶新增收藏
        public ActionResult 加入收藏(int? id)
        {
            文章 用戶Favorite = new SQL任務().文章.Find(id);
            new SQL任務().用戶.Find(Session["ID"]).文章.Add(用戶Favorite);
            return View("");
        }
    }
}