using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
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
            var 指定用戶 = 資料庫.讀取<用戶>(id);
            return Json(指定用戶, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUser()
        {
            var 全部用戶 = 資料庫.讀取<用戶>();
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            var 全部用戶 = 資料庫.讀取<用戶>();
            用戶 指定用戶 = new 用戶();
            if (id == null)
            {
                return Json(全部用戶, JsonRequestBehavior.AllowGet);
            }
            指定用戶["Id"] = id;
            指定用戶["帳號"] = "0";
            指定用戶["密碼"] = "0";
            指定用戶["名字"] = "0";
            指定用戶["手機"] = "0";
            (new 用戶CRUD()).更新(指定用戶);
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }
    }
}