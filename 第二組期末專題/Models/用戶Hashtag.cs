using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶Hashtag : 資料表
    {
        public int 用戶_FK { get { return (int)this["用戶_FK"]; } set { this["用戶_FK"] = value; } }
        public int Hashtag_FK { get { return (int)this["Hashtag_FK"]; } set { this["Hashtag_FK"] = value; } }


        public 用戶 Get作者()
        {
            return 資料庫.讀取<用戶>(this["用戶_FK"]);
        }

        public Hashtag GetHashtag()
        {
            return 資料庫.讀取<Hashtag>(this["Hashtag_FK"]);
        }
    }
}