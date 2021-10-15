using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 用戶
    {
        public int Id { get; set; }
        public string 帳號 { get; set; }
        public string 密碼 { get; set; }
        public string 名字 { get; set; }
        public string 手機 { get; set; }
        public DateTime 註冊日期 { get; set; }
        public string 大頭貼 { get; set; }
        public int 點數 { get; set; }

        public List<Hashtag> GetHashtag清單()
        {
            return new SelectHashtagList("User", Id).Get();
        }
    }
}