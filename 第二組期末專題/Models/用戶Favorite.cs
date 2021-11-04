using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶Favorite : 資料表
    {
        public int 收藏文章_FK { get { return (int)this["收藏文章_FK"]; } set { this["收藏文章_FK"] = value; } }
        public int 用戶_FK { get { return (int)this["用戶_FK"]; } set { this["用戶_FK"] = value; } }


        public 文章 Get收藏文章()
        {
            return 資料庫.讀取<文章>(this["收藏文章_FK"]);
        }

        public 用戶 Get用戶()
        {
            return 資料庫.讀取<用戶>(this["用戶_FK"]);
        }
    }
}