using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class Hashtag : 資料表
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public string 名稱 { get { return (string)this["名稱"]; } set { this["名稱"] = value; } }
        public string 類別 { get { return (string)this["類別"]; } set { this["類別"] = value; } }

        public List<文章> Get文章List()
        {
            List<string> whereList = new List<string>();

            new SQL任務("SELECT * FROM [文章Hashtag] WHERE [Hashtag_FK]=" + this["Id"]).讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["文章_FK"]);
            });

            return 資料庫.讀取<文章>($"WHERE ({string.Join(" OR ", whereList)})");
        }
    }
}