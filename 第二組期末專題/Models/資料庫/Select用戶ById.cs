using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class Select用戶ById : 資料庫任務
    {
        private int 用戶Id { get; set; }

        public Select用戶ById(int 用戶Id)
        {
            this.用戶Id = 用戶Id;
            查詢字串 = "SELECT * FROM [用戶] WHERE id=" + 用戶Id;
        }


        public 用戶 Get()
        {
            用戶 此用戶 = new 用戶();

            When讀取到一筆資料 = (資料讀取器) =>
            {
                此用戶.Id = 用戶Id;
                此用戶.帳號 = (string)資料讀取器["帳號"];
                此用戶.密碼 = (string)資料讀取器["密碼"];
                此用戶.名字 = (string)資料讀取器["名字"];
                此用戶.手機 = (string)資料讀取器["手機"];
                此用戶.註冊日期 = (DateTime)資料讀取器["註冊日期"];
                此用戶.大頭貼 = (string)資料讀取器["大頭貼"];
                此用戶.點數 = (int)資料讀取器["點數"];
            };

            讀取資料庫();

            return 此用戶;
        }
    }
}