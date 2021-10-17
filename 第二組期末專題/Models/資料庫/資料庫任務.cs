using System.Data;
using System.Data.SqlClient;

namespace 第二組期末專題.Models
{
    public class 資料庫任務
    {
        //建構函式 開始
        public 資料庫任務() {}

        public 資料庫任務(string 查詢字串)
        {
            this.查詢字串 = 查詢字串;
        }

        //建構函式 結束

        //物件屬性 開始
        private string _連線字串 = Teamdb2.連線字串;
        public string 連線字串
        {
            get { return _連線字串; }
            set { _連線字串 = value; }
        }

        public string 查詢字串 { get; set; }

        public delegate SqlCommand 回呼SqlCommand(SqlCommand 指令);
        private 回呼SqlCommand _注入參數 = (指令) => 指令;
        /*  delegate語句寫法:
            private 回呼指令 _注入參數 = delegate (SqlCommand 指令) { return 指令; }
            懶大語句寫法:
            private 回呼指令 _注入參數 = (指令) => 指令;
            懶大語句寫法(多行):
            private 回呼指令 _注入參數 = (指令) => { return 指令; };  */
        public 回呼SqlCommand 注入參數
        {
            get { return _注入參數; }
            set { _注入參數 = value; }
        }

        public delegate void 回呼SqlDataReader(SqlDataReader 資料讀取器);
        private 回呼SqlDataReader _When讀取到一筆資料 = (資料讀取器) => { };
        public 回呼SqlDataReader When讀取到一筆資料
        {
            get { return _When讀取到一筆資料; }
            set { _When讀取到一筆資料 = value; }
        }
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

        /*
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

            if (資料表.Rows.Count == 0) return null;

            return 資料表;
        }

        public DataRow Get資料列()
        {
            return Get資料表().Rows[0];
        }
        */

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
        //物件方法 結束
    }
}