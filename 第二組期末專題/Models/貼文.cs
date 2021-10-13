using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 貼文
    {
        public int Id { get; set; }
        public string 標題 { get; set; }
        public string 內容 { get; set; }
        public 用戶 作者 { get; set; }

        public int Get收藏數()
        {
            string 查詢字串 = "USE [teamdb2] SELECT COUNT(*) FROM [Favorite]" +
                $" WHERE 文章id={Id}";
            return (int)new 資料庫任務(查詢字串).Get資料格();
        }
    }
}