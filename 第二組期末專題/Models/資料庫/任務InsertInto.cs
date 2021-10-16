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
            查詢字串 = Get查詢字串(物件);
        }

        private string Get查詢字串(某類別 物件) {

            List<string> 屬性名稱清單 = new List<string>();
            List<object> 值清單 = new List<object>();

            foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
            {
                if (屬性.Name == "Id") continue;

                屬性名稱清單.Add(屬性.Name);
                值清單.Add(屬性.GetValue(物件));
            }

            return "INSERT INTO [" + typeof(某類別).Name + "] (" +
            string.Join(", ", 屬性名稱清單) + ") VALUES(" + string.Join(", ", 值清單) + ");";
        }
    }
}