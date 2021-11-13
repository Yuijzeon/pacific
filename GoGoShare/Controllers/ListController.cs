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
    }
}