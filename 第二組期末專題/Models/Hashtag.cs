using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class Hashtag : Dictionary<string, object>
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public string 名稱 { get { return (string)this["名稱"]; } set { this["名稱"] = value; } }
        public string 類別 { get { return (string)this["類別"]; } set { this["類別"] = value; } }

        public List<文章> Get文章List()
        {
            var 文章HashtagList = new 資料庫任務("SELECT * FROM [文章Hashtag] WHERE [Hashtag_FK]=@ID;").注入參數by(new { ID = this["Id"] }).Get();

            List<string> 文章IdList = new List<string>();
            foreach(var 文章Hashtag in 文章HashtagList)
            {
                文章IdList.Add("[Id]=" + 文章Hashtag["文章_FK"]);
            }
            string where = string.Join(" OR ", 文章IdList);

            return new 任務SelectList<文章>($"SELECT * FROM [文章] WHERE ({where});").Get();
        }
    }
}