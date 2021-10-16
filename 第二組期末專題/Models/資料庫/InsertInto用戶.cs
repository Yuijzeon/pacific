using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題.Models.資料庫
{
    public class InsertInto用戶 : 資料庫任務
    {
        public InsertInto用戶(用戶 新用戶)
        {
            查詢字串 = Get新增用戶查詢字串(新用戶);
            //"USE [teamdb2] INSERT INTO table_name (新用戶, column2, column3...) VALUES(value1, value2, value3...);";
        }

        private string Get新增用戶查詢字串(用戶 user) {

            string 查詢字串 = "USE [teamdb2] INSERT INTO ";

            List<string> 欄位清單 = new List<string>();
            List<string> 值清單 = new List<string>();

            foreach (PropertyInfo 屬性 in typeof(用戶).GetProperties())
            {
                欄位清單.Add(屬性.Name);
                值清單.Add(屬性.GetValue(user).ToString()); 
            }

            return 查詢字串;
        }
    }
}