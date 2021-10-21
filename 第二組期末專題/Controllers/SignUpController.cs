using System;
using System.Collections.Generic;
using System.Linq;
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
            new 用戶CRUD().註冊(x);
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

        //測試新增
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

    }
}