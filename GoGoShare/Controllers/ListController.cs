using GoGoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoGoShare.Controllers
{
    public class ListController : Controller
    {
        // GET: MyList
        public ActionResult Index()
        {
            return Redirect("~/List/MyPost");
        }

        public ActionResult MyPost()
        {
            if (!(Session["ID"] is int))
                return Redirect("/SignUp");

            用戶 user = new SQL任務().用戶.Find((int)Session["ID"]);
            return View(new ControlPanelPage(user));
        }

        public ActionResult Favorite()
        {
            if (!(Session["ID"] is int))
                return Redirect("/SignUp");

            List<文章> model = new SQL任務().用戶.Find((int)Session["ID"]).文章.OrderByDescending(p => p.Id).ToList();
            return View(model);
        }

        public ActionResult Test()
        {
            return View(new ControlPanelPage());
        }

        public string DeletePost(int id)
        {
            try
            {
                SQL任務 刪除任務 = new SQL任務();
                文章 文章 = 刪除任務.文章.Find(id);

                文章.Hashtag.Clear();
                文章.用戶.Clear();

                var 全部旅程包link = 刪除任務.旅程包_link.Where(x => x.文章_FK == id);
                foreach (var 旅程包link in 全部旅程包link)
                {
                    刪除任務.旅程包_link.Remove(旅程包link);
                }

                var 全部評級 = 刪除任務.評級.Where(x => x.文章_FK == id);
                foreach (var 評級 in 全部評級)
                {
                    刪除任務.評級.Remove(評級);
                }

                刪除任務.文章.Remove(文章);
                刪除任務.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return null;
        }

        public string DeleteUser(int id)
        {
            try
            {
                SQL任務 刪除任務 = new SQL任務();
                用戶 用戶 = 刪除任務.用戶.Find(id);

                用戶.Hashtag.Clear();
                用戶.旅程包.Clear();
                用戶.文章.Clear();
                用戶.評級.Clear();

                刪除任務.用戶.Remove(用戶);
                刪除任務.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return null;
        }

        public string DeleteImage(int id)
        {
            try
            {
                SQL任務 刪除任務 = new SQL任務();
                圖片 圖片 = 刪除任務.圖片.Find(id);

                foreach (var 文章 in 刪除任務.文章)
                {
                    if (文章.圖片_FK == id)
                        文章.圖片_FK = null;
                }

                System.IO.File.Delete(Server.MapPath("/images/" + 圖片.路徑));

                刪除任務.圖片.Remove(圖片);
                刪除任務.SaveChanges();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return null;
        }

        public ActionResult SearchMyArticle()
        {
            var name = Request.Params;

            try
            {
                var 用戶創作文章 = new SQL任務().用戶.Find((int)Session["ID"]).Get創作文章清單();

                if (!string.IsNullOrEmpty(name["result"]))
                {
                    用戶創作文章 = 用戶創作文章.Where(x => x.標題.Contains(name["result"])).ToList();
                }

                if (!string.IsNullOrEmpty(name["starttime"]))
                {
                    用戶創作文章 = 用戶創作文章.Where(x => x.日期起始 > Convert.ToDateTime(name["starttime"])).ToList();
                }

                if (!string.IsNullOrEmpty(name["endtime"]))
                {
                    用戶創作文章 = 用戶創作文章.Where(x => Convert.ToDateTime(name["endtime"]) < x.日期結束).ToList();
                }

                if (!string.IsNullOrEmpty(name["active"]))
                {
                    用戶創作文章 = 用戶創作文章.Where(x => x.類型.Contains(name["active"])).ToList();
                }

                return PartialView("_文章列表", 用戶創作文章);
            }
            catch (Exception e)
            {
                //return e.Message;
            }

            return null;
        }
        

        //public JsonResult MyAllPosts()
        //{
        //    var result = new SQL任務($"SELECT * FROM [文章] WHERE [作者用戶_FK]={Session["ID"]}").讀取();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}