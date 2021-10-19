using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 任務SelectList<某類別> : 資料庫任務 where 某類別 : new()
    {
        public 任務SelectList() : base()
        {
            查詢字串 = "SELECT * FROM [" + typeof(某類別).Name + "];";
        }

        public 任務SelectList(string 查詢字串) : base(查詢字串) {}

        public List<某類別> Get()
        {
            List<某類別> 某類別清單 = new List<某類別>();

            When讀取到一筆資料 = (資料讀取器) =>
            {
                某類別 物件 = new 某類別();

                foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
                {
                    var 資料庫資料 = 資料讀取器[屬性.Name];

                    if (資料庫資料.GetType() == typeof(DBNull))
                    {
                        continue;
                    }
                    else if (屬性.PropertyType == typeof(DateTime))
                    {
                        屬性.SetValue(物件, Convert.ToDateTime(資料庫資料));
                        continue;
                    }
                    else
                    {
                        屬性.SetValue(物件, 資料庫資料);
                    }
                }

                某類別清單.Add(物件);
            };

            讀取資料庫();

            return 某類別清單;
        }

        public List<某類別> GetBy(string 外鍵欄位名稱)
        {
            List<某類別> 某類別清單 = new List<某類別>();

            When讀取到一筆資料 = (資料讀取器) =>
            {
                某類別清單.Add(new 任務SelectById<某類別>((int)資料讀取器[外鍵欄位名稱]).Get());
            };

            讀取資料庫();

            return 某類別清單;
        }
    }
}