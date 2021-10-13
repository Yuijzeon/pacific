using System.Data;
using System.Data.SqlClient;

namespace 第二組期末專題.Models
{
    public class 資料庫任務
    {
        public 資料庫任務() {}

        public 資料庫任務(string str)
        {
            查詢字串 = str;
        }


        public string 連線字串 = "Server=tcp:teamtwodb.database.windows.net,1433;" +
                                 "Initial Catalog=teamdb2;" +
                                 "Persist Security Info=False;" +
                                 "User ID=teamtwo;" +
                                 "Password=abcTwo22;" +
                                 "MultipleActiveResultSets=False;" +
                                 "Encrypt=True;" +
                                 "TrustServerCertificate=False;" +
                                 "Connection Timeout=30;";

        public string 查詢字串 { get; set; }

        public delegate SqlCommand 回呼指令(SqlCommand 指令);
        public 回呼指令 注入參數 = delegate (SqlCommand 指令)
        {
            return 指令;
        };


        public DataTable Get資料表()
        {
            DataTable 資料表 = new DataTable();

            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();
                SqlCommand 指令 = 注入參數(new SqlCommand(查詢字串, 連線));
                SqlDataAdapter 資料中繼器 = new SqlDataAdapter(指令);
                資料中繼器.Fill(資料表);
            }
            return 資料表;
        }


        public void Set更新()
        {
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();
                SqlCommand 指令 = 注入參數(new SqlCommand(查詢字串, 連線));
                指令.ExecuteNonQuery();
            }
        }
    }
}