using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            ViewBag.msg1 = Session["msg"];
            return View();
        }

        //SHOW出所有標籤
        public ActionResult SelectInterest()
        {
            List<Hashtag> datas = null;
            datas = (new HashtagCRUD()).queryAll();
            return View(datas);
        }

        //用戶註冊
        public ActionResult 註冊()
        {
            用戶 x = new 用戶();
            x["帳號"] = Request.Form["Email"];
            x["密碼"] = Request.Form["Password"];
            x["名字"] = Request.Form["Name"];
            Session["test"] = Request.Form["Name"];
            x["手機"] = Request.Form["Phone"];
            x["註冊日期"] = DateTime.Now.ToString("yyyy -MM-dd HH:mm");
            x["點數"] = 1;
            (new 用戶CRUD()).註冊(x);
            return RedirectToAction("SelectInterest");
        }

        //新增用戶標籤
        public ActionResult AddUserHashtag(int? id)
        {
            if (id != null)
            {
                用戶Hashtag x = new 用戶Hashtag();
                string name = (string)Session["test"];
                List<用戶> data = new 用戶CRUD().取ID(name);
                //x["用戶_FK"] = Session["ID"];
                x["用戶_FK"] = data[0].Id;
                x["Hashtag_FK"] = (int)id;
                (new 用戶HashtagCRUD()).Create(x);
            }

            return RedirectToAction("SelectInterest");
        }

        //測試標籤新增
        public string Testinsert()
        {
            Hashtag x = new Hashtag();
            x["名稱"] = "書籍";
            x["類別"] = "愛好";

            (new HashtagCRUD()).Create(x);
            return "新增標籤成功";
        }

        //返回主頁
        public ActionResult back()
        {
            return RedirectToAction("Index", "Member");
        }

        //登入
        [HttpPost]
        public ActionResult index()
        {
            List<用戶> datas = null;
            登入view x = new 登入view();
            x.帳號 = Request.Form["帳號"];
            x.密碼 = Request.Form["密碼"];
            datas = new 用戶CRUD().登入(x.帳號, x.密碼);
            if (datas.Count == 0)
            {
                ViewBag.msg = "帳號密碼錯誤";
                return View();
            }
            else
            {
                TempData["message"] = "登入成功";
                TempData["account_text"] = x.帳號;
                TempData["password_text"] = x.密碼;
                Session["ID"] = datas[0].Id;
                Session["Name"] = datas[0].名字;
                return View();
            }           
        }
       
    }
}