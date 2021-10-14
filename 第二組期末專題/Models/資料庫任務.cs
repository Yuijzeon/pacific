using System.Data;
using System.Data.SqlClient;

namespace 第二組期末專題.Models
{
    public class 資料庫任務
    {
        //建構函式 開始
        public 資料庫任務() {}

        public 資料庫任務(string str)
        {
            查詢字串 = str;
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

        public delegate SqlCommand 回呼指令(SqlCommand 指令);
        private 回呼指令 _注入參數 = (指令) => 指令;
        /*  delegate語句寫法:
            private 回呼指令 _注入參數 = delegate (SqlCommand 指令) { return 指令; }
            懶大語句寫法:
            private 回呼指令 _注入參數 = (指令) => 指令;
            懶大語句寫法(多行):
            private 回呼指令 _注入參數 = (指令) => { return 指令; };  */
        public 回呼指令 注入參數
        {
            get { return _注入參數; }
            set { _注入參數 = value; }
        }

        public delegate void 回呼資料擷取器(SqlDataReader 資料擷取器);
        private 回呼資料擷取器 _When擷取到一筆資料 = (資料擷取器) => { };
        public 回呼資料擷取器 When擷取到一筆資料
        {
            get { return _When擷取到一筆資料; }
            set { _When擷取到一筆資料 = value; }
        }
        //物件屬性 結束

        //物件方法 開始
        public void 擷取()
        {
            using (SqlConnection 連線 = new SqlConnection(連線字串))
            {
                連線.Open();
                SqlCommand 指令 = 注入參數(new SqlCommand(查詢字串, 連線));

                SqlDataReader 資料擷取器 = 指令.ExecuteReader();
                while (資料擷取器.Read())
                {
                    When擷取到一筆資料(資料擷取器);
                }
            }
        }

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

        public DataRow Get資料列()
        {
            return Get資料表().Rows[0];
        }

        public object Get資料格()
        {
            return Get資料表().Rows[0][0];
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
        //物件方法 結束
    }
}