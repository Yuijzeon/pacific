using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 旅程包 : 資料表
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        public string 標題 { get { return (string)this["標題"]; } set { this["標題"] = value; } }
        public string 描述 { get { return (string)this["描述"]; } set { this["描述"] = value; } }
        public int 作者用戶_FK { get { return (int)this["作者用戶_FK"]; } set { this["作者用戶_FK"] = value; } }


        public 用戶 Get作者()
        {
            return 資料庫.讀取<用戶>(this["作者用戶_FK"]);
        }
        
        public List<文章> Get文章清單()
        {
            List<string> whereList = new List<string>();

            new SQL任務($"SELECT * FROM [旅程包_link] WHERE [旅程包_FK]={this["Id"]};").讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["文章_FK"]);
            });

            return 資料庫.讀取<文章>($"WHERE ({string.Join(" OR ", whereList)})");
        }
        
    }
}