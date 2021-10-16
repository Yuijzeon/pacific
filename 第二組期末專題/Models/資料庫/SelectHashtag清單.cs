using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class SelectHashtag清單 : 資料庫任務
    {
        public SelectHashtag清單(string 查詢字串) : base(查詢字串) {}


        public List<Hashtag> Get()
        {
            List<Hashtag> Hashtag清單 = new List<Hashtag>();

            When讀取到一筆資料 = (資料讀取器) =>
            {
                Hashtag清單.Add(new SelectHashtagById((int)資料讀取器["Hashtag_FK"]).Get());
            };

            讀取資料庫();

            return Hashtag清單;
        }
    }
}