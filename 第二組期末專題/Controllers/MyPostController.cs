using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class MyPostController : Controller
    {
        // GET: MyPost
        public ActionResult Index()
        {
            if (!(Session["ID"] is int))
                return Redirect("/SignUp");

            List<文章> 我的文章 = 資料庫.讀取<用戶>(Session["ID"]).Get創作文章清單();

            return View(我的文章);
        }
    }
}