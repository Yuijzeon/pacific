using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶Favorite : Dictionary<string, object>
    {
        public int 收藏文章_FK { get { return (int)this["收藏文章_FK"]; } set { this["收藏文章_FK"] = value; } }
        public int 用戶_FK { get { return (int)this["用戶_FK"]; } set { this["用戶_FK"] = value; } }


        public 文章 Get收藏文章()
        {
            return new 任務SelectById<文章>(收藏文章_FK).Get();
        }

        public 用戶 Get用戶()
        {
            return new 任務SelectById<用戶>(用戶_FK).Get();
        }
    }
}