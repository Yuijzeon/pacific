using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using GoGoShare.Models;

namespace GoGoShare.Controllers
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
            if (Session["Id"] is int)
            {
                SelectInterest datas = new SelectInterest();
                datas.已選Hashtags = new SQL任務().用戶.Find(Session["Id"]).Hashtag.ToList();
                datas.全部Hashtags = new SQL任務().Hashtag.ToList();
                return View(datas);
            }
            return RedirectToAction("Index");
        }

        //用戶註冊
        public ActionResult 註冊()
        {
            SQL任務 用戶註冊 = new SQL任務();
            用戶 x = new 用戶();
            x.帳號 = Request.Form["Email"];
            x.密碼 = Request.Form["Password"];
            x.名字 = Request.Form["Name"];
            Session["test"] = Request.Form["Name"];
            x.手機 = Request.Form["Phone"];
            x.註冊日期 = DateTime.Now.ToString("yyyy -MM-dd HH:mm");
            x.大頭貼 = "初始照片.jpg";
            x.點數 = 1;
            用戶註冊.用戶.Add(x);
            用戶註冊.SaveChanges();
            return RedirectToAction("Index");
        }

        //新增用戶標籤
        public ActionResult AddUserHashtag(int? id)
        {
            if (id != null)
            {
                SQL任務 新增用戶標籤 = new SQL任務();
                Hashtag 用戶Hashtag = 新增用戶標籤.Hashtag.Find(id);
                新增用戶標籤.用戶.Find((int)Session["ID"]).Hashtag.Add(用戶Hashtag);
                新增用戶標籤.SaveChanges();
            }

            return RedirectToAction("SelectInterest");
        }

        //刪除用戶標籤
        public ActionResult 刪除用戶標籤(int? id)
        {
            if (id != null)
            {
                SQL任務 刪除用戶標籤 = new SQL任務();
                Hashtag 用戶Hashtag = 刪除用戶標籤.Hashtag.Find(id);
                刪除用戶標籤.用戶.Find((int)Session["ID"]).Hashtag.Remove(用戶Hashtag);
                刪除用戶標籤.SaveChanges();
            }
            return View();
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
            datas = new SQL任務().用戶.Where(u => u.帳號 == x.帳號 && u.密碼 == x.密碼).ToList();
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