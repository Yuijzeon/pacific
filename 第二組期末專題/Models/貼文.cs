using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 第二組期末專題.Models
{
    public class 貼文
    {
        public int Id { get; set; }
        public string 文章title { get; set; }
        public string 文章內容 { get; set; }
        public 用戶 User { get; set; }
    }
}