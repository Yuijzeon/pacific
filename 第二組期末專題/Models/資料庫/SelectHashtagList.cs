using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class SelectHashtagList : 資料庫任務
    {
        public string Hashtag目標 { get; set; }
        public int 目標id { get; set; }

        public SelectHashtagList(string Hashtag目標, int 目標id)
        {
            this.Hashtag目標 = Hashtag目標;
            this.目標id = 目標id;
            查詢字串 = "USE [teamdb2] SELECT * FROM [" + Hashtag目標 + "_Hashtag]" +
                " WHERE " + Hashtag目標 + "Id_FK=" + 目標id;
        }


        public List<Hashtag> Get()
        {
            List<Hashtag> Hashtag清單 = new List<Hashtag>();

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    Hashtag清單.Add(new SelectHashtag((int)資料讀取器["Hashtag_FK"]).Get());
                }
            }.讀取資料庫();

            return Hashtag清單;
        }
    }
}