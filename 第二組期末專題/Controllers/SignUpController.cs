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

        //新增用戶標籤
        public ActionResult AddUserHashtag(int? id)
        {
            if (id != null)
            {
                AddHashtag x = new AddHashtag();
                x.UserId_FK = 1;
                x.Hashtag_FK = (int)id;
                (new AddHashtagCRUD()).Create(x);
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