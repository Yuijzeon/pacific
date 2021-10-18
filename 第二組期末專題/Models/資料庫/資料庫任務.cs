using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace 第二組期末專題.Models
{
    public class 資料庫任務
    {
        //建構函式 開始
        public 資料庫任務()
        {
            連線字串 = Teamdb2.連線字串;
            注入參數 = (指令) => 指令;
            When讀取到一筆資料 = (資料讀取器) => {};

        /*  delegate語句寫法:
            private 回呼指令 注入參數 = delegate (SqlCommand 指令) { return 指令; }
            懶大語句寫法:
            private 回呼指令 注入參數 = (指令) => 指令;
            懶大語句寫法(多行):
            private 回呼指令 注入參數 = (指令) => { return 指令; };  */
        }

        public 資料庫任務(string 查詢字串) : this()
        {
            this.查詢字串 = 查詢字串;
        }
        //建構函式 結束

        //物件屬性 開始
        public string 連線字串 { get; set; }

        public string 查詢字串 { get; set; }

        public delegate SqlCommand 回呼SqlCommand(SqlCommand 指令);
        public 回呼SqlCommand 注入參數 { get; set; }

        public delegate void 回呼SqlDataReader(SqlDataReader 資料讀取器);
        public 回呼SqlDataReader When讀取到一筆資料 { get; set; }
        //物件屬性 結束

        //物件方法 開始
        public void 讀取資料庫()
        {
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();
                SqlCommand 指令 = 注入參數(new SqlCommand(查詢字串, 連線));

                SqlDataReader 資料讀取器 = 指令.ExecuteReader();
                while (資料讀取器.Read())
                {
                    When讀取到一筆資料(資料讀取器);
                }
                連線.Close(); 
            }
        }

        public object Get資料格()
        {
            object 資料格 = new object();
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();
                SqlCommand 指令 = 注入參數(new SqlCommand(查詢字串, 連線));
                資料格 = 指令.ExecuteScalar();
                連線.Close();
            }
            return 資料格;
        }

        public void Set()
        {
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();
                SqlCommand 指令 = 注入參數(new SqlCommand(查詢字串, 連線));
                指令.ExecuteNonQuery();
                連線.Close();
            }
        }

        public 資料庫任務 大量注入參數by(Dictionary<string, object> 注入鍵值字典)
        {
            注入參數 = (指令) =>
            {
                foreach (KeyValuePair<string, object> 注入鍵值對 in 注入鍵值字典)
                {
                    string 屬性鍵 = 注入鍵值對.Key;
                    object 屬性值 = 注入鍵值對.Value;

                    if (屬性值 == null) continue;
                    
                    if (屬性值.GetType() == typeof(DateTime))
                    {
                        屬性值 = ((DateTime)屬性值).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    
                    指令.Parameters.AddWithValue(屬性鍵, 屬性值);
                }
                return 指令;
            };
            return this;
        }
        //物件方法 結束
    }
}