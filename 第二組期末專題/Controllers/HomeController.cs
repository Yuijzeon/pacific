﻿using System;
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
            */
            return View();
        }
    }
}