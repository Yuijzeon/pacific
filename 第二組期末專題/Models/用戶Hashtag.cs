using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶Hashtag : Dictionary<string, object>
    {
        public int 用戶_FK { get { return (int)this["用戶_FK"]; } set { this["用戶_FK"] = value; } }
        public int Hashtag_FK { get { return (int)this["Hashtag_FK"]; } set { this["Hashtag_FK"] = value; } }


        public 用戶 Get作者()
        {
            return new 任務SelectById<用戶>(this["用戶_FK"]).Get();
        }

        public Hashtag GetHashtag()
        {
            return new 任務SelectById<Hashtag>(this["Hashtag_FK"]).Get();
        }
    }
}