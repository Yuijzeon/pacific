using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 任務SelectById<某類別> : 資料庫任務 where 某類別 : new()
    {
        public 任務SelectById(int Id)
        {
            查詢字串 = "SELECT * FROM [" + typeof(某類別).Name + "] WHERE Id=@ID;";

            注入參數 = delegate (SqlCommand 指令)
            {
                指令.Parameters.AddWithValue("@ID", Id);
                return 指令;
            };
        }


        public 某類別 Get()
        {
            某類別 物件 = new 某類別();

            When讀取到一筆資料 = delegate (SqlDataReader 資料讀取器)
            {
                foreach (PropertyInfo 屬性 in typeof(某類別).GetProperties())
                {
                    屬性.SetValue(物件, 資料讀取器[屬性.Name]);
                }
            };

            讀取資料庫();

            return 物件;
        }
    }
}