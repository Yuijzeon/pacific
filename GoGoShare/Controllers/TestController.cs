using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoGoShare.Models;

namespace GoGoShare.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser(int id)
        {
            var 指定用戶 = new SQL任務().用戶.Find(id);
            return Json(指定用戶, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUser()
        {
            var 全部用戶 = new SQL任務().用戶.ToList();
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            用戶 指定用戶 = new SQL任務().用戶.Find(id);
            if (id != null)
            {
                new SQL任務().用戶.Remove(指定用戶);
            }

            var 全部用戶 = new SQL任務().用戶.ToList();
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }
    }
}