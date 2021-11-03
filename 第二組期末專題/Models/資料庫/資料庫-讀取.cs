using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 第二組期末專題.Models;

namespace 第二組期末專題
{
    public static partial class 資料庫
    {
        public static List<某類別> 讀取表<某類別>(string 查詢字串, object 欲注入鍵值 = null) where 某類別 : Dictionary<string, object>, new()
        {
            List<某類別> 字典清單 = new List<某類別>();

            new Sql任務(查詢字串, 欲注入鍵值).讀取(delegate (SqlDataReader 資料讀取器)
            {
                某類別 字典 = new 某類別();
                for (int i = 0; i < 資料讀取器.FieldCount; i++)
                {
                    string 欄位標題 = 資料讀取器.GetName(i);
                    object 儲存格值 = 資料讀取器[i];

                    if (儲存格值.GetType() == typeof(DateTime))
                    {
                        儲存格值 = ((DateTime)儲存格值).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    try // INNER JOIN 排除相同欄位(通常是ID)
                    {
                        字典.Add(欄位標題, 儲存格值);
                    }
                    catch { }
                }
                字典清單.Add(字典);
            });

            return 字典清單;
        }


        public static List<Dictionary<string, object>> 讀取(string 查詢字串, object 注入鍵值 = null)
        {
            return 讀取表<Dictionary<string, object>>(查詢字串, 注入鍵值);
        }

        public static List<某類別> 讀取<某類別>(string 查詢條件 = null, object 注入鍵值 = null) where 某類別 : Dictionary<string, object>, new()
        {
            string 查詢字串 = $"SELECT * FROM [{typeof(某類別).Name}]";

            if (!string.IsNullOrEmpty(查詢條件)) 查詢字串 += $" {查詢條件}";

            return 讀取表<某類別>(查詢字串, 注入鍵值);
        }

        public static 某類別 讀取<某類別>(object ID) where 某類別 : Dictionary<string, object>, new()
        {
            string 查詢字串 = $"SELECT TOP 1 * FROM [{typeof(某類別).Name}] WHERE [Id]=@ID";

            return 讀取表<某類別>(查詢字串, new { ID }).FirstOrDefault();
        }



        // 擴充功能區 待整理
        public static List<某類別> GetBy<某類別, 中繼類別>(this List<中繼類別> 用戶Favorite清單, string 外鍵名稱) where 某類別 : Dictionary<string, object>, new() where 中繼類別 : Dictionary<string, object>, new()
        {
            List<string> ID清單 = new List<string>();

            用戶Favorite清單.ForEach(x => ID清單.Add($"[Id]={x[外鍵名稱]}"));

            string 查詢條件 = $"WHERE {string.Join(" OR ", ID清單)}";

            return 讀取<某類別>(查詢條件);
        }

        public static List<某類別> GetBy<某類別>(this List<文章Hashtag> 文章Hashtag清單, string 外鍵名稱) where 某類別 : Dictionary<string, object>, new()
        {
            List<string> ID清單 = new List<string>();

            文章Hashtag清單.ForEach(x => ID清單.Add($"[Id]={x[外鍵名稱]}"));

            string 查詢條件 = $"WHERE {string.Join(" OR ", ID清單)}";

            return 讀取<某類別>(查詢條件);
        }
    }
}