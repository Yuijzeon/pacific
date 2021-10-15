using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class Select文章 : 資料庫任務
    {
        public int 文章id { get; set; }

        public Select文章(int 文章id)
        {
            this.文章id = 文章id;
            查詢字串 = "USE [teamdb2] SELECT * FROM [Post] WHERE id=" + 文章id;
        }


        public 文章 Get()
        {
            文章 此文章 = new 文章();

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    此文章.Id = 文章id;
                    此文章.標題 = (string)資料讀取器["文章title"];
                    此文章.作者 = new Select用戶(文章id).Get();
                    此文章.內容 = (string)資料讀取器["文章內容"];
                    此文章.日期起始 = (DateTime)資料讀取器["日期起始"];
                    此文章.日期結束 = (DateTime)資料讀取器["日期結束"];
                    此文章.時段起始 = (string)資料讀取器["時段起始"];
                    此文章.時段 = (string)資料讀取器["時段"];
                    此文章.地點 = (string)資料讀取器["地點"];
                    此文章.接待人數 = (int)資料讀取器["接待人數"];
                    此文章.類型 = (string)資料讀取器["類型"];
                }
            }.讀取資料庫();

            return 此文章;
        }
    }
}