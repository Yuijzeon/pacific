using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶 : Dictionary<string, object>
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
            string 查詢字串 = "SELECT * FROM [用戶Hashtag] WHERE 用戶_FK=" + this["Id"];
            return new 任務SelectList<Hashtag>(查詢字串).GetBy("Hashtag_FK");
        }

        public List<文章> Get創作文章清單()
        {
            string 查詢字串 = "SELECT * FROM [文章] WHERE 作者用戶_FK=" + this["Id"];
            return new 任務SelectList<文章>(查詢字串).Get();
        }

        public List<文章> Get收藏文章清單()
        {
            string 查詢字串 = "SELECT * FROM [用戶Favorite] WHERE 用戶_FK=" + this["Id"];
            return new 任務SelectList<文章>(查詢字串).GetBy("收藏文章_FK");
        }

        public List<旅程包> Get旅程包清單()
        {
            string 查詢字串 = "SELECT * FROM [旅程包] WHERE 作者用戶_FK=" + this["Id"];
            return new 任務SelectList<旅程包>(查詢字串).Get();
        }

        public List<圖片> Get上傳圖片清單()
        {
            string 查詢字串 = "SELECT * FROM [圖片] WHERE 上傳用戶_FK=" + this["Id"];

            return new 任務SelectList<圖片>(查詢字串).Get();
        }

        public List<提問> Get提問清單()
        {
            string 查詢字串 = "SELECT * FROM [提問] WHERE 提問用戶_FK=" + this["Id"];

            return new 任務SelectList<提問>(查詢字串).Get();
        }
    }
}