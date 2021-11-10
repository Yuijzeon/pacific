using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶 : 資料表
    {
        public int Id { get { return (int)this["Id"]; } set { this["Id"] = value; } }
        
        public string 帳號 { get { return (string)this["帳號"]; } set { this["帳號"] = value; } }
        
        public string 密碼 { get { return (string)this["密碼"]; } set { this["密碼"] = value; } }
        
        public string 名字 { get { return (string)this["名字"]; } set { this["名字"] = value; } }
        
        public string 手機 { get { return (string)this["手機"]; } set { this["手機"] = value; } }
        public string 註冊日期 { get { return (string)this["註冊日期"]; } set { this["註冊日期"] = value; } }
        public string 大頭貼 { get { return (string)this["大頭貼"]; } set { this["大頭貼"] = value; } }
        public int 點數 { get { return (int)this["點數"]; } set { this["點數"] = value; } }



        public List<Hashtag> GetHashtag清單()
        {
            List<string> whereList = new List<string>();

            new SQL任務($"SELECT * FROM [用戶Hashtag] WHERE [用戶_FK]={this["Id"]};").讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["Hashtag_FK"]);
            });

            return 資料庫.讀取<Hashtag>($"WHERE ({string.Join(" OR ", whereList)})");
        }

        public List<文章> Get創作文章清單()
        {
            return 資料庫.讀取<文章>("WHERE [作者用戶_FK]=" + this["Id"]);
        }

        public List<文章> Get收藏文章清單()
        {
            List<string> whereList = new List<string>();

            new SQL任務($"SELECT * FROM [用戶Favorite] WHERE [用戶_FK]={this["Id"]};").讀取((讀取器) =>
            {
                whereList.Add("[Id]=" + 讀取器["收藏文章_FK"]);
            });

            return 資料庫.讀取<文章>($"WHERE ({string.Join(" OR ", whereList)})");
        }

        public List<旅程包> Get旅程包清單()
        {
            return 資料庫.讀取<旅程包>("WHERE [作者用戶_FK]=" + this["Id"]);
        }

        public List<圖片> Get上傳圖片清單()
        {
            return 資料庫.讀取<圖片>("WHERE [上傳用戶_FK]=" + this["Id"]);
        }

        public List<提問> Get提問清單()
        {
            return 資料庫.讀取<提問>("WHERE [提問用戶_FK]=" + this["Id"]);
        }

        public string Get大頭貼()
        {
            if (this["大頭貼"] is DBNull || string.IsNullOrEmpty((string)this["大頭貼"]))
                return "person_2.jpg";

            return this["大頭貼"] as string;
        }

        public List<文章> Get最新三筆文章()
        {
            return new SQL任務(
                "SELECT TOP 3 [文章].* FROM [文章] WHERE [作者用戶_FK]=" + this["Id"] + " ORDER BY [Id] DESC"
                ).讀取<文章>();
        }
    }
}