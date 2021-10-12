using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 期末專題.Models
{
    public class 資料庫任務
    {
        public string 連線字串 = "Server=tcp:teamtwodb.database.windows.net,1433;Initial Catalog=teamdb2;Persist Security Info=False;User ID=teamtwo;Password=abcTwo22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public string 查詢字串 { get; set; }


        public DataTable Get資料表()
        {
            DataTable 資料表 = new DataTable();

            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                SqlCommand 指令 = new SqlCommand(查詢字串, 連線);
                連線.Open();
                SqlDataAdapter 資料中繼器 = new SqlDataAdapter(指令);
                資料中繼器.Fill(資料表);
            }
            return 資料表;
        }


        public void Set更新()
        {
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                SqlCommand 指令 = new SqlCommand(查詢字串, 連線);
                連線.Open();
                指令.ExecuteNonQuery();
            }
        }
    }
}