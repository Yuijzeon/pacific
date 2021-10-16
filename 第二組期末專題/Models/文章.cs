﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 文章
    {
        public int Id { get; set; }
        public string 標題 { get; set; }
        public int 作者用戶_FK { get; set; }
        public string 內容 { get; set; }
        public DateTime 日期起始 { get; set; }
        public DateTime 日期結束 { get; set; }
        public string 時段起始 { get; set; }
        public string 時段 { get; set; }
        public string 地點 { get; set; }
        public int 接待人數 { get; set; }
        public string 類型 { get; set; }

        public 用戶 Get作者()
        {
            return new Select用戶ById(作者用戶_FK).Get();
        }

        public List<Hashtag> GetHashtag清單()
        {
            string 查詢字串 = "USE [teamdb2] SELECT * FROM [文章_Hashtag]" +
                    " WHERE 文章_FK=" + Id;
            return new SelectHashtag清單(查詢字串).Get();
        }

        public int Get收藏數()
        {
            string 查詢字串 = "USE [teamdb2] SELECT COUNT(*) FROM [Favorite]" +
                $" WHERE 文章id={Id}";
            return (int)new 資料庫任務(查詢字串).Get資料格();
        }
    }
}