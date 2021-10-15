using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 讀取Hashtag任務 : 資料庫任務
    {
        new string 查詢字串 = "USE [teamdb2] SELECT * FROM [Hashtag]";

        public Hashtag GetById(int id)
        {
            查詢字串 += " WHERE id=" + id;

            Hashtag hashtag = new Hashtag();

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    hashtag.Id = (int)資料讀取器["id"];
                    hashtag.名稱 = (string)資料讀取器["hashtag名稱"];
                    hashtag.類別 = (string)資料讀取器["hashtag類別"];
                }
            }.讀取();

            return hashtag;
        }
    }
}