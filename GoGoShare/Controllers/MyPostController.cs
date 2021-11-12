using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoGoShare.Models;

namespace GoGoShare.Controllers
{
    public class MyPostController : Controller
    {
        // GET: MyPost
        public ActionResult Index()
        {
            if (!(Session["ID"] is int))
                return Redirect("/SignUp");

            List<文章> 我的文章 = new SQL任務().用戶.Find(Session["ID"]).文章.ToList();

            return View(我的文章);
        }
    }
}