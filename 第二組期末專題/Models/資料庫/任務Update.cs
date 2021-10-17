using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 任務Update<某類別> : 資料庫任務
    {
        private int 目標Id { get; set; }
        private List<KeyValuePair<string, object>> 屬性鍵值對清單 { get; set; }

        public 任務Update(某類別 物件)
        {
            Get屬性鍵值對清單(物件);
            查詢字串 = Get連線字串();
        }

        public void SetBy欄位(string[] 指定欄位)
        {
            修改屬性鍵值對清單By(指定欄位);
            查詢字串 = Get連線字串();
            Set();
        }

        private void Get屬性鍵值對清單(某類別 物件) {
            List<KeyValuePair<string, object>> 屬性鍵值對清單 = new List<KeyValuePair<string, object>>();
            foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
            {
                string 屬性鍵 = 屬性.Name;
                object 屬性值 = 屬性.GetValue(物件);

                if (屬性鍵.Equals("Id"))
                {
                    目標Id = (int)屬性值;
                    continue;
                }

                屬性鍵值對清單.Add(new KeyValuePair<string, object>(屬性鍵, 屬性值));
            }
            this.屬性鍵值對清單 = 屬性鍵值對清單;
        }

        private string Get連線字串()
        {
            List<string> 屬性字串清單 = new List<string>();

            foreach (KeyValuePair<string, object> 屬性鍵值對 in 屬性鍵值對清單)
            {
                string 屬性鍵 = "[" + 屬性鍵值對.Key + "]";

                object 屬性值 = 屬性鍵值對.Value;

                if (屬性值 == null)
                {
                    屬性值 = "NULL";
                }
                else
                {
                    if (屬性值.GetType() == typeof(DateTime))
                    {
                        屬性值 = ((DateTime)屬性值).ToString("yyyy-MM-dd hh:mm:ss");
                    }
                    else if (屬性值.GetType() == typeof(int)) {
                    }
                    else
                    {
                        屬性值 = "N'" + 屬性值 + "'";
                    }
                }
                屬性字串清單.Add(屬性鍵 + "=" + 屬性值);
            }

            return "UPDATE [" + typeof(某類別).Name + "] SET " + string.Join(", ", 屬性字串清單) + " WHERE Id=" + 目標Id + ";";
        }

        private void 修改屬性鍵值對清單By(string[] 指定欄位)
        {
            List<KeyValuePair<string, object>> 指定屬性鍵值對清單 = new List<KeyValuePair<string, object>>();

            foreach (KeyValuePair<string, object> 屬性鍵值對 in 屬性鍵值對清單)
            {
                if (指定欄位.Contains(屬性鍵值對.Key))
                {
                    指定屬性鍵值對清單.Add(屬性鍵值對);
                }
            }
            屬性鍵值對清單 = 指定屬性鍵值對清單;
        }
    }
}