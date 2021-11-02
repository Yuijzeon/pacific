using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace 第二組期末專題
{
    public class 任務
    {
        //建構函式 開始
        public 任務()
        {
            連線字串 = "Server=tcp:datateam2.database.windows.net,1433;" +
                       "Initial Catalog=team2;" +
                       "Persist Security Info=False;" +
                       "User ID=team2;" +
                       "Password=XYZtwo22;" +
                       "MultipleActiveResultSets=False;" +
                       "Encrypt=True;" +
                       "TrustServerCertificate=False;" +
                       "Connection Timeout=30;";
            注入鍵值 = null;
        }

        public 任務(string 查詢字串) : this()
        {
            this.查詢字串 = 查詢字串;
        }
        //建構函式 結束

        //物件屬性 開始
        public string 連線字串 { get; set; }

        public string 查詢字串 { get; set; }

        public object 注入鍵值 { get; set; }

        public Action<SqlCommand> 操作流程 { get; set; }
        //物件屬性 結束

        //物件方法 開始
        public void 執行()
        {
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();

                SqlCommand 指令 = new SqlCommand(查詢字串, 連線);

                if (注入鍵值 != null)
                {
                    foreach (PropertyInfo 屬性 in 注入鍵值.GetType().GetProperties())
                    {
                        string 注入鍵 = 屬性.Name;
                        object 注入值 = 屬性.GetValue(注入鍵值);

                        if (注入值 == null) continue;

                        if (注入值.GetType() == typeof(DateTime))
                        {
                            注入值 = ((DateTime)注入值).ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        指令.Parameters.AddWithValue(注入鍵, 注入值);
                    }
                }

                操作流程(指令);

                連線.Close();
            }
        }

        public 任務 注入(object 參數鍵值)
        {
            注入鍵值 = 參數鍵值;
            return this;
        }
    }
}