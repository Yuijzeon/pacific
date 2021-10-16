using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶Favorite
    {
        public int 收藏文章_FK;
        public int 用戶_FK;


        public 文章 Get收藏文章()
        {
            return new SelectById<文章>(收藏文章_FK).Get();
        }

        public 用戶 Get用戶()
        {
            return new SelectById<用戶>(用戶_FK).Get();
        }
    }
}