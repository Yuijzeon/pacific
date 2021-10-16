using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 文章Hashtag
    {
        public int 文章_FK;
        public int Hashtag_FK;


        public 文章 Get文章()
        {
            return new SelectById<文章>(文章_FK).Get();
        }

        public Hashtag GetHashtag()
        {
            return new SelectById<Hashtag>(Hashtag_FK).Get();
        }
    }
}