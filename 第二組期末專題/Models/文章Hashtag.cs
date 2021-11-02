using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 文章Hashtag : Dictionary<string, object>
    {
        public int 文章_FK { get { return (int)this["文章_FK"]; } set { this["文章_FK"] = value; } }
        public int Hashtag_FK { get { return (int)this["Hashtag_FK"]; } set { this["Hashtag_FK"] = value; } }


        public 文章 Get文章()
        {
            return 資料庫.讀取<文章>(this["文章_FK"]);
        }

        public Hashtag GetHashtag()
        {
            return 資料庫.讀取<Hashtag>(this["Hashtag_FK"]);
        }
    }
}