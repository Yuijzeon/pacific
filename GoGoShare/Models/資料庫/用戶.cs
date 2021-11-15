﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGoShare
{
    public partial class 用戶
    {
        public List<Hashtag> GetHashtag清單()
        {
            return this.Hashtag.ToList();
        }

        public List<文章> Get創作文章清單()
        {
            return new SQL任務().文章.Where(post => post.作者用戶_FK == this.Id).OrderByDescending(x => x.Id).ToList();
        }

        public List<文章> Get最新三筆文章()
        {
            return new SQL任務().文章.Where(post => post.作者用戶_FK == this.Id).OrderByDescending(x => x.Id).Take(3).ToList();
        }

        public 圖片 Get最新圖片()
        {
            return new SQL任務().圖片.Where(img => img.上傳用戶_FK == this.Id).OrderByDescending(x => x.Id).Take(1).SingleOrDefault();
        }

        public List<旅程包> Get旅程包清單()
        {
            return new SQL任務().旅程包.Where(pack => pack.作者用戶_FK == this.Id).OrderByDescending(x => x.Id).ToList();
        }
    }
}