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
            List<string> 值清單 = new List<string>();

            foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
            {
                if (屬性.Name == "Id") continue;

                屬性名稱清單.Add("[" + 屬性.Name + "]");
                if (屬性.PropertyType == typeof(DateTime))
                {
                    值清單.Add("N'" + ((DateTime)屬性.GetValue(物件)).ToString("yyyy-MM-dd hh:mm:ss") + "'");
                }
                else
                {
                    值清單.Add("N'" + 屬性.GetValue(物件).ToString() + "'");
                }
            }

            return "INSERT INTO [" + typeof(某類別).Name + "] (" +
            string.Join(", ", 屬性名稱清單) + ") VALUES(" + string.Join(", ", 值清單) + ");";
        }
    }
}