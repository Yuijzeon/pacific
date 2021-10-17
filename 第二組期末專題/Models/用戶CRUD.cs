using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶CRUD
    {
        public void 註冊(用戶 x)
        {
            string sql = "INSERT INTO 用戶 (帳號, 密碼, 名字, 手機, 註冊日期, 點數) VALUES (";
            sql += "N'" + x.帳號 + "', ";
            sql += "'" + x.密碼 + "', ";
            sql += "N'" + x.名字 + "', ";
            sql += "'" + x.手機 + "', ";
            sql += "'" + x.註冊日期 + "', ";
            sql += x.點數 + ")";

            new 資料庫任務(sql).Set();
        }
    }
}