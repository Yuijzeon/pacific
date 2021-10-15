using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class Select旅程包 : 資料庫任務
    {
        public Select旅程包(int id)
        {
            this.旅程包id = 旅程包id;
            查詢字串 = "USE [teamdb2] SELECT * FROM [Post_Pack] WHERE id=" + id;
        }
        public int 旅程包id { get; set; }


        public 旅程包 Get()
        {
            旅程包 此旅程包 = new 旅程包();

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    此旅程包.Id = (int)資料讀取器["id"];
                    此旅程包.標題 = (string)資料讀取器["旅程包title"];
                    此旅程包.內容 = (string)資料讀取器["旅程包文章內容"];
                    此旅程包.作者 = new Select用戶((int)資料讀取器["旅程包userId"]).Get();
                }
            }.讀取資料庫();

            return 此旅程包;
        }
    }
}