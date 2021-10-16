using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class SelectHashtagById : 資料庫任務
    {
        private int HashtagId { get; set; }

        public SelectHashtagById(int HashtagId)
        {
            this.HashtagId = HashtagId;
            查詢字串 = "USE [teamdb2] SELECT * FROM [Hashtag] WHERE id=" + HashtagId;
        }


        public Hashtag Get()
        {
            Hashtag hashtag = new Hashtag();

            When讀取到一筆資料 = (資料讀取器) =>
            {
                hashtag.Id = HashtagId;
                hashtag.名稱 = (string)資料讀取器["名稱"];
                hashtag.類別 = (string)資料讀取器["類別"];
            };

            讀取資料庫();

            return hashtag;
        }
    }
}