using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 讀取用戶任務 : 資料庫任務
    {
        new string 查詢字串 = "USE [teamdb2] SELECT * FROM [User]";

        public 用戶 GetById(int id)
        {
            用戶 此用戶 = new 用戶();

            查詢字串 += " WHERE id=" + id;

            new 資料庫任務(查詢字串)
            {
                When讀取到一筆資料 = (資料讀取器) =>
                {
                    此用戶.Id = (int)資料讀取器["id"];
                    此用戶.帳號 = (string)資料讀取器["帳號"];
                    此用戶.密碼 = (string)資料讀取器["密碼"];
                    此用戶.名字 = (string)資料讀取器["名字"];
                    此用戶.手機 = (string)資料讀取器["手機"];
                    此用戶.註冊日期 = (DateTime)資料讀取器["註冊日期"];
                    此用戶.大頭貼 = (string)資料讀取器["大頭貼"];
                    此用戶.點數 = (int)資料讀取器["點數"];
                    此用戶.Hashtag清單 = new 讀取Hashtag清單任務().GetFromTableById("User", (int)資料讀取器["id"]);
                }
            }.讀取();

            return 此用戶;
        }
    }
}