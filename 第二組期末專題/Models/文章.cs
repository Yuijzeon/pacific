using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 文章 : 資料表
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public string 標題 { get { return (string)this["標題"]; } set { this["標題"] = value; } }
        public int 作者用戶_FK { get { return (int)this["作者用戶_FK"]; } set { this["作者用戶_FK"] = value; } }
        public string 內容 { get { return (string)this["內容"]; } set { this["內容"] = value; } }
        public DateTime 日期起始 { get { return (DateTime)this["日期起始"]; } set { this["日期起始"] = value; } }
        public DateTime 日期結束 { get { return (DateTime)this["日期結束"]; } set { this["日期結束"] = value; } }
        public int 圖片_FK { get { return (int)this["圖片_FK"]; } set { this["圖片_FK"] = value; } }
        public string 時段 { get { return (string)this["時段"]; } set { this["時段"] = value; } }
        public string 地點 { get { return (string)this["地點"]; } set { this["地點"] = value; } }
        public int 接待人數 { get { return (int)this["接待人數"]; } set { this["接待人數"] = value; } }
        public string 類型 { get { return (string)this["類型"]; } set { this["類型"] = value; } }


        public 用戶 Get作者()
        {
            return 資料庫.讀取<用戶>(this["作者用戶_FK"]);
        }

        public int Get收藏數()
        {
            return 資料庫.計數<用戶Favorite>($"WHERE [收藏文章_FK]={this["Id"]}");
        }

        public int Get評論數()
        {
            return 資料庫.計數<評級>($"WHERE [文章_FK]={this["Id"]}");
        }

        public List<用戶> Get收藏用戶清單()
        {
            List<string> whereList = new List<string>();

            new SQL任務($"SELECT * FROM [用戶Favorite] WHERE [收藏文章_FK]={this["Id"]};").讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["收藏文章_FK"]);
            });

            return 資料庫.讀取<用戶>($"WHERE ({string.Join(" OR ", whereList)})");
        }

        public List<評級> Get評級清單()
        {
            return 資料庫.讀取<評級>("WHERE [文章_FK]=" + this["Id"]);
        }

        public List<Hashtag> GetHashtag清單()
        {
            List<string> whereList = new List<string>();

            new SQL任務($"SELECT * FROM [文章Hashtag] WHERE [文章_FK]={this["Id"]};").讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["Hashtag_FK"]);
            });

            return 資料庫.讀取<Hashtag>($"WHERE ({string.Join(" OR ", whereList)})");
        }

        public List<旅程包> Get旅程包清單()
        {
            List<string> whereList = new List<string>();

            new SQL任務($"SELECT * FROM [旅程包_link] WHERE [文章_FK]={this["Id"]};").讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["旅程包_FK"]);
            });

            return 資料庫.讀取<旅程包>($"WHERE ({string.Join(" OR ", whereList)})");
        }

        public string Get圖片路徑()
        {
            var 圖片 = 資料庫.讀取<圖片>(this["圖片_FK"]);

            if (圖片 != null)
                return (string)圖片["路徑"];

            return "bg_3.jpg";
        }
    }
}