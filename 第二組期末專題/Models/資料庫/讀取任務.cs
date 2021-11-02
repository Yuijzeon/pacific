using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace 第二組期末專題
{
    public class 讀取任務 : 任務
    {
        public Action<SqlDataReader> When讀取到一筆資料 { get; set; }

        public 讀取任務(string 查詢字串) : base()
        {
            this.查詢字串 = 查詢字串;

            this.操作流程 = delegate (SqlCommand 指令)
            {
                SqlDataReader 資料讀取器 = 指令.ExecuteReader();

                while (資料讀取器.Read())
                {
                    When讀取到一筆資料(資料讀取器);
                }
            };
        }
    }
}