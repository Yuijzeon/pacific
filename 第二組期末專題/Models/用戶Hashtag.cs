using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶Hashtag
    {
        public int 用戶_FK;
        public int Hashtag_FK;


        public 用戶 Get作者()
        {
            return new 任務SelectById<用戶>(用戶_FK).Get();
        }

        public Hashtag GetHashtag()
        {
            return new 任務SelectById<Hashtag>(Hashtag_FK).Get();
        }
    }
}