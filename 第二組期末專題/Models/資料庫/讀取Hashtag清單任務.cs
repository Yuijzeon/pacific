using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 讀取Hashtag清單任務 : 資料庫任務
    {
        new string 查詢字串 = "USE [teamdb2] SELECT * FROM [Post]";

        public List<Hashtag> GetFromTableById(string 名稱, int id)
        {
            List<Hashtag> Hashtag清單 = new List<Hashtag>();

            查詢字串 = "USE [teamdb2] SELECT * FROM [" + 名稱 + "_Hashtag]" +
                " WHERE " + 名稱 + "Id_FK=" + id;

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    Hashtag清單.Add(new 讀取Hashtag任務().GetById((int)資料讀取器["Hashtag_FK"]));
                }
            }.讀取();

            return Hashtag清單;
        }
    }
}