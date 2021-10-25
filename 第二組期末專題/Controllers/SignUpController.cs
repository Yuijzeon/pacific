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
            x.帳號 = Request.Form["Email"];
            x.密碼 = Request.Form["Password"];
            x.名字 = Request.Form["Name"];
            x.手機 = Request.Form["Phone"];
            x.註冊日期 = DateTime.Now;
            x.點數 = 1;
            if (x.帳號 == "" || x.密碼 == "" || x.名字 == "" || x.手機 == "")
            {
                Session["msg"] = "不可以空白";
                return RedirectToAction("Index", "SignUp");
            }
            else {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(x.帳號))
                    {
                        Session["msg"] = "Email格式錯誤";
                        return View("Index", );
                    }
            } 
            return RedirectToAction("Index", "Home");
        }

        //新增用戶標籤
        public ActionResult AddUserHashtag(int? id)
        {
            if (id != null)
            {
                用戶Hashtag x = new 用戶Hashtag();
                x.用戶_FK = 1;
                x.Hashtag_FK = (int)id;
                (new 用戶HashtagCRUD()).Create(x);
            }

            return RedirectToAction("SelectInterest");
        }

        //測試標籤新增
        public string Testinsert()
        {
            Hashtag x = new Hashtag();
            x.名稱 = "書籍";
            x.類別 = "愛好";

            (new HashtagCRUD()).Create(x);
            return "新增標籤成功";
        }

        //返回主頁
        public ActionResult back()
        {
            return RedirectToAction("Index", "Home");
        }

        //登入比對
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
      
            string Name = datas[0].名字;
            ViewBag.Name = Name;
            Session["ID"] = datas[0].Id;
            Session["Name"] = Name;
            return RedirectToAction("Index", "Home");
        }
    }
}