using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 讀取文章任務 : 資料庫任務
    {
        new string 查詢字串 = "USE [teamdb2] SELECT * FROM [Post]";

        public 文章 GetById(int id)
        {
            文章 此文章 = new 文章();

            查詢字串 += " WHERE id=" + id;

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    此文章.Id = id;
                    此文章.標題 = (string)資料讀取器["文章title"];
                    此文章.作者 = new 讀取用戶任務().GetById((int)資料讀取器["發文userId"]);
                    此文章.內容 = (string)資料讀取器["文章內容"];
                    此文章.日期起始 = (DateTime)資料讀取器["日期起始"];
                    此文章.日期結束 = (DateTime)資料讀取器["日期結束"];
                    此文章.時段起始 = (string)資料讀取器["時段起始"];
                    此文章.時段 = (string)資料讀取器["時段"];
                    此文章.地點 = (string)資料讀取器["地點"];
                    此文章.接待人數 = (int)資料讀取器["接待人數"];
                    此文章.類型 = (string)資料讀取器["類型"];
                    此文章.Hashtag清單 = new 讀取Hashtag清單任務().GetFromTableById("Post", id);
                }
            }.讀取();

            return 此文章;
        }
    }
}