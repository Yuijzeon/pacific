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
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string 帳號, string 密碼, string 名字, string 手機)
        {
            if (帳號 == "" || 帳號 == null)
                return View();
            if (密碼 == "" || 密碼 == null)
                return View();
            if (名字 == "" || 名字 == null)
                return View();
            if (手機 == "" || 手機 == null)
                return View();
            新增用戶 addUser = new 新增用戶();
            addUser.帳號 = 帳號;
            addUser.密碼 = 密碼;
            addUser.名字 = 名字;
            addUser.手機 = 手機;
            addUser.註冊日期 = DateTime.Now;
            return View();

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