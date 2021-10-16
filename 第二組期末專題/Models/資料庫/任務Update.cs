using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 任務Update<某類別> : 資料庫任務
    {
        public 任務Update(某類別 物件)
        {
            查詢字串 = Get查詢字串(物件);
        }

        private string Get查詢字串(某類別 物件) {

            object Id = new object();
            List<string> 屬性鍵值對 = new List<string>();

            foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
            {
                if (屬性.Name == "Id")
                {
                    Id = 屬性.GetValue(物件);
                    continue; 
                }

                屬性鍵值對.Add(屬性.Name + "=" + 屬性.GetValue(物件) + ", ");
            }

            return "UPDATE [" + typeof(某類別).Name + "] SET " +
            string.Join(", ", 屬性鍵值對) + " WHERE Id=" + Id + ";";
        }
    }
}