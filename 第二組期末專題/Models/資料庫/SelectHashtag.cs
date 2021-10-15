using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class SelectHashtag : 資料庫任務
    {
        public int HashtagId { get; set; }

        public SelectHashtag(int HashtagId)
        {
            this.HashtagId = HashtagId;
            查詢字串 = "USE [teamdb2] SELECT * FROM [Hashtag] WHERE id=" + HashtagId;
        }


        public Hashtag Get()
        {
            Hashtag hashtag = new Hashtag();

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    hashtag.Id = HashtagId;
                    hashtag.名稱 = (string)資料讀取器["hashtag名稱"];
                    hashtag.類別 = (string)資料讀取器["hashtag類別"];
                }
            }.讀取資料庫();

            return hashtag;
        }
    }
}