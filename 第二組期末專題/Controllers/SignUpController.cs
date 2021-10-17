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

        //選取興趣愛好
        public ActionResult SelectInterest()
        {
            List<Hashtag> datas = null;
            datas = (new HashtagCRUD()).queryAll();
            return View(datas);
        }
        
        //新用戶註冊
        public ActionResult AddUser()
        {
            用戶 user = new 用戶();
            user.帳號 = Request.Form["user帳號"];
            user.密碼 = Request.Form["user密碼"];
            user.名字 = Request.Form["user名字"];
            user.手機 = Request.Form["user手機"];

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