using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 讀取旅程包任務 : 資料庫任務
    {
        new string 查詢字串 = "USE [teamdb2] SELECT * FROM [Post_Pack]";

        public 旅程包 GetById(int id)
        {
            旅程包 此旅程包 = new 旅程包();

            查詢字串 += " WHERE id=" + id;

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    此旅程包.Id = (int)資料讀取器["id"];
                    此旅程包.標題 = (string)資料讀取器["旅程包title"];
                    此旅程包.內容 = (string)資料讀取器["旅程包文章內容"];
                    此旅程包.作者 = new 讀取用戶任務().GetById((int)資料讀取器["旅程包userId"]);
                }
            }.讀取();

            return 此旅程包;
        }
    }
}