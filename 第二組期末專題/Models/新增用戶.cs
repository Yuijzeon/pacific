using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 新增用戶
    {
        public int Id { get; set; }
        public string 帳號 { get; set; }
        public string 密碼 { get; set; }
        public string 名字 { get; set; }
        public string 手機 { get; set; }
        public DateTime 註冊日期 { get; set; }

        public bool Insert新增用戶(object 用戶)
        {
            new 任務InsertInto<用戶>(用戶).Set();
            return true; //之後要改

        }
    }
}