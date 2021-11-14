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

            List<文章> model = new SQL任務().用戶.Find((int)Session["ID"]).Get創作文章清單();
            return View(model);
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
                文章.旅程包_link.Clear();
                文章.用戶.Clear();
                文章.評級.Clear();

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

        //public JsonResult MyAllPosts()
        //{
        //    var result = new SQL任務($"SELECT * FROM [文章] WHERE [作者用戶_FK]={Session["ID"]}").讀取();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}