using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 文章
    {
        public int Id { get; set; }
        public string 標題 { get; set; }
        public int 作者用戶_FK { get; set; }
        public string 內容 { get; set; }
        public DateTime 日期起始 { get; set; }
        public DateTime 日期結束 { get; set; }
        public string 時段起始 { get; set; }
        public string 時段 { get; set; }
        public string 地點 { get; set; }
        public int 接待人數 { get; set; }
        public string 類型 { get; set; }


        public 用戶 Get作者()
        {
            return new 任務SelectById<用戶>(作者用戶_FK).Get();
        }

        public int Get收藏數()
        {
            string 查詢字串 = "SELECT COUNT(*) FROM [用戶Favorite] WHERE 收藏文章_FK=" + Id + ";";
            return (int)new 資料庫任務(查詢字串).Get資料格();
        }

        public List<用戶> Get收藏用戶清單()
        {
            string 查詢字串 = "SELECT * FROM [用戶Favorite] WHERE 收藏文章_FK=" + Id + ";";
            return new 任務SelectList<用戶>(查詢字串).GetBy("用戶_FK");
        }

        public List<評級> Get評級清單()
        {
            string 查詢字串 = "SELECT * FROM [評級] WHERE 文章_FK=" + Id + ";";
            return new 任務SelectList<評級>(查詢字串).Get();
        }

        public List<Hashtag> GetHashtag清單()
        {
            string 查詢字串 = "SELECT * FROM [文章Hashtag] WHERE 文章_FK=" + Id + ";";
            return new 任務SelectList<Hashtag>(查詢字串).GetBy("Hashtag_FK");
        }
    }
}