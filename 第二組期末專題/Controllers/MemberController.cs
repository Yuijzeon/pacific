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
            ViewBag.kk = x.大頭貼;
            return View(x);
        }

        public string FileName;

        [HttpPost]
        public ActionResult Index(用戶 x)
        {
            if (x == null)
                return RedirectToAction("index");
            HttpPostedFileBase f = Request.Files["myfile"];
            FileName = f.FileName;
            if (Request.Files.Count > 0)
            {
                 try
                {
                    f.SaveAs(Server.MapPath("../../Content/images/" + FileName));
                }
                catch { };
            }
            x["帳號"] = Request.Form["Email"];
            x["密碼"] = Request.Form["Password"];
            x["名字"] = Request.Form["Name"];
            x["手機"] = Request.Form["Phone"];
            x["Id"] = Request.Form["Id"];
            x["大頭貼"] = FileName;
            (new 用戶CRUD()).更新(x);
            Session["Name"] = x.名字;
            return RedirectToAction("Index", "Home");
        }

        //登出
        public ActionResult 登出()
        {
            Session["ID"] = "";
            Session["Name"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}