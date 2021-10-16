﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶
    {
        public int Id { get; set; }
        public string 帳號 { get; set; }
        public string 密碼 { get; set; }
        public string 名字 { get; set; }
        public string 手機 { get; set; }
        public DateTime 註冊日期 { get; set; }
        public string 大頭貼 { get; set; }
        public int 點數 { get; set; }


        public List<Hashtag> GetHashtag清單()
        {
            string 查詢字串 = "SELECT * FROM [用戶Hashtag] WHERE 用戶_FK=" + Id;
            return new SelectList<Hashtag>(查詢字串).GetBy("Hashtag_FK");
        }

        public List<文章> Get創作清單()
        {
            string 查詢字串 = "SELECT * FROM [文章] WHERE 作者用戶_FK=" + Id;
            return new SelectList<文章>(查詢字串).Get();
        }

        public List<文章> Get收藏清單()
        {
            string 查詢字串 = "SELECT * FROM [用戶Favorite] WHERE 用戶_FK=" + Id;
            return new SelectList<文章>(查詢字串).GetBy("收藏文章_FK");
        }

        public List<旅程包> Get旅程包清單()
        {
            string 查詢字串 = "SELECT * FROM [旅程包] WHERE 作者用戶_FK=" + Id;
            return new SelectList<旅程包>(查詢字串).Get();
        }

        /*
        public List<圖片> Get上傳圖片清單()
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [圖片]" +
                    " WHERE 上傳用戶_FK=" + Id;

            return new Select圖片清單(查詢字串).Get();
        }
        */

        /*
        public List<提問> Get提問清單()
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [QnA]" +
                    " WHERE 提問用戶_FK=" + Id;

            return new Select提問清單(查詢字串).Get();
        }
        */

    }
}