using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        //會員編輯資料顯示
        public ActionResult Index(int? id)
        {
            if (id == null) 
                return RedirectToAction("Index", "Home");
            用戶 x = (new 用戶CRUD()).queryById((int)id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(用戶 x)
        {
            if (x == null)
                return RedirectToAction("index");
            (new 用戶CRUD()).更新(x);
            Session["Name"] = x.名字;
            return RedirectToAction("Index", "Home");
        }

        //登出
        public ActionResult 登出(用戶 x)
        {
            Session["ID"] = "";
            Session["Name"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}