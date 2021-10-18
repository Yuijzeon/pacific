using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 任務InsertInto<某類別> : 資料庫任務
    {
        public 任務InsertInto(某類別 物件)
        {
            string 資料表名稱 = typeof(某類別).Name;
            List<string> 屬性鍵清單 = new List<string>();
            List<string> 屬性值清單 = new List<string>();
            Dictionary<string, object> 注入鍵值字典 = new Dictionary<string, object>();

            foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
            {
                string 屬性鍵 = 屬性.Name;
                object 屬性值 = 屬性.GetValue(物件);

                if (屬性鍵 == "Id") continue;

                屬性鍵清單.Add("[" + 屬性鍵 + "]");
                屬性值清單.Add("@" + 屬性鍵);

                注入鍵值字典.Add("@" + 屬性鍵, 屬性值);
            }

            查詢字串 = "INSERT INTO [" + 資料表名稱 + "] (" + string.Join(", ", 屬性鍵清單) + ") VALUES(" + string.Join(", ", 屬性值清單) + ");";

            大量注入參數by(注入鍵值字典);
        }
    }
}