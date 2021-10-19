using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第二組期末專題.Models;

namespace 第二組期末專題.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string 我的查詢 = "";
            /*
            DataTable 報表 = new 資料庫任務()
            {
                查詢字串 = 我的查詢,
                注入參數 = (指令) =>
                {
                    指令.Parameters.AddWithValue("@1", "AAA");
                    指令.Parameters.AddWithValue("@2", "BBB");
                    指令.Parameters.AddWithValue("@3", "CCC");
                    return 指令;
                }
            }.Get資料表();
            
            new 任務Update<用戶>(new 用戶 {
                Id = 6,
                手機 = "0988888888",
                註冊日期 = DateTime.Parse("2021-10-18 16:30:00")
            }).SetBy欄位(new[] {"大頭貼", "手機" , "註冊日期" });
            */

            new 資料庫任務($"UPDATE [用戶] SET [名字]=@NAME WHERE [Id]=@ID") {
                注入參數 = (指令) => {
                    指令.Parameters.AddWithValue("NAME", "哀低五號");
                    指令.Parameters.AddWithValue("ID", 5);
                    return 指令;
                }
            }.Set();

            new 任務Update<用戶>(new 用戶() {
                Id = 6,
                名字 = "哀低六號"
            }).SetBy欄位(new[] { "名字" });

            new 資料庫任務($"UPDATE [用戶] SET [名字]=@NAME WHERE [Id]=@ID")
                .注入參數by(new { NAME = "哀低七號", ID = 7 }).Set();

            return View();
        }
    }
}