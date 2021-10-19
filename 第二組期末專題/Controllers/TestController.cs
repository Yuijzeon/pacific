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
            var 指定用戶 = new 任務SelectById<用戶>(id).Get();
            return Json(指定用戶, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUser()
        {
            var 全部用戶 = new 資料庫任務("SELECT * FROM [用戶]").Get();
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser(int id)
        {
            new 資料庫任務("DELETE FROM [用戶] WHERE [Id]=@ID").注入參數by(new { ID = id }).Set();

            var 全部用戶 = new 資料庫任務("SELECT * FROM [用戶]").Get();
            return Json(全部用戶, JsonRequestBehavior.AllowGet);
        }
    }
}