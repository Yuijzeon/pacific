using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class Select旅程包ById : 資料庫任務
    {
        private int 旅程包Id { get; set; }

        public Select旅程包ById(int 旅程包Id)
        {
            this.旅程包Id = 旅程包Id;
            查詢字串 = "SELECT * FROM [旅程包] WHERE Id=" + 旅程包Id;
        }


        public 旅程包 Get()
        {
            旅程包 此旅程包 = new 旅程包();

            When讀取到一筆資料 = (資料讀取器) =>
            {
                此旅程包.Id = 旅程包Id;
                此旅程包.標題 = (string)資料讀取器["標題"];
                此旅程包.描述 = (string)資料讀取器["描述"];
                此旅程包.作者用戶_FK = (int)資料讀取器["作者用戶_FK"];
            };

            讀取資料庫();

            return 此旅程包;
        }
    }
}